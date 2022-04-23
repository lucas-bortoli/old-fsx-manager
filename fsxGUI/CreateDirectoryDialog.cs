using System;
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
    public partial class CreateDirectoryDialog : Form
    {
        public CreateDirectoryDialog()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                this.InputTextBox.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            if (!Utils.isValidName(InputTextBox.Text))
            {
                MessageBox.Show("A file or folder name cannot contain any of the following characters:\n" + string.Join(' ', Utils.FORBIDDEN_NAME_CHARACTERS), "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.InputTextBox.Focus();
                this.DialogResult = DialogResult.None;
                this.InputTextBox.Text = "";
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void CreateDirectoryDialog_Load(object sender, EventArgs e)
        {
            this.ActiveControl = InputTextBox;
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        public string getResults()
        {
            return InputTextBox.Text;
        }
    }
}
