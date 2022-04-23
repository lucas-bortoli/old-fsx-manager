using fsxGUI.Properties;
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
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
            setUIElementsValues();
        }

        private void setUIElementsValues()
        {
            var settings = Properties.Settings.Default;
            numericUpDown1.Value = settings.PortNumber;
            checkBox1.Checked = settings.ListenOnLocalhost;
            textBox1.Text = settings.DataFileLocation;
            textBox2.Text = settings.DownloadsFolder;
            webhookTextbox.Text = settings.WebhookURL;
        }

        private void SaveToFile(string targetPath)
        {
            var settings = Properties.Settings.Default;
            var file = File.OpenWrite(targetPath);

            using (var sw = new StreamWriter(file))
            {
                sw.WriteLine($"PortNumber={settings.PortNumber}");
                sw.WriteLine($"ListenOnLocalhost={settings.ListenOnLocalhost}");
                sw.WriteLine($"DataFileLocation={settings.DataFileLocation}");
                sw.WriteLine($"DownloadsFolder={settings.DownloadsFolder}");
                sw.WriteLine($"WebhookURL={settings.WebhookURL}");
                sw.Close();
            }
        }

        private void LoadFromFile(string filePath)
        {
            var settings = Properties.Settings.Default;
            var file = File.OpenRead(filePath);

            using (var sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (line == null) break;

                    int keyValueSepIndex = line.IndexOf('=');
                    string key = line.Substring(0, keyValueSepIndex);
                    string value = line.Substring(keyValueSepIndex + 1);

                    Debug.WriteLine($"Settings import: {key} = {value}");

                    switch (key)
                    {
                        case "PortNumber":
                            settings.PortNumber = Convert.ToInt32(value);
                            break;
                        case "ListenOnLocalhost":
                            settings.ListenOnLocalhost = bool.Parse(value);
                            break;
                        case "DataFileLocation":
                            settings.DataFileLocation = value;
                            break;
                        case "DownloadsFolder":
                            settings.DownloadsFolder = value;
                            break;
                        case "WebhookURL":
                            settings.WebhookURL = value;
                            break;
                    }
                }

                sr.Close();
            }

            settings.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            settings.PortNumber = (int)numericUpDown1.Value;
            settings.ListenOnLocalhost = checkBox1.Checked;
            settings.DataFileLocation = textBox1.Text;
            settings.DownloadsFolder = textBox2.Text;
            settings.WebhookURL = webhookTextbox.Text;
            settings.Save();
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dialogResult = dataFileChooser.ShowDialog();

            if (dialogResult == DialogResult.OK)
                textBox1.Text = dataFileChooser.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dialogResult = downloadsFolderChooser.ShowDialog();

            if (dialogResult == DialogResult.OK)
                textBox2.Text = downloadsFolderChooser.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private async void testWebhookButton_Click(object sender, EventArgs e)
        {
            var webhookUrl = webhookTextbox.Text;
            bool webhookWorking = false;
            
            try
            {
                webhookWorking = await LibFsxBridge.isWebhookUrlValid(webhookUrl);
            } catch (Exception)
            {
                webhookWorking = false;
                webhookStatus.Text = "An invalid webhook URL was provided.";
                webhookStatus.ForeColor = Color.Red;
                button1.Enabled = false;
                return;
            }

            if (webhookWorking)
            {
                webhookStatus.Text = "The webhook is working.";
                webhookStatus.ForeColor = Color.Black;
            } else {
                webhookStatus.Text = "The webhook is NOT working.";
                webhookStatus.ForeColor = Color.Red;
            }

            button1.Enabled = webhookWorking;
        }

        private void webhookTextbox_TextChanged(object sender, EventArgs e)
        {
            // When the text is changed, force user to test the webhook again before he can exit this dialog.
            button1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to reset all settings to their default values? This will require an application restart.", "Confirmation needed", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Properties.Settings.Default.Reset();
                MessageBox.Show("The settings have been reset to their default values. Press OK to restart the application.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (exportSettingsFileDialog.ShowDialog() == DialogResult.OK)
            
                SaveToFile(exportSettingsFileDialog.FileName);
                MessageBox.Show("The settings have been exported.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("explorer.exe", Path.GetDirectoryName(exportSettingsFileDialog.FileName));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (importSettingsFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadFromFile(importSettingsFileDialog.FileName);
                setUIElementsValues();
                MessageBox.Show("The settings have been imported. Press OK to restart the application.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
                Environment.Exit(0);
            }
        }
    }
}
