using System;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class frmSupplierManagement : Form
    {
        public frmSupplierManagement()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmSupplierManagement";
            this.Text = "frmSupplierManagement";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}
