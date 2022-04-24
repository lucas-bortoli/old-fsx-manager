﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fsxGUI
{
    public partial class ShareDialog : Form
    {
        public LibFsxBridge Fsx;
        public string[] FilePaths;
        public long[] FileSizes;
        public ImageList IconList;
        public string Cwd;

        public ShareDialog(LibFsxBridge fsx, ImageList iconList, string[] filePaths, long[] fileSizes, string cwd)
        {
            InitializeComponent();

            Fsx = fsx;
            FilePaths = filePaths;
            FileSizes = fileSizes;
            IconList = iconList;
            Cwd = cwd;

            listView1.SmallImageList = IconList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool _resizing = false;
        private void listView1_Resize(object sender, EventArgs e)
        {
            if (!_resizing)
            {
                _resizing = true;

                listView1.BeginUpdate();
                listView1.Columns[0].Width = listView1.Width - listView1.Columns[1].Width - 22;
                listView1.EndUpdate();
            }

            _resizing = false;
        }

        private void ShareDialog_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < FilePaths.Length; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.SubItems[0].Text = FilePaths[i];
                lvi.SubItems.Add(Utils.GetBytesReadable(FileSizes[i]));
                lvi.ImageKey = Path.GetExtension(FilePaths[i]);

                listView1.Items.Add(lvi);
            }

            listView1_Resize(null, null);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("The file name must not be empty.", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            if (!Utils.isValidName(textBox1.Text))
            {
                MessageBox.Show("The file name cannot contain any of the following characters:\n" + string.Join(' ', Utils.FORBIDDEN_NAME_CHARACTERS), "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            // Add extension if there's none
            if (string.IsNullOrWhiteSpace(Path.GetExtension(textBox1.Text)))
            {
                if (FilePaths.Length == 1)
                {
                    textBox1.Text += Path.GetExtension(FilePaths[0]);
                } else {
                    textBox1.Text += ".zip";
                }
            }

            var finalUrl = await Fsx.shareFiles(textBox1.Text, textBox2.Text, FilePaths, Cwd);
            
            using (var s = new ShareDialogPopup(Properties.Settings.Default.FileSharingServer + finalUrl))
            {
                s.ShowDialog();
            }

            DialogResult = DialogResult.OK;
        }
    }
}
