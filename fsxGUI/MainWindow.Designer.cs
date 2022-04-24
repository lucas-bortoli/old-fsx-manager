namespace fsxGUI
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileIconsSmall = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.fileListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadFilesHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.shareSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.newDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameListViewContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileIconsLarge = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilesystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sidePaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCurrentFolderPathOnStatusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesystemPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusItemCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cwdStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPadding = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.uploadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sysTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.treeViewContextMenu.SuspendLayout();
            this.fileListContextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(12, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(767, 372);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.ContextMenuStrip = this.treeViewContextMenu;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.FileIconsSmall;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.PathSeparator = "/";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(252, 372);
            this.treeView1.TabIndex = 1;
            this.treeView1.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_BeforeLabelEdit);
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // treeViewContextMenu
            // 
            this.treeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFolderToolStripMenuItem,
            this.renameFolderToolStripMenuItem});
            this.treeViewContextMenu.Name = "treeViewContextMenu";
            this.treeViewContextMenu.Size = new System.Drawing.Size(202, 48);
            this.treeViewContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.treeViewContextMenu_Opening);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newFolderToolStripMenuItem.Image")));
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl-Shift-N";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.newFolderToolStripMenuItem.Text = "New folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // renameFolderToolStripMenuItem
            // 
            this.renameFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renameFolderToolStripMenuItem.Image")));
            this.renameFolderToolStripMenuItem.Name = "renameFolderToolStripMenuItem";
            this.renameFolderToolStripMenuItem.ShortcutKeyDisplayString = "F2";
            this.renameFolderToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.renameFolderToolStripMenuItem.Text = "Rename folder";
            this.renameFolderToolStripMenuItem.Click += new System.EventHandler(this.renameFolderToolStripMenuItem_Click);
            // 
            // FileIconsSmall
            // 
            this.FileIconsSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.FileIconsSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FileIconsSmall.ImageStream")));
            this.FileIconsSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.FileIconsSmall.Images.SetKeyName(0, "<folder>");
            this.FileIconsSmall.Images.SetKeyName(1, "driveIcon");
            this.FileIconsSmall.Images.SetKeyName(2, "<folderOpened>");
            this.FileIconsSmall.Images.SetKeyName(3, "<folderClosed>");
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.AllowDrop = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.ContextMenuStrip = this.fileListContextMenu;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.LabelEdit = true;
            this.listView1.LargeImageList = this.FileIconsLarge;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(511, 372);
            this.listView1.SmallImageList = this.FileIconsSmall;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_AfterLabelEdit);
            this.listView1.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_BeforeLabelEdit);
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.SizeChanged += new System.EventHandler(this.listView1_SizeChanged);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "4";
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 246;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "1";
            this.columnHeader2.Text = "Size";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "2";
            this.columnHeader3.Text = "Creation date";
            this.columnHeader3.Width = 123;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "1";
            this.columnHeader4.Text = "Type";
            // 
            // fileListContextMenu
            // 
            this.fileListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.uploadFilesHereToolStripMenuItem,
            this.toolStripMenuItem1,
            this.shareSelectedFilesToolStripMenuItem,
            this.toolStripMenuItem3,
            this.newDirectoryToolStripMenuItem,
            this.renameListViewContextMenu,
            this.deleteToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.fileListContextMenu.Name = "fileListContextMenuStrip";
            this.fileListContextMenu.Size = new System.Drawing.Size(202, 214);
            this.fileListContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.fileListContextMenu_Opening);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("downloadToolStripMenuItem.Image")));
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.downloadToolStripMenuItem.Text = "Download selected files";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // uploadFilesHereToolStripMenuItem
            // 
            this.uploadFilesHereToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uploadFilesHereToolStripMenuItem.Image")));
            this.uploadFilesHereToolStripMenuItem.Name = "uploadFilesHereToolStripMenuItem";
            this.uploadFilesHereToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.uploadFilesHereToolStripMenuItem.Text = "Upload files here";
            this.uploadFilesHereToolStripMenuItem.Click += new System.EventHandler(this.uploadFilesHereToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 6);
            // 
            // shareSelectedFilesToolStripMenuItem
            // 
            this.shareSelectedFilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("shareSelectedFilesToolStripMenuItem.Image")));
            this.shareSelectedFilesToolStripMenuItem.Name = "shareSelectedFilesToolStripMenuItem";
            this.shareSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.shareSelectedFilesToolStripMenuItem.Text = "Share selected files";
            this.shareSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.shareSelectedFilesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(198, 6);
            // 
            // newDirectoryToolStripMenuItem
            // 
            this.newDirectoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newDirectoryToolStripMenuItem.Image")));
            this.newDirectoryToolStripMenuItem.Name = "newDirectoryToolStripMenuItem";
            this.newDirectoryToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl-Shift-N";
            this.newDirectoryToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.newDirectoryToolStripMenuItem.Text = "New folder";
            this.newDirectoryToolStripMenuItem.Click += new System.EventHandler(this.newDirectoryToolStripMenuItem_Click);
            // 
            // renameListViewContextMenu
            // 
            this.renameListViewContextMenu.Image = ((System.Drawing.Image)(resources.GetObject("renameListViewContextMenu.Image")));
            this.renameListViewContextMenu.Name = "renameListViewContextMenu";
            this.renameListViewContextMenu.ShortcutKeyDisplayString = "F2";
            this.renameListViewContextMenu.Size = new System.Drawing.Size(201, 22);
            this.renameListViewContextMenu.Text = "Rename";
            this.renameListViewContextMenu.Click += new System.EventHandler(this.renameListViewContextMenu_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeyDisplayString = "Delete";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl-C";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl-X";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl-V";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // FileIconsLarge
            // 
            this.FileIconsLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.FileIconsLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FileIconsLarge.ImageStream")));
            this.FileIconsLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.FileIconsLarge.Images.SetKeyName(0, "<folder>");
            this.FileIconsLarge.Images.SetKeyName(1, "driveIcon");
            this.FileIconsLarge.Images.SetKeyName(2, "<folderOpened>");
            this.FileIconsLarge.Images.SetKeyName(3, "<folderClosed>");
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(791, 32);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFilesystemToolStripMenuItem,
            this.exportAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeyDisplayString = "F";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 28);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveFilesystemToolStripMenuItem
            // 
            this.saveFilesystemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveFilesystemToolStripMenuItem.Image")));
            this.saveFilesystemToolStripMenuItem.Name = "saveFilesystemToolStripMenuItem";
            this.saveFilesystemToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl-S";
            this.saveFilesystemToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveFilesystemToolStripMenuItem.Text = "Save filesystem";
            this.saveFilesystemToolStripMenuItem.Click += new System.EventHandler(this.saveFilesystemToolStripMenuItem_Click);
            // 
            // exportAsToolStripMenuItem
            // 
            this.exportAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cSVToolStripMenuItem,
            this.jSONToolStripMenuItem});
            this.exportAsToolStripMenuItem.Enabled = false;
            this.exportAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportAsToolStripMenuItem.Image")));
            this.exportAsToolStripMenuItem.Name = "exportAsToolStripMenuItem";
            this.exportAsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exportAsToolStripMenuItem.Text = "Export data file as...";
            // 
            // cSVToolStripMenuItem
            // 
            this.cSVToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cSVToolStripMenuItem.Image")));
            this.cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
            this.cSVToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cSVToolStripMenuItem.Text = "CSV";
            // 
            // jSONToolStripMenuItem
            // 
            this.jSONToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("jSONToolStripMenuItem.Image")));
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.jSONToolStripMenuItem.Text = "JSON";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDirectoryToolStripMenuItem,
            this.uploadFilesToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 28);
            this.actionsToolStripMenuItem.Text = "&Actions";
            // 
            // createDirectoryToolStripMenuItem
            // 
            this.createDirectoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createDirectoryToolStripMenuItem.Image")));
            this.createDirectoryToolStripMenuItem.Name = "createDirectoryToolStripMenuItem";
            this.createDirectoryToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl-Shift-N";
            this.createDirectoryToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.createDirectoryToolStripMenuItem.Text = "New folder";
            this.createDirectoryToolStripMenuItem.Click += new System.EventHandler(this.createDirectoryToolStripMenuItem_Click);
            // 
            // uploadFilesToolStripMenuItem
            // 
            this.uploadFilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uploadFilesToolStripMenuItem.Image")));
            this.uploadFilesToolStripMenuItem.Name = "uploadFilesToolStripMenuItem";
            this.uploadFilesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.uploadFilesToolStripMenuItem.Text = "Upload files";
            this.uploadFilesToolStripMenuItem.Click += new System.EventHandler(this.uploadFilesToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.listToolStripMenuItem,
            this.tileToolStripMenuItem,
            this.largeIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.sidePaneToolStripMenuItem,
            this.showCurrentFolderPathOnStatusBarToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.viewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 28);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Checked = true;
            this.detailsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // tileToolStripMenuItem
            // 
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.tileToolStripMenuItem.Text = "Tile";
            this.tileToolStripMenuItem.Click += new System.EventHandler(this.tileToolStripMenuItem_Click);
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.largeIconsToolStripMenuItem.Text = "Large icons";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.largeIconsToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.smallIconsToolStripMenuItem.Text = "Small icons";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.smallIconsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(273, 6);
            // 
            // sidePaneToolStripMenuItem
            // 
            this.sidePaneToolStripMenuItem.Checked = true;
            this.sidePaneToolStripMenuItem.CheckOnClick = true;
            this.sidePaneToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sidePaneToolStripMenuItem.Name = "sidePaneToolStripMenuItem";
            this.sidePaneToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.sidePaneToolStripMenuItem.Text = "Side pane";
            this.sidePaneToolStripMenuItem.Click += new System.EventHandler(this.sidePaneToolStripMenuItem_Click);
            // 
            // showCurrentFolderPathOnStatusBarToolStripMenuItem
            // 
            this.showCurrentFolderPathOnStatusBarToolStripMenuItem.CheckOnClick = true;
            this.showCurrentFolderPathOnStatusBarToolStripMenuItem.Name = "showCurrentFolderPathOnStatusBarToolStripMenuItem";
            this.showCurrentFolderPathOnStatusBarToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.showCurrentFolderPathOnStatusBarToolStripMenuItem.Text = "Show current folder path on status bar";
            this.showCurrentFolderPathOnStatusBarToolStripMenuItem.Click += new System.EventHandler(this.showCurrentFolderPathOnStatusBarToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesystemPropertiesToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 28);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // filesystemPropertiesToolStripMenuItem
            // 
            this.filesystemPropertiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filesystemPropertiesToolStripMenuItem.Image")));
            this.filesystemPropertiesToolStripMenuItem.Name = "filesystemPropertiesToolStripMenuItem";
            this.filesystemPropertiesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.filesystemPropertiesToolStripMenuItem.Text = "Filesystem properties";
            this.filesystemPropertiesToolStripMenuItem.Click += new System.EventHandler(this.filesystemPropertiesToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsToolStripMenuItem.Image")));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.aboutToolStripMenuItem.Text = "About FSX Manager";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusItemCount,
            this.toolStripStatusLabel1,
            this.cwdStatusStrip,
            this.statusPadding,
            this.toolStripSplitButton1,
            this.toolStripSplitButton2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(791, 32);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusItemCount
            // 
            this.statusItemCount.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.statusItemCount.Name = "statusItemCount";
            this.statusItemCount.Size = new System.Drawing.Size(45, 27);
            this.statusItemCount.Text = "0 items";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(293, 27);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // cwdStatusStrip
            // 
            this.cwdStatusStrip.Name = "cwdStatusStrip";
            this.cwdStatusStrip.Size = new System.Drawing.Size(12, 27);
            this.cwdStatusStrip.Text = "/";
            this.cwdStatusStrip.Visible = false;
            // 
            // statusPadding
            // 
            this.statusPadding.Name = "statusPadding";
            this.statusPadding.Size = new System.Drawing.Size(293, 27);
            this.statusPadding.Spring = true;
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.AutoToolTip = false;
            this.toolStripSplitButton1.DropDownButtonWidth = 0;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Padding = new System.Windows.Forms.Padding(4);
            this.toolStripSplitButton1.Size = new System.Drawing.Size(57, 30);
            this.toolStripSplitButton1.Text = "  Up";
            this.toolStripSplitButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripSplitButton1.ToolTipText = "Go to parent folder\r\n";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.AutoToolTip = false;
            this.toolStripSplitButton2.DropDownButtonWidth = 0;
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Margin = new System.Windows.Forms.Padding(0, 2, -3, 0);
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Padding = new System.Windows.Forms.Padding(4);
            this.toolStripSplitButton2.Size = new System.Drawing.Size(81, 30);
            this.toolStripSplitButton2.Text = "  Refresh";
            this.toolStripSplitButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripSplitButton2.ToolTipText = "Refresh listing";
            this.toolStripSplitButton2.ButtonClick += new System.EventHandler(this.toolStripSplitButton2_ButtonClick);
            // 
            // uploadFileDialog
            // 
            this.uploadFileDialog.FileName = "openFileDialog1";
            this.uploadFileDialog.Filter = "All files (*.*)|*.*";
            this.uploadFileDialog.Multiselect = true;
            this.uploadFileDialog.Title = "Upload files...";
            // 
            // sysTrayIcon
            // 
            this.sysTrayIcon.Text = "FSX Manager";
            this.sysTrayIcon.Visible = true;
            this.sysTrayIcon.Click += new System.EventHandler(this.sysTrayIcon_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(791, 442);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FSX Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.treeViewContextMenu.ResumeLayout(false);
            this.fileListContextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private ListView listView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveFilesystemToolStripMenuItem;
        private ToolStripMenuItem exportAsToolStripMenuItem;
        private ToolStripMenuItem cSVToolStripMenuItem;
        private ToolStripMenuItem jSONToolStripMenuItem;
        private ToolStripMenuItem actionsToolStripMenuItem;
        private ToolStripMenuItem uploadFilesToolStripMenuItem;
        private ToolStripMenuItem createDirectoryToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusItemCount;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ImageList FileIconsSmall;
        private ContextMenuStrip fileListContextMenu;
        private ToolStripMenuItem renameListViewContextMenu;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem newDirectoryToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private OpenFileDialog uploadFileDialog;
        private ToolStripStatusLabel cwdStatusStrip;
        private ToolStripSplitButton toolStripSplitButton1;
        private ContextMenuStrip treeViewContextMenu;
        private ToolStripMenuItem newFolderToolStripMenuItem;
        private ToolStripMenuItem renameFolderToolStripMenuItem;
        private ToolStripStatusLabel statusPadding;
        private ToolStripMenuItem downloadToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ImageList FileIconsLarge;
        private ToolStripSplitButton toolStripSplitButton2;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem detailsToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem;
        private ToolStripMenuItem tileToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem uploadFilesHereToolStripMenuItem;
        private ToolStripMenuItem filesystemPropertiesToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem sidePaneToolStripMenuItem;
        private ToolStripMenuItem largeIconsToolStripMenuItem;
        private ToolStripMenuItem smallIconsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem showCurrentFolderPathOnStatusBarToolStripMenuItem;
        public NotifyIcon sysTrayIcon;
        private ToolStripMenuItem shareSelectedFilesToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
    }
}