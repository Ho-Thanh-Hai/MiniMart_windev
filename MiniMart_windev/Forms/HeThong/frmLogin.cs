using System;
using System.Windows.Forms;
using System.Linq;
using MiniMart_windev.Helpers;
using MiniMart_windev.Models;

namespace MiniMart_windev.Forms.HeThong
{
    public partial class frmLogin : Form
    {
        private Label label1;
        private Label label2;
        private TextBox txtTenDangNhap;
        private Label label3;
        private CheckBox chkHienMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;
        private LinkLabel lnkCauHinh;
        private TextBox txtMatKhau;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkHienMatKhau = new System.Windows.Forms.CheckBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lnkCauHinh = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hệ thống quản lí siêu thị Mini";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(228, 105);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(100, 20);
            this.txtTenDangNhap.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(228, 167);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(100, 20);
            this.txtMatKhau.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu";
            // 
            // chkHienMatKhau
            // 
            this.chkHienMatKhau.AutoSize = true;
            this.chkHienMatKhau.Location = new System.Drawing.Point(228, 194);
            this.chkHienMatKhau.Name = "chkHienMatKhau";
            this.chkHienMatKhau.Size = new System.Drawing.Size(95, 17);
            this.chkHienMatKhau.TabIndex = 5;
            this.chkHienMatKhau.Text = "Hiện mật khẩu";
            this.chkHienMatKhau.UseVisualStyleBackColor = true;
            this.chkHienMatKhau.CheckedChanged += new System.EventHandler(this.chkHienMatKhau_CheckedChanged);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(267, 261);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(75, 23);
            this.btnDangNhap.TabIndex = 6;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(428, 261);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lnkCauHinh
            // 
            this.lnkCauHinh.AutoSize = true;
            this.lnkCauHinh.Location = new System.Drawing.Point(13, 386);
            this.lnkCauHinh.Name = "lnkCauHinh";
            this.lnkCauHinh.Size = new System.Drawing.Size(136, 13);
            this.lnkCauHinh.TabIndex = 8;
            this.lnkCauHinh.TabStop = true;
            this.lnkCauHinh.Text = "Cấu hình kết nối máy chủ...";
            this.lnkCauHinh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCauHinh_LinkClicked);
            // 
            // frmLogin
            // 
            this.ClientSize = new System.Drawing.Size(800, 411);
            this.Controls.Add(this.lnkCauHinh);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.chkHienMatKhau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập-MiniMart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Đóng toàn bộ ứng dụng
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu tích chọn thì xóa ký tự *, ngược lại thì bật lại ký tự *
            if (chkHienMatKhau.Checked)
            {
                txtMatKhau.PasswordChar = '\0'; // Hiện mật khẩu bình thường
            }
            else
            {
                txtMatKhau.PasswordChar = '*';  // Che mật khẩu lại
            }
        }

        private void lnkCauHinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmConnectionConfig configForm = new frmConnectionConfig();
            configForm.ShowDialog(); // Bật form cấu hình lên dạng hộp thoại
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text;

            // 1. Kiểm tra đầu vào
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Clear();
                        txtMatKhau.Focus();
                        return;
                    }

                    if (account.TrangThai == false)
                    {
                        MessageBox.Show("Tài khoản này hiện đang bị khóa. Vui lòng liên hệ Admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    // 5. Lưu thông tin tài khoản vào phiên đăng nhập tĩnh (CurrentUserSession)
                    CurrentUserSession.MaNguoiDung = account.MaNguoiDung;
                    CurrentUserSession.TenDangNhap = account.TenDangNhap;
                    CurrentUserSession.HoTen = account.HoTen;
                    CurrentUserSession.MaVaiTro = account.MaVaiTro;
                    CurrentUserSession.TenVaiTro = account.TenVaiTro;

                    // 6. Đăng nhập thành công -> Ẩn form Login và mở form Main
                    MessageBox.Show($"Đăng nhập thành công!\nXin chào {account.HoTen} ({account.TenVaiTro})", "Chào mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide(); // Ẩn Login đi
                    frmMain mainForm = new frmMain();
                    mainForm.ShowDialog(); // Chạy Main

                    // Khi người dùng bấm Đăng xuất ở Main tắt đi thì mở lại Login
                    this.Show();
                    txtMatKhau.Clear();
                    txtTenDangNhap.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến máy chủ CSDL!\nChi tiết: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
