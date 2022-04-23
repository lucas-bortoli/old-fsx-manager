using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fsxGUI
{
    public partial class DownloadDialog : Form
    {
        public LibFsxBridge fsx;

        public readonly string FsxParentDir;
        public readonly string[] FsxFilePaths;
        public readonly long[] FsxFileSizes;
        public readonly string TargetDir;

        public DateTime startDownloadTime;

        public readonly List<Download> Downloads;
        public Download CurrentDownload;
        public bool AllDownloadsFinished;

        private CancellationTokenSource cancelTokenSource;

        public ImageList IconList;
        public MainWindow MainWind;

        public DownloadDialog(MainWindow mainWindow, LibFsxBridge libfsx, ImageList iconList, string[] fsxFilePaths, long[] fsxFileSizes, string fsxParentDir, string localTargetDirectoryPath)
        {
            InitializeComponent();

            FsxFilePaths = fsxFilePaths;
            TargetDir = localTargetDirectoryPath;
            fsx = libfsx;
            FsxParentDir = fsxParentDir;
            FsxFileSizes = fsxFileSizes;
            Downloads = new List<Download>();
            cancelTokenSource = new CancellationTokenSource();
            IconList = iconList;
            MainWind = mainWindow;

            listView1.SmallImageList = iconList;

            _lastUIUpdateByteCount = 0;
            _lastUIUpdateDateTime = DateTime.UtcNow;

            if (FsxFileSizes.Length != FsxFilePaths.Length)
            {
                throw new ArgumentException("Os tamanhos de fsxFilePaths e fsxFileSizes não coincidem.");
            }

            for (int i = 0; i < fsxFilePaths.Length; i++)
            {
                var url = fsx.getDownloadURL(fsxFilePaths[i]);
                var outputPath = Path.Combine(TargetDir, Path.GetRelativePath(FsxParentDir, fsxFilePaths[i])).Replace('/', '\\');
                Downloads.Add(new Download(url, outputPath, fsxFileSizes[i]));
            }
        }

        public async void DoAllDownloads()
        {
            startDownloadTime = DateTime.UtcNow;
            UIUpdateTimer.Start();

            for (int i = 0; i < Downloads.Count; i++)
            {
                if (cancelTokenSource.IsCancellationRequested)
                    break;

                var download = Downloads[i];

                listView1.Items[i].SubItems[2].Text = "Downloading";

                try
                {
                    CurrentDownload = download;
                    progressBar1.Value = 100;
                    await download.Start();
                    await download.WaitForFinish();
                } catch(TaskCanceledException)
                {
                    for (int j = i; j < Downloads.Count; j++)
                        listView1.Items[i].SubItems[2].Text = "Canceled";

                    closeWhenFinished.Checked = false;

                    break;
                }

                download.Dispose();

                // Set progress bar to 100%
                progressBar1.Value = 100;
                label2.Text = $"100%\n{i + 1} of {Downloads.Count}";
                listView1.Items[i].SubItems[2].Text = "Finished";
            }

            AllDownloadsFinished = true;
            UIUpdateTimer.Stop();

            openFolder.Enabled = true;
            cancelButton.Text = "Close";

            // Send notification
            MainWind.sysTrayIcon.ShowBalloonTip(4000, $"Finished downloading files.", $"All downloads have finished - took {Utils.elapsedTime(startDownloadTime)}.", ToolTipIcon.Info);

            if (closeWhenFinished.Checked) this.Close();
        }

        private int getPercentage(long current, long total)
        {
            return Math.Max(0, Math.Min(100, (int)Math.Floor((double)current / (double)total * 100.0)));
        }

        private long _lastUIUpdateByteCount = 0;
        private DateTime _lastUIUpdateDateTime = DateTime.UtcNow;
        private void UpdateUserInterface()
        {
            if (CurrentDownload != null && !AllDownloadsFinished)
            {
                int downloadIndex = Downloads.IndexOf(CurrentDownload);
                long dBytes = CurrentDownload.CurrentByteCount - _lastUIUpdateByteCount;
                TimeSpan dTime = DateTime.UtcNow - _lastUIUpdateDateTime;

                downloadRateLabel.Text = Utils.GetBytesReadable((long)Math.Floor(dBytes / dTime.TotalSeconds)).ToString() + "/s";
                elapsedTime.Text = Utils.elapsedTime(startDownloadTime);
                
                progressBar1.Value = getPercentage(CurrentDownload.CurrentByteCount, CurrentDownload.TotalBytes);
                label2.Text = $"{progressBar1.Value}%\n{Downloads.IndexOf(CurrentDownload) + 1} of {Downloads.Count}";

                _lastUIUpdateByteCount = CurrentDownload.CurrentByteCount;
                _lastUIUpdateDateTime = DateTime.UtcNow;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void DownloadDialog_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < FsxFilePaths.Length; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.SubItems[0].Text = FsxFilePaths[i];
                lvi.SubItems.Add(Utils.GetBytesReadable(FsxFileSizes[i]));
                lvi.SubItems.Add("Queued");
                lvi.ImageKey = Path.GetExtension(FsxFilePaths[i]);

                listView1.Items.Add(lvi);
            }

            listView1_Resize(null, null);

            DoAllDownloads();
        }

        private void openFolder_Click(object sender, EventArgs e)
        {
            Utils.OpenWindowsExplorer(TargetDir);
            this.Close();
        }

        private void DownloadDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AllDownloadsFinished) return;

            var result = MessageBox.Show("Are you sure you wish to cancel all remaining downloads?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cancelTokenSource.Cancel();
                if (CurrentDownload != null && !CurrentDownload.Finished) CurrentDownload.Abort();
            }

            e.Cancel = true;
        }

        private void UIUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (cancelTokenSource.IsCancellationRequested)
            {
                UIUpdateTimer.Stop();
                return;
            }

            UpdateUserInterface();
        }

        private bool _resizing = false;
        private void listView1_Resize(object sender, EventArgs e)
        {
            if (!_resizing)
            {
                _resizing = true;

                listView1.BeginUpdate();
                listView1.Columns[0].Width = listView1.Width - listView1.Columns[1].Width - listView1.Columns[2].Width - 22;
                listView1.EndUpdate();
            }

            _resizing = false;
        }
    }

    public class Download
    {
        public readonly string FileName;
        public readonly string SourceURL;
        public readonly long TotalBytes;

        public bool Started { get; private set; }
        public bool Finished { get; private set; }
        public bool Aborted { get; private set; }
        public DateTime StartTime { get; private set; }

        private FileStream fileStream;
        private HttpClient client;
        private Stream httpStream;
        private Task copyTask;
        private CancellationTokenSource cancelTokenSource;

        public Download(string url, string targetFile, long fileSize)
        {
            SourceURL = url;
            FileName = targetFile;
            TotalBytes = fileSize;
            client = new HttpClient();
            cancelTokenSource = new CancellationTokenSource();

            // 1 week to complete a download... I think that's good enough, right?
            client.Timeout = TimeSpan.FromDays(7);
        }

        public async Task Start()
        {
            Started = true;
            StartTime = DateTime.Now;

            // Ensure containing directory
            Directory.CreateDirectory(Path.GetDirectoryName(FileName));

            // FileMode.Create replaces the file if it exists
            fileStream = new FileStream(FileName, FileMode.Create);
            httpStream = await client.GetStreamAsync(SourceURL, cancelTokenSource.Token);
            copyTask = httpStream.CopyToAsync(fileStream, cancelTokenSource.Token);

            if (cancelTokenSource.IsCancellationRequested)
            {
                fileStream.Dispose();
            }
        }

        public void Abort()
        {
            if (!Finished)
                Aborted = true;

            Finished = true;
            fileStream.Dispose();

            cancelTokenSource.Cancel();
        }

        public async Task WaitForFinish()
        {
            await copyTask.WaitAsync(cancelTokenSource.Token);
            fileStream.Dispose();
        }

        public long CurrentByteCount
        {
            get
            {
                return fileStream.Length;
            }
        }

        public void Dispose()
        {
            client?.Dispose();
            httpStream?.Dispose();
            fileStream?.Dispose();
        }
    }
}
