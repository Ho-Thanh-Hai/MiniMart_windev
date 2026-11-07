using System;
using System.Linq;
using System.Windows.Forms;
using MiniMart_windev.Helpers;
using MiniMart_windev.Models;

namespace MiniMart_windev.Forms.HeThong
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            lblTenDangNhapHienTai.Text = CurrentUserSession.TenDangNhap;
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            char passChar = chkHienMatKhau.Checked ? '\0' : '●';
            txtMatKhauCu.PasswordChar = passChar;
            txtMatKhauMoi.PasswordChar = passChar;
            txtXacNhanMatKhau.PasswordChar = passChar;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string oldPass = txtMatKhauCu.Text;
            string newPass = txtMatKhauMoi.Text;
            string confirmPass = txtXacNhanMatKhau.Text;

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPass.Length < 4)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 4 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    string oldPassHash = SecurityHelper.ComputeSha256Hash(oldPass);
                    var user = db.NguoiDungs.FirstOrDefault(u => u.MaNguoiDung == CurrentUserSession.MaNguoiDung && u.MatKhauHash == oldPassHash);

                    if (user == null)
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhauCu.Focus();
                        return;
                    }

                    user.MatKhauHash = SecurityHelper.ComputeSha256Hash(newPass);
                    db.SubmitChanges();

                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
