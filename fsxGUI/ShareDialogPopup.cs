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
    public partial class ShareDialogPopup : Form
    {
        public readonly string ShareLink;
        public ShareDialogPopup(string shareLink)
        {
            InitializeComponent();
            ShareLink = shareLink;
        }

        private string generateQRCodeLink(string link)
        {
            return "https://api.qrserver.com/v1/create-qr-code/?size=128x128&data=" + Uri.EscapeDataString(link);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ShareLink);
        }

        private void ShareDialogPopup_Load(object sender, EventArgs e)
        {
            pictureBox1.Load(generateQRCodeLink(ShareLink));
            textBox1.Text = ShareLink;
        }
    }
}
