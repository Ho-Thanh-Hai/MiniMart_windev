using System;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class frmCategoryManagement : Form
    {
        public frmCategoryManagement()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmCategoryManagement";
            this.Text = "frmCategoryManagement";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}
