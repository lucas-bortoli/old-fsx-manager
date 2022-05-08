namespace fsxGUI
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.webhookStatus = new System.Windows.Forms.Label();
            this.testWebhookButton = new System.Windows.Forms.Button();
            this.webhookTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.enableFileSharing = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fileSharingServer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataFileChooser = new System.Windows.Forms.OpenFileDialog();
            this.downloadsFolderChooser = new System.Windows.Forms.FolderBrowserDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.exportSettingsFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.importSettingsFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.enablePushNotifications = new System.Windows.Forms.CheckBox();
            this.pushNotificationsTopic = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(385, 418);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(377, 390);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.webhookStatus);
            this.groupBox4.Controls.Add(this.testWebhookButton);
            this.groupBox4.Controls.Add(this.webhookTextbox);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(6, 169);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(365, 111);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Discord webhook";
            // 
            // webhookStatus
            // 
            this.webhookStatus.AutoSize = true;
            this.webhookStatus.Location = new System.Drawing.Point(6, 85);
            this.webhookStatus.Name = "webhookStatus";
            this.webhookStatus.Size = new System.Drawing.Size(0, 15);
            this.webhookStatus.TabIndex = 4;
            // 
            // testWebhookButton
            // 
            this.testWebhookButton.Location = new System.Drawing.Point(263, 81);
            this.testWebhookButton.Name = "testWebhookButton";
            this.testWebhookButton.Size = new System.Drawing.Size(96, 23);
            this.testWebhookButton.TabIndex = 2;
            this.testWebhookButton.Text = "Test webhook";
            this.testWebhookButton.UseVisualStyleBackColor = true;
            this.testWebhookButton.Click += new System.EventHandler(this.testWebhookButton_Click);
            // 
            // webhookTextbox
            // 
            this.webhookTextbox.Location = new System.Drawing.Point(6, 52);
            this.webhookTextbox.Name = "webhookTextbox";
            this.webhookTextbox.Size = new System.Drawing.Size(353, 23);
            this.webhookTextbox.TabIndex = 1;
            this.webhookTextbox.TextChanged += new System.EventHandler(this.webhookTextbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(336, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "All files will be split into 7.8 MB segments and uploaded to this\r\nwebhook. Use t" +
    "he button to determine if it is working.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 71);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data file";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(315, 23);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "File/folder entries will be stored in this file:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HTTP server";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(344, 19);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Listen on `localhost` instead of all interfaces (recommended)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(263, 23);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(96, 23);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            38639,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start internal server on port";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(377, 390);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Downloads and uploads";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pictureBox2);
            this.groupBox6.Controls.Add(this.enableFileSharing);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.fileSharingServer);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Location = new System.Drawing.Point(6, 82);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(365, 124);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "File sharing";
            // 
            // enableFileSharing
            // 
            this.enableFileSharing.AutoSize = true;
            this.enableFileSharing.Location = new System.Drawing.Point(28, 21);
            this.enableFileSharing.Name = "enableFileSharing";
            this.enableFileSharing.Size = new System.Drawing.Size(122, 19);
            this.enableFileSharing.TabIndex = 6;
            this.enableFileSharing.Text = "Enable file sharing";
            this.enableFileSharing.UseVisualStyleBackColor = true;
            this.enableFileSharing.CheckedChanged += new System.EventHandler(this.enableFileSharing_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(347, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "File IDs are added to the end of the server link when sharing files.";
            // 
            // fileSharingServer
            // 
            this.fileSharingServer.Location = new System.Drawing.Point(6, 77);
            this.fileSharingServer.Name = "fileSharingServer";
            this.fileSharingServer.PlaceholderText = "file share server (e.g. ***.glitch.me)";
            this.fileSharingServer.Size = new System.Drawing.Size(353, 23);
            this.fileSharingServer.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(352, 30);
            this.label7.TabIndex = 0;
            this.label7.Text = "Files shared with the \"share files\" function can be downloaded via\r\nthe following" +
    " server link:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(365, 70);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Downloads location";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(327, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(315, 23);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Downloaded files will be stored in this folder:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(377, 390);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Import/export settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(365, 111);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Export settings to a file";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(263, 52);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 23);
            this.button7.TabIndex = 4;
            this.button7.Text = "Import settings";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(263, 81);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Export settings";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(353, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "You can export your settings to a file, for an easy transfer between\r\ncomputers.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(241, 439);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataFileChooser
            // 
            this.dataFileChooser.CheckFileExists = false;
            this.dataFileChooser.Filter = "Data files|*.dat|All files|*.*";
            this.dataFileChooser.RestoreDirectory = true;
            this.dataFileChooser.Title = "Data file";
            // 
            // downloadsFolderChooser
            // 
            this.downloadsFolderChooser.Description = "Choose downloads folder";
            this.downloadsFolderChooser.UseDescriptionForTitle = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(16, 439);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Reset";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // exportSettingsFileDialog
            // 
            this.exportSettingsFileDialog.Filter = "Exported settings|*.ini";
            this.exportSettingsFileDialog.Title = "Export settings to file...";
            // 
            // importSettingsFileDialog
            // 
            this.importSettingsFileDialog.Filter = "Exported settings|*.ini";
            this.importSettingsFileDialog.Title = "Import settings from a file";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.pictureBox1);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.pushNotificationsTopic);
            this.groupBox7.Controls.Add(this.enablePushNotifications);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Location = new System.Drawing.Point(6, 212);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(365, 172);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Phone push notifications";
            // 
            // enablePushNotifications
            // 
            this.enablePushNotifications.AutoSize = true;
            this.enablePushNotifications.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.enablePushNotifications.Location = new System.Drawing.Point(28, 21);
            this.enablePushNotifications.Name = "enablePushNotifications";
            this.enablePushNotifications.Size = new System.Drawing.Size(196, 19);
            this.enablePushNotifications.TabIndex = 7;
            this.enablePushNotifications.Text = "Enable phone push notifications";
            this.enablePushNotifications.UseVisualStyleBackColor = true;
            this.enablePushNotifications.CheckedChanged += new System.EventHandler(this.enablePushNotifications_CheckedChanged);
            // 
            // pushNotificationsTopic
            // 
            this.pushNotificationsTopic.Location = new System.Drawing.Point(6, 122);
            this.pushNotificationsTopic.Name = "pushNotificationsTopic";
            this.pushNotificationsTopic.PlaceholderText = "ntfy.sh topic. this should be kept private";
            this.pushNotificationsTopic.Size = new System.Drawing.Size(353, 23);
            this.pushNotificationsTopic.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(351, 75);
            this.label8.TabIndex = 7;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(303, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Make sure to subscribe to the same topic in your phone.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.button4;
            this.ClientSize = new System.Drawing.Size(409, 474);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private TabPage tabPage2;
        private CheckBox checkBox1;
        private GroupBox groupBox2;
        private Button button2;
        private TextBox textBox1;
        private Label label2;
        private GroupBox groupBox3;
        private Button button3;
        private TextBox textBox2;
        private Label label3;
        private Button button4;
        private OpenFileDialog dataFileChooser;
        private FolderBrowserDialog downloadsFolderChooser;
        private GroupBox groupBox4;
        private Label webhookStatus;
        private Button testWebhookButton;
        private TextBox webhookTextbox;
        private Label label4;
        public Button button1;
        private Button button5;
        private TabPage tabPage3;
        private GroupBox groupBox5;
        private Button button6;
        private Label label5;
        private SaveFileDialog exportSettingsFileDialog;
        private Button button7;
        private OpenFileDialog importSettingsFileDialog;
        private GroupBox groupBox6;
        private CheckBox enableFileSharing;
        private Label label6;
        private TextBox fileSharingServer;
        private Label label7;
        private GroupBox groupBox7;
        private Label label9;
        private TextBox pushNotificationsTopic;
        private CheckBox enablePushNotifications;
        private Label label8;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}