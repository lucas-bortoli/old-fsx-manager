namespace fsxGUI
{
    partial class FileSystemPropertiesDialog
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.listViewColumn1 = new System.Windows.Forms.ColumnHeader();
            this.listViewColumn2 = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ValueEditTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewColumn1,
            this.listViewColumn2});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 27);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(374, 149);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // listViewColumn1
            // 
            this.listViewColumn1.Text = "Key";
            this.listViewColumn1.Width = 155;
            // 
            // listViewColumn2
            // 
            this.listViewColumn2.Text = "Value";
            this.listViewColumn2.Width = 215;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "You can edit the filesystem properties in this window.";
            // 
            // ValueEditTextbox
            // 
            this.ValueEditTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ValueEditTextbox.Location = new System.Drawing.Point(170, 54);
            this.ValueEditTextbox.Name = "ValueEditTextbox";
            this.ValueEditTextbox.Size = new System.Drawing.Size(206, 23);
            this.ValueEditTextbox.TabIndex = 3;
            this.ValueEditTextbox.TabStop = false;
            this.ValueEditTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ValueEditTextbox_KeyDown);
            this.ValueEditTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.ValueEditTextbox_Validating);
            // 
            // FileSystemPropertiesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(398, 211);
            this.Controls.Add(this.ValueEditTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileSystemPropertiesDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filesystem properties";
            this.Load += new System.EventHandler(this.FileSystemPropertiesDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView listView1;
        private ColumnHeader listViewColumn1;
        private ColumnHeader listViewColumn2;
        private Button button1;
        private Label label1;
        private TextBox ValueEditTextbox;
    }
}