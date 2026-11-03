using System;
using System.Windows.Forms;

namespace MiniMart_windev.Forms.HeThong
{
    public partial class frmRoleManagement : Form
    {
        public frmRoleManagement()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmRoleManagement";
            this.Text = "frmRoleManagement";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}
