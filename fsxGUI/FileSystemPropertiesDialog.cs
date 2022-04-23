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
    public partial class FileSystemPropertiesDialog : Form
    {
        private LibFsxBridge Fsx;

        public FileSystemPropertiesDialog(LibFsxBridge fsx)
        {
            InitializeComponent();

            Fsx = fsx;
        }

        private async Task LoadAllProperties()
        {
            listView1.Items.Clear();

            var headers = await Fsx.getHeaders();

            foreach (var header in headers)
            {
                var item = new ListViewItem(new string[] { header.Key, header.Value });
                listView1.Items.Add(item);    
            }
        }

        private async Task SetProperty(string key, string value)
        {
            await Fsx.setHeader(key, value);
            await LoadAllProperties();
        }

        private void FileSystemPropertiesDialog_Load(object sender, EventArgs e)
        {
            // Put it offscreen
            ValueEditTextbox.Location = new Point(9999, 9999);

            LoadAllProperties();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = listView1.SelectedItems[0];

            if (selectedItem == null) return;

            var valueSubitemBounds = selectedItem.SubItems[1].Bounds;
            ValueEditTextbox.Parent = listView1;
            ValueEditTextbox.Location = new Point(valueSubitemBounds.X, valueSubitemBounds.Y - 2);
            ValueEditTextbox.Width = valueSubitemBounds.Width;
            ValueEditTextbox.Height = valueSubitemBounds.Height;
            ValueEditTextbox.Text = selectedItem.SubItems[1].Text;
            ValueEditTextbox.Focus();
        }

        private async void ValueEditTextbox_Validating(object sender, CancelEventArgs e)
        {
            Debug.WriteLine($"Set key {listView1.SelectedItems[0].Text} to {ValueEditTextbox.Text}");
            await SetProperty(listView1.SelectedItems[0].Text, ValueEditTextbox.Text.Trim());
            ValueEditTextbox.Location = new Point(9999, 9999);
        }

        private void ValueEditTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                listView1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
