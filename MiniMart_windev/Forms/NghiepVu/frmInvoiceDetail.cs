using System;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class frmInvoiceDetail : Form
    {
        public frmInvoiceDetail()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmInvoiceDetail";
            this.Text = "frmInvoiceDetail";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}
