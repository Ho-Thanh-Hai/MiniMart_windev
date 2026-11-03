using System;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class frmStockReceiptDetail : Form
    {
        public frmStockReceiptDetail()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmStockReceiptDetail";
            this.Text = "frmStockReceiptDetail";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}
