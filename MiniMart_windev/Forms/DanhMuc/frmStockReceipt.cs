using System;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class frmStockReceipt : Form
    {
        public frmStockReceipt()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmStockReceipt";
            this.Text = "frmStockReceipt";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}
