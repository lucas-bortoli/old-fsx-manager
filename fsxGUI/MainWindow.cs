using System.Diagnostics;

namespace fsxGUI
{
    enum ClipboardOperation
    {
        None = 0,
        Copy = 1,
        Cut = 2
    }

    public partial class MainWindow : Form
    {
        LibFsxBridge fsx;
        List<string> clipboardFiles;
        ClipboardOperation clipboardOperation;

        public string cwd {
            get { return this.cwdStatusStrip.Text; }
            set { this.cwdStatusStrip.Text = value; }
        }

        public MainWindow()
        {
            InitializeComponent();

            var settings = Properties.Settings.Default;

            cwd = "/";
            fsx = new LibFsxBridge(settings.DataFileLocation, settings.PortNumber, settings.WebhookURL);
            clipboardFiles = new List<string>();
            clipboardOperation = ClipboardOperation.None;
            sysTrayIcon.Icon = this.Icon;
        }

        private async Task populateTreeView(TreeNode driveNode)
        {
            driveNode.Nodes.Clear();

            var listOfPaths = await fsx.getDirTree("/");

            foreach (var (path, childCount) in listOfPaths)
            {
                TreeNode? lastNode = null;
                string subPathAgg = "/";

                foreach (string subPath in path.Split('/'))
                {
                    if (string.IsNullOrWhiteSpace(subPath)) continue;
                    subPathAgg += subPath + '/';
                    TreeNode[] nodes = treeView1.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = addFolderToTreeView(driveNode, subPathAgg, subPath);
                        else
                            lastNode = addFolderToTreeView(lastNode, subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
            }
        }

        public TreeNode addFolderToTreeView(TreeNode parent, string path, string name)
        {
            Debug.WriteLine("addFolderToTreeView key = " + path);
            var childNode = parent.Nodes.Add(path, name, FileIconsSmall.Images.IndexOfKey("<folderClosed>"), FileIconsSmall.Images.IndexOfKey("<folderOpened>"));
            if (parent.Level <= 1)
                parent.Expand();
            return childNode;
        }


        public async Task<bool> reloadTreeView()
        {
            treeView1.Nodes.Clear();
            TreeNode driveNode = treeView1.Nodes.Add("/", Path.GetFileName(fsx.FsxDrive), FileIconsSmall.Images.IndexOfKey("driveIcon"), FileIconsSmall.Images.IndexOfKey("driveIcon"));
            await populateTreeView(driveNode);
            treeView1.SelectedNode = driveNode;
            return true;
        }

        private TreeNode? getTreeNodeFromPath(string path)
        {
            // Add trailing '/' if it's not there
            if (!path.EndsWith("/")) path = path + '/';

            var searchResults = treeView1.Nodes.Find(path, true);

            Debug.WriteLine("getTreeNodeFromPath: " + path);

            // Return the first match or NULL if not found
            return searchResults.Length > 0 ? searchResults[0] : null;
        }

        public async void openFolder(string path)
        {
            cwd = path;
            listView1.Items.Clear();

            var entries = await fsx.readDirectory(path);

            Debug.WriteLine("openFolder: " + entries.Count + " items");
            addFolderToListView("..", 0);
            foreach (var entry in entries)
            {
                if (entry is FsxDirectory directory)
                {
                    addFolderToListView(directory.Name, directory.ChildCount);
                } else if (entry is FsxFile file)
                {
                    addFileToListView(file.Name, file.Size, file.CreationDate);
                }
            }

            var treeNode = getTreeNodeFromPath(path);

            if (treeNode != null)
                treeView1.SelectedNode = treeNode;

            statusItemCount.Text = Utils.plural(listView1.Items.Count - 1, "item");
        }

        public void addFolderToListView(string name, int childCount)
        {
            var childCountLabel = Utils.plural(childCount, "item");
            var iconName = childCount > 0 ? "<folderOpened>" : "<folderClosed>";

            if (name == "..") childCountLabel = "";

            var item = new ListViewItem(new string[] { name, childCountLabel, "", "Folder"  }, iconName);
            item.Tag = "directory";
            listView1.Items.Add(item);
        }

        public void addFileToListView(string name, long size, long creationTimestamp)
        {
            DateTime ctime = DateTimeOffset.FromUnixTimeMilliseconds(creationTimestamp).DateTime;
            var item = new ListViewItem(new string[] { name, Utils.GetBytesReadable(size), ctime.ToString(), "File" });
            Utils.LoadFileIcon(name, listView1.SmallImageList, listView1.LargeImageList);
            item.Tag = "file";
            item.ImageKey = Path.GetExtension(name);
            listView1.Items.Add(item);
        }

        public string treeNodeToPath(TreeNode node)
        {
            var p = Utils.fsxJoinAndResolvePath("/", string.Join("/", node.FullPath.Split('/').Skip(1).ToArray()));
            Debug.WriteLine("getFsxPathToFolder: " + p + " ::: " + node.FullPath);
            return p;
        }

        public void openNewFolderDialog()
        {
            using (var dialog = new CreateDirectoryDialog())
            {
                dialog.StartPosition = FormStartPosition.CenterParent;
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var folderName = dialog.getResults();
                    addFolderToListView(folderName, 0);
                    addFolderToTreeView(treeView1.SelectedNode, Utils.fsxJoinAndResolvePath(cwd, folderName), folderName);
                }

                dialog.Dispose();
            }
        }

        public void uploadFiles(string[] sourceFiles, string[] fsxTargetFiles)
        {
            var uploadDialog = new UploadDialog(this, listView1.SmallImageList, fsx, sourceFiles, fsxTargetFiles);
            uploadDialog.Show();
        }

        private void createDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openNewFolderDialog();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var targetItem = listView1.SelectedItems[0];

                // When a folder has been double-clicked in the listView, open it
                if (string.Equals(targetItem.Tag, "directory"))
                {
                    var targetDirectory = Utils.fsxJoinAndResolvePath(cwd, targetItem.Text);
                    //var treeViewNodes = treeView1.Nodes.Find(targetDirectory, true);

                    //if (treeViewNodes.Length > 0)
                    {
                    //    treeView1.SelectedNode = treeViewNodes[0];
                        openFolder(targetDirectory);
                    //    populateTreeView(treeView1.SelectedNode);
                    }
                }
            }
        }

        private void newDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openNewFolderDialog();
        }

        private void OpenFilePickerAndUploadToCwd()
        {
            if (uploadFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fsxTargetPaths = new List<string>();
                foreach (var selectedFile in uploadFileDialog.FileNames)
                {
                    var fsxTargetPath = Utils.fsxJoinAndResolvePath(cwd, Path.GetFileName(selectedFile));
                    fsxTargetPaths.Add(fsxTargetPath);
                }
                uploadFiles(uploadFileDialog.FileNames, fsxTargetPaths.ToArray());
            }
        }

        private void uploadFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFilePickerAndUploadToCwd();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            // Go to parent directory
            openFolder(Utils.fsxJoinAndResolvePath(cwd, ".."));
        }

        private async void saveFilesystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string errorMessage = await fsx.saveFileSystem();

            if (errorMessage.Length < 1)
            {
                MessageBox.Show("The filesystem data file was saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("There was an error saving the filesystem:\n" + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            await FirstTimeSetup();
            
            setViewMode(View.Details);
            await this.reloadTreeView();
            openFolder("/");
        }

        private async Task FirstTimeSetup()
        {
            bool webhookValid = false;

            try
            {
                webhookValid = await LibFsxBridge.isWebhookUrlValid(Properties.Settings.Default.WebhookURL);
            } catch(Exception)
            {
                // Invalid URL... force the user to reconfigure i
            }

            if (webhookValid)
                return;

            while (!webhookValid)
            {
                MessageBox.Show("The webhook URL is not set up. Please click OK to open the settings page, and set it up there.", "Initial setup", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var settingsDialog = new SettingsDialog();
                settingsDialog.button1.Enabled = false;
                var dialogChoice = settingsDialog.ShowDialog();

                if (dialogChoice == DialogResult.Cancel)
                    Environment.Exit(1);

                webhookValid = await LibFsxBridge.isWebhookUrlValid(Properties.Settings.Default.WebhookURL);
            }

            // Here, the webhook is working. Restart the program.
            Application.Restart();
        }


        // When a new node is selected in the treeview, open that directory.
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown) return;

            Debug.WriteLine("Selected treeNode key = " + e.Node.Name);
            openFolder(e.Node.Name);
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
           // if (e.Action == TreeViewAction.Unknown) e.Cancel = true;
        }

        private void treeViewContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            renameFolderToolStripMenuItem.Enabled = treeView1.SelectedNode != null && treeView1.SelectedNode.Level > 0;
            newFolderToolStripMenuItem.Enabled = treeView1.SelectedNode != null;
        }

        private void renameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                _nameBeforeRenaming = treeView1.SelectedNode.Text;
                treeView1.SelectedNode.BeginEdit();
            }
        }
        
        // This variable stores the old name before renaming a file/folder in the treeView or listView. It is used to restore
        // the old name if the new name is invalid.
        private string _nameBeforeRenaming;
        private async void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var newName = e.Label;

            if (string.IsNullOrWhiteSpace(newName) || newName == "..")
            {
                e.CancelEdit = true;
                e.Node.Text = _nameBeforeRenaming;
                return;
            }

            if (!Utils.isValidName(newName))
            {
                e.CancelEdit = true;
                e.Node.Text = _nameBeforeRenaming;
                MessageBox.Show("A file or folder name cannot contain any of the following characters:\n" + string.Join(' ', Utils.FORBIDDEN_NAME_CHARACTERS), "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sourcePath = Utils.fsxJoinAndResolvePath(treeNodeToPath(e.Node.Parent), _nameBeforeRenaming);
            var targetPath = Utils.fsxJoinAndResolvePath(treeNodeToPath(e.Node.Parent), newName);

            if (await fsx.entryExists(targetPath))
            {
                e.CancelEdit = true;
                e.Node.Text = _nameBeforeRenaming;
                MessageBox.Show("There's already a folder with that name in the parent directory.", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var errorMessage = await fsx.mv(sourcePath, targetPath);

            if (errorMessage.Length > 0)
            {
                e.CancelEdit = true;
                e.Node.Text = _nameBeforeRenaming;
                MessageBox.Show("There was an error while renaming the directory:\n" + errorMessage, "Renaming error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update listview
            openFolder(Utils.fsxJoinAndResolvePath(treeNodeToPath(e.Node.Parent)));
        }

        // Checks if the listView selection has an item with the given text. Used to check for "..", for example.
        private bool listViewSelectionHasText(string text)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                if (item.Text == text) return true;
            }

            return false;
        }

        private void fileListContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var listViewHasSelectedParentDir = listViewSelectionHasText("..");

            renameListViewContextMenu.Enabled = listView1.SelectedItems.Count == 1 && !listViewHasSelectedParentDir;
            downloadToolStripMenuItem.Enabled =
                !listViewHasSelectedParentDir &&
                listView1.SelectedItems.Count >= 1; /*&&
                listView1.SelectedItems.Cast<ListViewItem>().ToList().Find(i => string.Equals(i.Tag, "directory")) == null);*/

            deleteToolStripMenuItem.Enabled = listView1.SelectedItems.Count > 0 && !listViewHasSelectedParentDir;

            pasteToolStripMenuItem.Enabled = clipboardFiles.Count > 0;
            cutToolStripMenuItem.Enabled = listView1.SelectedItems.Count > 0 && !listViewHasSelectedParentDir;
            copyToolStripMenuItem.Enabled = listView1.SelectedItems.Count > 0 && !listViewHasSelectedParentDir;
        }

        private void renameListViewContextMenu_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1 || listView1.SelectedItems[0].Text == "..")
                return;

            var target = listView1.SelectedItems[0];
            _nameBeforeRenaming = target.Text;
            target.BeginEdit();
        }

        private async void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            var newName = e.Label;

            if (string.IsNullOrWhiteSpace(newName) || newName == "..")
            {
                e.CancelEdit = true;
                listView1.Items[e.Item].Text = _nameBeforeRenaming;
                return;
            }

            if (!Utils.isValidName(newName))
            {
                e.CancelEdit = true;
                listView1.Items[e.Item].Text = _nameBeforeRenaming;
                var result = MessageBox.Show("A file or folder name cannot contain any of the following characters:\n" + string.Join(' ', Utils.FORBIDDEN_NAME_CHARACTERS), "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sourcePath = Utils.fsxJoinAndResolvePath(cwd, _nameBeforeRenaming);
            var targetPath = Utils.fsxJoinAndResolvePath(cwd, newName);

            if (await fsx.entryExists(targetPath))
            {
                e.CancelEdit = true;
                listView1.Items[e.Item].Text = _nameBeforeRenaming;
                var result = MessageBox.Show("There's already a file/folder with that name in the parent directory.", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var errorMessage = await fsx.mv(sourcePath, targetPath);

            if (errorMessage.Length > 0)
            {
                e.CancelEdit = true;
                listView1.Items[e.Item].Text = _nameBeforeRenaming;
                MessageBox.Show("There was an error while renaming the file/folder:\n" + errorMessage, "Renaming error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If this was a directory, update treeview to match new name
            if (string.Equals(listView1.Items[e.Item].Tag, "directory"))
                await reloadTreeView();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1) return;

            var targets = listView1.SelectedItems;
            var confirmation = MessageBox.Show($"Are you sure you want to delete {targets.Count} items? This action can't be undone.", "Confirm file deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes) return;

            foreach (ListViewItem target in targets) {
                var path = Utils.fsxJoinAndResolvePath(cwd, target.Text);
                await fsx.rm(path);
            }

            await reloadTreeView();
            openFolder(cwd);
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openNewFolderDialog();
        }

        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // Don't allow renaming drives in the treeview
            if (e.Node.Level == 0)
            {
                e.CancelEdit = true;
                return;
            }

            _nameBeforeRenaming = e.Node.Text;
        }

        private async void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> filePaths = new List<string>();
            List<long> fileSizes = new List<long>();

            // Get file entries from a list of selected items in cwd.
            var entriesInCwd = await fsx.readDirectory(cwd);

            foreach (ListViewItem selItem in listView1.SelectedItems)
            {
                var entry = entriesInCwd.Find(e =>
                {
                    // Need to cast to their respective types before comparing (even though they both share
                    // the "Name" field), or else the string comparision will always be False.
                    if (e is FsxDirectory dir) 
                        return string.Equals(dir.Name, selItem.Text) && !string.Equals(dir.Name, "..");
                    else if (e is FsxFile file)
                        return string.Equals(file.Name, selItem.Text);

                    return false;
                });

                // If the file/dir doesn't exist in the cwd, then it's probably a race condition. Don't try to
                // download it.
                if (entry == null)
                    continue;
                
                if (entry is FsxFile file)
                {
                    var path = Utils.fsxJoinAndResolvePath(cwd, file.Name);
                    filePaths.Add(path);
                    fileSizes.Add(file.Size);
                    Debug.WriteLine("Added file to queue: " + path);
                } else if (entry is FsxDirectory dir)
                {
                    // Get all files in that directory
                    foreach (var (subfilePath, subfileSize) in await fsx.getFileTree(Utils.fsxJoinAndResolvePath(cwd, dir.Name)))
                    {
                        var path = Utils.fsxJoinAndResolvePath(cwd, dir.Name, subfilePath);
                        filePaths.Add(path);
                        fileSizes.Add(subfileSize);
                        Debug.WriteLine("Added subfile to queue: " + path);
                    }
                }
            }

            if (filePaths.Count < 1)
            {
                MessageBox.Show("There are no items to be downloaded.", "Can't download", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create downloads folder if it doesn't exist.
            var targetFolder = Properties.Settings.Default.DownloadsFolder;
            Directory.CreateDirectory(targetFolder);

            var downloadDialog = new DownloadDialog(this, fsx, listView1.SmallImageList, filePaths.ToArray(), fileSizes.ToArray(), cwd, targetFolder);
            downloadDialog.Show();
            downloadDialog.FormClosed += (s, e) => downloadDialog.Dispose();
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            List<string> fileNames = new List<string>();
            List<string> fsxTargetPaths = new List<string>();

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                FileAttributes attr = File.GetAttributes(file);

                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    // Is a directory
                    var baseDir = Path.GetDirectoryName(file);
                    foreach (string subFile in Utils.EnumerateFilesRecursive(file))
                    {
                        var fsxPath = Utils.fsxJoinAndResolvePath(cwd, Path.GetRelativePath(baseDir, subFile).Replace('\\', '/'));
                        fileNames.Add(subFile);
                        fsxTargetPaths.Add(fsxPath);
                    }
                }
                else
                {
                    // Is a file
                    var fsxPath = Utils.fsxJoinAndResolvePath(cwd, Path.GetFileName(file));
                    fileNames.Add(file);
                    fsxTargetPaths.Add(fsxPath);
                }
            }

            if (fileNames.Count > 0)
            {
                uploadFiles(fileNames.ToArray(), fsxTargetPaths.ToArray());
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            fsx.CloseProcess();

            // Remove systray icon
            sysTrayIcon.Dispose();
        }

        // Do "paste" clipboard operation
        private async void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clipboardFiles.Count < 1 || clipboardOperation == ClipboardOperation.None)
                return;

            if (clipboardOperation == ClipboardOperation.Copy)
            {
                foreach (var sourcePath in clipboardFiles)
                {
                    var targetPath = Utils.fsxJoinAndResolvePath(cwd, Path.GetFileName(sourcePath));
                    await fsx.cp(sourcePath, targetPath);
                }
            } else if (clipboardOperation == ClipboardOperation.Cut)
            {
                foreach (var sourcePath in clipboardFiles)
                {
                    var targetPath = Utils.fsxJoinAndResolvePath(cwd, Path.GetFileName(sourcePath));
                    await fsx.mv(sourcePath, targetPath);
                }
            }

            clipboardOperation = ClipboardOperation.None;
            clipboardFiles.Clear();
            Debug.WriteLine("Paste");

            openFolder(cwd);
            await reloadTreeView();
        }

        // Do "cut" clipboard operation
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1 || listViewSelectionHasText(".."))
                return;

            clipboardFiles.Clear();

            foreach (ListViewItem selectedItem in listView1.SelectedItems)
            {
                var itemPath = Utils.fsxJoinAndResolvePath(cwd, selectedItem.Text);
                clipboardFiles.Add(itemPath);

                // Change item color
                selectedItem.ForeColor = Color.Gray;
            }

            clipboardOperation = ClipboardOperation.Cut;
            Debug.WriteLine("Cut");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1 || listViewSelectionHasText(".."))
                return;

            clipboardFiles.Clear();

            foreach (ListViewItem selectedItem in listView1.SelectedItems)
            {
                var itemPath = Utils.fsxJoinAndResolvePath(cwd, selectedItem.Text);
                clipboardFiles.Add(itemPath);
            }

            clipboardOperation = ClipboardOperation.Copy;
            Debug.WriteLine("Copy");
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            // CTRL- handling
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        Debug.WriteLine("Ctrl-C");
                        copyToolStripMenuItem.PerformClick();
                        break;
                    case Keys.X:
                        Debug.WriteLine("Ctrl-X");
                        cutToolStripMenuItem.PerformClick();
                        break;
                    case Keys.V:
                        Debug.WriteLine("Ctrl-V");
                        pasteToolStripMenuItem.PerformClick();
                        break;
                    case Keys.S:
                        Debug.WriteLine("Ctrl-S");
                        saveFilesystemToolStripMenuItem.PerformClick();
                        break;
                    case Keys.A:
                        Debug.WriteLine("Ctrl-A");
                        if (listView1.Focused)
                            foreach (ListViewItem i in listView1.Items)
                                i.Selected = true;
                        break;
                }
            } else if (e.Modifiers == (Keys.Control | Keys.Shift)) {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        Debug.WriteLine("Ctrl-Shift-N");
                        newDirectoryToolStripMenuItem.PerformClick();
                        break;
                }
            } else if (e.Modifiers == Keys.None)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2:
                        if (listView1.Focused) {
                            renameListViewContextMenu.PerformClick();
                        } else if (treeView1.Focused)
                        {
                            renameFolderToolStripMenuItem.PerformClick();
                        }
                        Debug.WriteLine("F2");
                        break;
                    case Keys.F5:
                        openFolder(cwd);
                        reloadTreeView();
                        Debug.WriteLine("F5");
                        break;
                    case Keys.Delete:
                        if (listView1.Focused)
                        {
                            deleteToolStripMenuItem.PerformClick();
                        }
                        Debug.WriteLine("Delete");
                        break;
                }
            }

        }

        private void listView1_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            _nameBeforeRenaming = listView1.Items[e.Item].Text;
            if (_nameBeforeRenaming == "..") e.CancelEdit = true;
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            openFolder(cwd);
            reloadTreeView();
        }

        public void setViewMode(View view)
        {
            detailsToolStripMenuItem.Checked = view == View.Details;
            listToolStripMenuItem.Checked = view == View.List;
            tileToolStripMenuItem.Checked = view == View.Tile;
            largeIconsToolStripMenuItem.Checked = view == View.LargeIcon;
            smallIconsToolStripMenuItem.Checked = view == View.SmallIcon;
            listView1.View = view;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setViewMode(View.Details);
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setViewMode(View.List);
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setViewMode(View.Tile);
        }

        private void largeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setViewMode(View.LargeIcon);
        }

        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setViewMode(View.SmallIcon);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsDialog = new SettingsDialog();

            settingsDialog.button1.Enabled = true;

            var dialogResult = settingsDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                var msgBoxResult = MessageBox.Show("To apply your changes, the application must be restarted. Restart now?", "Restart required", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgBoxResult == DialogResult.Yes)
                {
                    Application.Restart();
                    Environment.Exit(0);
                }
            }

            settingsDialog.Dispose();
        }

        private void uploadFilesHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFilePickerAndUploadToCwd();
        }

        private void filesystemPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fileSystemProperties = new FileSystemPropertiesDialog(fsx))
            {
                fileSystemProperties.ShowDialog();
            }
        }

        private void sidePaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !sidePaneToolStripMenuItem.Checked;
        }

        private bool Resizing = false;
        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            // Don't allow overlapping of SizeChanged calls
            if (!Resizing)
            {
                // Set the resizing flag
                Resizing = true;

                ListView listView = listView1;
                listView.BeginUpdate();
                if (listView != null)
                {
                    float totalColumnWidth = 0;

                    // Get the sum of all column tags
                    for (int i = 0; i < listView.Columns.Count; i++)
                        totalColumnWidth += Convert.ToInt32(listView.Columns[i].Tag);

                    // Calculate the percentage of space each column should 
                    // occupy in reference to the other columns and then set the 
                    // width of the column to that percentage of the visible space.
                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
                        listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                    }
                }
                listView1.EndUpdate();
            }

            // Clear the resizing flag
            Resizing = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var aboutBox = new AboutBox1())
            {
                aboutBox.ShowDialog();
            }
        }

        private void showCurrentFolderPathOnStatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cwdStatusStrip.Visible = showCurrentFolderPathOnStatusBarToolStripMenuItem.Checked;
        }

        private void sysTrayIcon_Click(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}