using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net;


namespace fsxGUI
{
    public enum FsxEntryType
    {
        EntryTypeFile = 0,
        EntryTypeDirectory = 1
    }

    public abstract class FsxEntry
    {
        public readonly string? Name;
    }

    public class FsxFile : FsxEntry
    {
        public new readonly string Name;
        public readonly Int64 Size;
        public readonly Int64 CreationDate;
        public readonly string Comment;
        public FsxFile(string name, Int64 size, Int64 cdate, string comment) {
            Name = name;
            Size = size;
            CreationDate = cdate;
            Comment = comment;
        }
    }

    public class FsxDirectory : FsxEntry
    {
        public new readonly string Name;
        public readonly int ChildCount;
        public FsxDirectory(string name, int childCount)
        {
            Name = name;
            ChildCount = childCount;
        }
    }
    
    public class LibFsxBridge
    {
        public readonly string nodejsBinaryLocation;
        public readonly string nodejsScriptLocation;

        public Process? nodeProcess;

        public readonly string WebhookUrl;
        public readonly string FsxDrive;
        public readonly int Port;

        public LibFsxBridge(string fsxDrive, int port, string webhookUrl)
        {
            FsxDrive = fsxDrive;
            Port = port;
            WebhookUrl = webhookUrl;

            // Determine Node.js target location
            nodejsBinaryLocation = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "fsx_node.exe");
            nodejsScriptLocation = Path.Combine(Path.GetTempPath(), "fsx_script.mjs");

            Debug.WriteLine("Looking for Node.js binary at " + nodejsBinaryLocation);
            Debug.WriteLine("Node.js script will be written to " + nodejsScriptLocation);

            // Kill previous processes that may still be running
            foreach (var process in Process.GetProcessesByName("fsx_node"))
            {
                Debug.WriteLine("Killing PID " + process.Id.ToString());
                process.Kill();
                Thread.Sleep(500);
            }

            // Write embedded script to temporary location on disk
            File.WriteAllText(nodejsScriptLocation, Properties.Resources.nodejsScript);

            Debug.WriteLine("Node.js script write finished.");

            Debug.WriteLine("Script size: " + Properties.Resources.nodejsScript.Length + " characters");

            this.startNodeProcess(new string[] {});
        }
        private Process startNodeProcess(string[] args) {
            if (this.nodeProcess != null && !this.nodeProcess.HasExited)
                return this.nodeProcess;

            var proc = new Process();
            var startInfo = new ProcessStartInfo(nodejsBinaryLocation);

            startInfo.UseShellExecute = false;
            startInfo.Environment.Add("DISCORD_WEBHOOK", WebhookUrl);
            Debug.WriteLine("Data file location = " + FsxDrive);
            startInfo.Environment.Add("FSX_DRIVE", FsxDrive);
            startInfo.Environment.Add("PORT", Properties.Settings.Default.PortNumber.ToString());
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;

            startInfo.ArgumentList.Add(nodejsScriptLocation);

            for (int i = 0; i < args.Length; i++)
            {
                startInfo.ArgumentList.Add(args[i]);
            }

            proc.StartInfo = startInfo;

            proc.OutputDataReceived += (sender, args) =>
            {
                Debug.WriteLine(args.Data);
            };

            proc.ErrorDataReceived += (sender, args) =>
            {
                Debug.WriteLine(args.Data);
            };

            proc.Exited += (sender, args) =>
            {
                Debug.WriteLine("Node.js process exited! Code " + proc.ExitCode);
                if (proc.ExitCode != 0)
                    MessageBox.Show("Node.js process crashed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            proc.Start();
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();

            this.nodeProcess = proc;

            return proc;
        }

        public static string setupRequestURL(string[] args) {
            HttpClient client = new HttpClient();
            string API_BASE = $"http://localhost:{Properties.Settings.Default.PortNumber}";
            string query = "?";

            // Build query string
            foreach (string arg in args) {
                query = query + $"arg={Uri.EscapeDataString(arg)}&";
            }



            Debug.WriteLine("HTTP GET " + API_BASE + "/" + query);

            return API_BASE + '/' + query;
        }

        public async Task<string> uploadFile(string localSourceFile, string fsxTargetPath)
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromDays(14);
            var fileStream = File.OpenRead(localSourceFile);
            var reqBodyContents = new StreamContent(fileStream);
            var request = await client.PostAsync(setupRequestURL(new string[] { "upload", fsxTargetPath }), reqBodyContents);
            Debug.WriteLine($"File upload status code: {request.StatusCode}");
            return fsxTargetPath;
        }

        public async Task<List<FsxEntry>> readDirectory(string path)
        {
            var client = new HttpClient();
            var request = await client.GetAsync(setupRequestURL(new string[] { "ls", path }));
            var output = await request.Content.ReadAsStringAsync();

            var entries = new List<FsxEntry>();

            foreach (var line in output.Split('\n'))
            {
                string[] fields = line.Trim().Split(',');

                // Maybe the line is empty, who knows.
                if (fields.Length < 2)
                    continue;

                if (string.Equals(fields[1], "file"))
                {
                    var file = new FsxFile(Uri.UnescapeDataString(fields[0]), long.Parse(Uri.UnescapeDataString(fields[2])), long.Parse(Uri.UnescapeDataString(fields[3])), Uri.UnescapeDataString(fields[4]));
                    entries.Add(file);
                } else if (string.Equals(fields[1], "directory")) {
                    var directory = new FsxDirectory(Uri.UnescapeDataString(fields[0]), int.Parse(Uri.UnescapeDataString(fields[2])));
                    entries.Add(directory);
                }
            }

            return entries;
        }

        public async Task<List<(string, int)>> getDirTree(string root)
        {
            var client = new HttpClient();
            var request = await client.GetAsync(setupRequestURL(new string[] { "get-dir-tree", root }));
            var output = await request.Content.ReadAsStringAsync();

            var entries = new List<(string, int)>();

            foreach (var line in output.Split('\n'))
            {
                string[] fields = line.Trim().Split(',');

                // Maybe the line is empty, who knows.
                if (fields.Length < 2)
                    continue;


                entries.Add((Uri.UnescapeDataString(fields[0]), int.Parse(fields[1])));
            }

            return entries;
        }

        // Returns Tuple(string filePath (using the parameter `root` as the root dir), long sizeBytes)
        public async Task<List<(string, long)>> getFileTree(string root)
        {
            var client = new HttpClient();
            var request = await client.GetAsync(setupRequestURL(new string[] { "get-file-tree", root }));
            var output = await request.Content.ReadAsStringAsync();

            var entries = new List<(string, long)>();

            foreach (var line in output.Split('\n'))
            {
                string[] fields = line.Trim().Split(',');

                // Maybe the line is empty, who knows.
                if (fields.Length < 2)
                    continue;

                entries.Add((Uri.UnescapeDataString(fields[0]), long.Parse(fields[1])));
            }

            return entries;
        }

        public async Task<Dictionary<string, string>> getHeaders()
        {
            var client = new HttpClient();
            var request = await client.GetAsync(setupRequestURL(new string[] { "get-headers" }));
            var output = await request.Content.ReadAsStringAsync();

            var headers = new Dictionary<string, string>();

            foreach (var line in output.Split('\n'))
            {
                string[] fields = line.Trim().Split(',');

                // Maybe the line is empty, who knows.
                if (fields.Length < 2)
                    continue;

                headers.Add(Uri.UnescapeDataString(fields[0]), Uri.UnescapeDataString(fields[1]));
            }

            return headers;
        }

        public async Task setHeader(string key, string value)
        {
            var client = new HttpClient();
            await client.GetAsync(setupRequestURL(new string[] { "set-header", key, value }));
        }

        public static async Task<bool> isWebhookUrlValid(string webhookUrl)
        {
            // These must be on the url for it to be valid
            if (!webhookUrl.Contains("discord") || !webhookUrl.Contains("/api/webhooks"))
                return false;

            var client = new HttpClient();
            var request = await client.GetAsync(webhookUrl);
            return request.IsSuccessStatusCode;
        }

        public async Task<bool> entryExists(string path)
        {
            var client = new HttpClient();
            var request = await client.GetAsync(setupRequestURL(new string[] { "exists", path }));
            var output = await request.Content.ReadAsStringAsync();
            var exists = output.Contains("true");
            Debug.WriteLine("entryExists: " + output);
            return exists;
        }

        public async Task<string> mv(string sourcePath, string targetPath)
        {
            var client = new HttpClient();
            var request = await client.GetAsync(setupRequestURL(new string[] { "mv", sourcePath, targetPath }));
            var output = await request.Content.ReadAsStringAsync();
            Debug.WriteLine("mv: " + output);
            return output;
        }

        public async Task<string> cp(string sourcePath, string targetPath)
        {
            var client = new HttpClient();
            var request = await client.GetAsync(setupRequestURL(new string[] { "cp", sourcePath, targetPath }));
            var output = await request.Content.ReadAsStringAsync();
            Debug.WriteLine("cp: " + output);
            return output;
        }

        public async Task<string> rm(string targetPath)
        {
            var client = new HttpClient();
            var request = await client.GetAsync(setupRequestURL(new string[] { "rm", targetPath }));
            var output = await request.Content.ReadAsStringAsync();
            Debug.WriteLine("rm: " + output);
            return output;
        }

        public async Task<string> saveFileSystem()
        {
            var client = new HttpClient();
            var request = await client.GetAsync(setupRequestURL(new string[] { "save" }));
            var output = await request.Content.ReadAsStringAsync();

            return output;
        }

        public string getDownloadURL(string file)
        {
            return setupRequestURL(new string[] { "download", file });
        }

        public string getUploadURL(string file)
        {
            return setupRequestURL(new string[] { "upload", file });
        }

        public void CloseProcess()
        {
            if (this.nodeProcess != null)
            {
                this.nodeProcess.Kill();
                this.nodeProcess.Close();
            }
        }
    }
}
