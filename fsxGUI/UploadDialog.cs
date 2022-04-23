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
    public partial class UploadDialog : Form
    {
        public LibFsxBridge fsx;
        public MainWindow MainWind;
        public readonly string OriginalMainWindowCwd;

        public readonly string[] FilesToUpload;
        public readonly string[] FsxTargetFilePaths;

        public DateTime startUploadTime;

        public readonly List<Upload> Uploads;
        public Upload CurrentUpload;
        public bool AllUploadsFinished;

        private CancellationTokenSource cancelTokenSource;

        public ImageList IconList;

        public UploadDialog(MainWindow mainWind, ImageList iconList, LibFsxBridge libfsx, string[] filesToUpload, string[] fsxTargetFilePaths)
        {
            InitializeComponent();

            FilesToUpload = filesToUpload;
            FsxTargetFilePaths = fsxTargetFilePaths;
            fsx = libfsx;
            Uploads = new List<Upload>();
            cancelTokenSource = new CancellationTokenSource();
            MainWind = mainWind;
            OriginalMainWindowCwd = MainWind.cwd;
            IconList = iconList;

            listView1.SmallImageList = IconList;

            if (FilesToUpload.Length != FsxTargetFilePaths.Length)
            {
                throw new ArgumentException("Os tamanhos de filesToUpload e fsxTargetFilePaths não coincidem.");
            }

            for (int i = 0; i < FsxTargetFilePaths.Length; i++)
            {
                var url = fsx.getUploadURL(FsxTargetFilePaths[i]);
                var fileSize = new FileInfo(filesToUpload[i]).Length;
                Uploads.Add(new Upload(url, filesToUpload[i], fileSize));
            }
        }

        public async void DoAllUploads()
        {
            startUploadTime = DateTime.UtcNow;
            UIUpdateTimer.Start();

            for (int i = 0; i < Uploads.Count; i++)
            {
                if (cancelTokenSource.IsCancellationRequested)
                    break;

                
                listView1.Items[i].SubItems[3].Text = "Uploading";

                CurrentUpload = Uploads[i];

                await CurrentUpload.Start();

                progressBar1.Value = 0;

                try
                {
                    await CurrentUpload.WaitForFinish();

                    if (MainWind.cwd == OriginalMainWindowCwd)
                    {
                        await Task.Delay(100);
                        // Refresh file list there
                        MainWind.openFolder(MainWind.cwd);
                        await MainWind.reloadTreeView();
                    }

                    // Set progress bar to 100%
                    progressBar1.Value = 100;
                    label2.Text = $"100%\n{i + 1} of {Uploads.Count}";
                    listView1.Items[i].SubItems[3].Text = "Finished";

                    CurrentUpload.Dispose();

                    await Task.Delay(200);
                } catch (TaskCanceledException)
                {
                    for (int j = i; j < Uploads.Count; j++)
                        listView1.Items[i].SubItems[3].Text = "Canceled";

                    closeWhenFinished.Checked = false;

                    break;
                }
            }

            AllUploadsFinished = true;
            UIUpdateTimer.Stop();

            cancelButton.Text = "Close";

            MainWind.sysTrayIcon.ShowBalloonTip(4000, $"Finished uploading files.", $"All uploads have finished - took {Utils.elapsedTime(startUploadTime)}.", ToolTipIcon.Info);

            if (closeWhenFinished.Checked) 
                this.Close();
        }

        private int getPercentage(long current, long total)
        {
            return Math.Max(0, Math.Min(100, (int)Math.Floor((double)current / (double)total * 100.0)));
        }

        private void UpdateUserInterface()
        {
            if (CurrentUpload != null && !AllUploadsFinished)
            {
                elapsedTime.Text = Utils.elapsedTime(startUploadTime);
                progressBar1.Value = getPercentage(CurrentUpload.CurrentByteCount, CurrentUpload.TotalBytes);
                label2.Text = $"{progressBar1.Value}%\n{Uploads.IndexOf(CurrentUpload) + 1} of {Uploads.Count}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void UploadDialog_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < FilesToUpload.Length; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.SubItems[0].Text = FilesToUpload[i];
                lvi.SubItems.Add(FsxTargetFilePaths[i]);
                lvi.SubItems.Add(Utils.GetBytesReadable(Uploads[i].TotalBytes));
                lvi.SubItems.Add("Queued");
                lvi.ImageKey = Path.GetExtension(FilesToUpload[i]);

                listView1.Items.Add(lvi);
            }

            listView1_Resize(null, null);

            DoAllUploads();
        }

        private void UploadDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AllUploadsFinished) return;

            var result = MessageBox.Show("Are you sure you wish to cancel all remaining uploads?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cancelTokenSource.Cancel();
                if (CurrentUpload != null && !CurrentUpload.Finished) CurrentUpload.Abort();
                e.Cancel = true;
            } else
            {
                e.Cancel = true;
            }
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
                listView1.Columns[1].Width = listView1.Width - listView1.Columns[2].Width - listView1.Columns[3].Width - 22;
                listView1.EndUpdate();
            }

            _resizing = false;
        }
    }

    public class Upload
    {
        public readonly string FileName;
        public readonly string TargetURL;
        public readonly long TotalBytes;

        public bool Started { get; private set; }
        public bool Finished { get; private set; }
        public bool Aborted { get; private set; }
        public DateTime StartTime { get; private set; }

        private FileStream fileStream;
        private StreamContent httpBodyContent;
        private HttpClient client;
        private Stream httpStream;
        private Task httpWriteTask;
        private CancellationTokenSource cancelTokenSource;

        public Upload(string url, string sourceFile, long fileSize)
        {
            TargetURL = url;
            FileName = sourceFile;
            TotalBytes = fileSize;
            client = new HttpClient();
            cancelTokenSource = new CancellationTokenSource();
            StartTime = DateTime.Now;

            // 1 week to complete a Upload... I think that's good enough, right?
            client.Timeout = TimeSpan.FromDays(7);
        }

        public async Task Start()
        {
            Started = true;
            StartTime = DateTime.Now;

            // FileMode.Create replaces the file if it exists
            fileStream = File.OpenRead(FileName);
            httpBodyContent = new StreamContent(fileStream);
            httpWriteTask = client.PostAsync(TargetURL, httpBodyContent, cancelTokenSource.Token);

            if (cancelTokenSource.IsCancellationRequested)
            {
                fileStream.Dispose();
                httpStream.Dispose();
                httpWriteTask.Dispose();
                httpBodyContent.Dispose();
            }
        }

        public void Abort()
        {
            if (!Finished)
                Aborted = true;

            Finished = true;

            this.Dispose();

            cancelTokenSource.Cancel();
        }

        public Task WaitForFinish()
        {
            return httpWriteTask.WaitAsync(cancelTokenSource.Token);
        }

        public long CurrentByteCount
        {
            get
            {
                try
                {
                    return fileStream.Position;
                } catch (ObjectDisposedException)
                {
                    return TotalBytes;
                }
            }
        }

        public void Dispose()
        {
            client?.Dispose();
            httpStream?.Dispose();
            fileStream?.Dispose();
            httpBodyContent?.Dispose();
        }
    }
}
