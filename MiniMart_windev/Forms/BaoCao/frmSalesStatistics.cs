using System;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class frmSalesStatistics : Form
    {
        public frmSalesStatistics()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmSalesStatistics";
            this.Text = "frmSalesStatistics";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}
