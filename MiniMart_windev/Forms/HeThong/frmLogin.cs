using System;
using System.Linq;
using System.Windows.Forms;
using MiniMart_windev.Helpers;
using MiniMart_windev.Models;

namespace MiniMart_windev.Forms.HeThong
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = chkHienMatKhau.Checked ? '\0' : '●';
        }

        private void lnkCauHinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmConnectionConfig configForm = new frmConnectionConfig();
            configForm.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text;

            // 1. Kiểm tra đầu vào
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            // 2. Băm mật khẩu ra mã SHA-256
            string passwordHash = SecurityHelper.ComputeSha256Hash(password);

            // 3. Kết nối CSDL và truy vấn qua LINQ to SQL
            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    // Dùng LINQ tìm tài khoản khớp tên đăng nhập và mật khẩu băm
                    var account = (from u in db.NguoiDungs
                                   join r in db.VaiTros on u.MaVaiTro equals r.MaVaiTro
                                   where u.TenDangNhap == username && u.MatKhauHash == passwordHash
                                   select new
                                   {
                                       u.MaNguoiDung,
                                       u.TenDangNhap,
                                       u.HoTen,
                                       u.TrangThai,
                                       u.MaVaiTro,
                                       r.TenVaiTro
                                   }).FirstOrDefault();

                    // 4. Kiểm tra kết quả
                    if (account == null)
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi đăng nhập",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Clear();
                        txtMatKhau.Focus();
                        return;
                    }

                    if (account.TrangThai == false)
                    {
                        MessageBox.Show("Tài khoản này hiện đang bị khóa. Vui lòng liên hệ Admin!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    // 5. Lưu thông tin tài khoản vào phiên đăng nhập tĩnh (CurrentUserSession)
                    CurrentUserSession.MaNguoiDung = account.MaNguoiDung;
                    CurrentUserSession.TenDangNhap = account.TenDangNhap;
                    CurrentUserSession.HoTen = account.HoTen;
                    CurrentUserSession.MaVaiTro = account.MaVaiTro;
                    CurrentUserSession.TenVaiTro = account.TenVaiTro;

                    // 6. Đăng nhập thành công -> Mở form Main
                    MessageBox.Show($"Đăng nhập thành công!\nXin chào: {account.HoTen} ({account.TenVaiTro})",
                        "Chào mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    frmMain mainForm = new frmMain();
                    mainForm.ShowDialog();

                    // Khi người dùng bấm Đăng xuất ở Main tắt đi thì mở lại Login
                    this.Show();
                    txtMatKhau.Clear();
                    txtTenDangNhap.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến máy chủ CSDL!\nChi tiết: " + ex.Message,
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
