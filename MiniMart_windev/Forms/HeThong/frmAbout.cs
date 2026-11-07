using System;
using System.Drawing;
using System.Windows.Forms;
using MiniMart_windev.Helpers;

namespace MiniMart_windev.Forms.HeThong
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyTheme(this);
            btnTheme.Text = ThemeHelper.IsDarkMode ? "Light Mode" : "Dark Mode";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            ThemeHelper.ToggleTheme();
            ThemeHelper.ApplyTheme(this);
            btnTheme.Text = ThemeHelper.IsDarkMode ? "Light Mode" : "Dark Mode";
        }
    }
}
