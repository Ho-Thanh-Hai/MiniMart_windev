using System;
using System.Windows.Forms;

namespace MiniMart_windev.Forms.HeThong
{
    public partial class frmConnectionConfig : Form
    {
        public frmConnectionConfig()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmConnectionConfig";
            this.Text = "frmConnectionConfig";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}
