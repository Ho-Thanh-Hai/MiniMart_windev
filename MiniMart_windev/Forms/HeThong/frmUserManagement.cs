using System;
using System.Linq;
using System.Windows.Forms;
using MiniMart_windev.Helpers;
using MiniMart_windev.Models;

namespace MiniMart_windev.Forms.HeThong
{
    public partial class frmUserManagement : Form
    {
        private int selectedUserId = 0;

        public frmUserManagement()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            LoadVaiTro();
            LoadNguoiDung();
        }

        private void LoadVaiTro()
        {
            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    var roles = db.VaiTros.ToList();
                    cboVaiTro.DataSource = roles;
                    cboVaiTro.DisplayMember = "TenVaiTro";
                    cboVaiTro.ValueMember = "MaVaiTro";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải vai trò: " + ex.Message);
            }
        }

        private void LoadNguoiDung(string keyword = "")
        {
            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    var query = from u in db.NguoiDungs
                                join r in db.VaiTros on u.MaVaiTro equals r.MaVaiTro
                                select new
                                {
                                    u.MaNguoiDung,
                                    u.TenDangNhap,
                                    u.HoTen,
                                    u.MaVaiTro,
                                    r.TenVaiTro,
                                    TrangThai = u.TrangThai == true ? "Hoạt động" : "Đã khóa"
                                };

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        query = query.Where(u => u.TenDangNhap.Contains(keyword) || u.HoTen.Contains(keyword));
                    }

                    dgvNguoiDung.AutoGenerateColumns = false;
                    dgvNguoiDung.AutoGenerateColumns = false;
                    dgvNguoiDung.DataSource = query.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách người dùng: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text;
            string fullname = txtHoTen.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullname))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    if (db.NguoiDungs.Any(x => x.TenDangNhap == username))
                    {
                        MessageBox.Show("Tên đăng nhập này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    NguoiDung u = new NguoiDung
                    {
                        TenDangNhap = username,
                        MatKhauHash = SecurityHelper.ComputeSha256Hash(password),
                        HoTen = fullname,
                        MaVaiTro = Convert.ToInt32(cboVaiTro.SelectedValue),
                        TrangThai = chkTrangThai.Checked
                    };

                    db.NguoiDungs.InsertOnSubmit(u);
                    db.SubmitChanges();

                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm tài khoản: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullname = txtHoTen.Text.Trim();
            if (string.IsNullOrEmpty(fullname))
            {
                MessageBox.Show("Họ và tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    var user = db.NguoiDungs.FirstOrDefault(u => u.MaNguoiDung == selectedUserId);
                    if (user != null)
                    {
                        user.HoTen = fullname;
                        user.MaVaiTro = Convert.ToInt32(cboVaiTro.SelectedValue);
                        user.TrangThai = chkTrangThai.Checked;

                        if (!string.IsNullOrEmpty(txtMatKhau.Text))
                        {
                            user.MatKhauHash = SecurityHelper.ComputeSha256Hash(txtMatKhau.Text);
                        }

                        db.SubmitChanges();
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLamMoi_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa tài khoản: " + ex.Message);
            }
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần khóa/mở khóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedUserId == CurrentUserSession.MaNguoiDung)
            {
                MessageBox.Show("Không thể tự khóa tài khoản của chính mình!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    var user = db.NguoiDungs.FirstOrDefault(u => u.MaNguoiDung == selectedUserId);
                    if (user != null)
                    {
                        user.TrangThai = !user.TrangThai;
                        db.SubmitChanges();
                        string msg = user.TrangThai == true ? "Đã MỞ KHÓA tài khoản!" : "Đã KHÓA tài khoản!";
                        MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLamMoi_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thao tác: " + ex.Message);
            }
        }

        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần đặt lại mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Đặt lại mật khẩu cho tài khoản này về mặc định '123456'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new MiniMartDBDataContext())
                    {
                        var user = db.NguoiDungs.FirstOrDefault(u => u.MaNguoiDung == selectedUserId);
                        if (user != null)
                        {
                            user.MatKhauHash = SecurityHelper.ComputeSha256Hash("123456");
                            db.SubmitChanges();
                            MessageBox.Show("Đã đặt lại mật khẩu thành công: 123456", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLamMoi_Click(null, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi đặt lại mật khẩu: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            selectedUserId = 0;
            txtTenDangNhap.Clear();
            txtTenDangNhap.ReadOnly = false;
            txtMatKhau.Clear();
            txtHoTen.Clear();
            txtTimKiem.Clear();
            chkTrangThai.Checked = true;
            if (cboVaiTro.Items.Count > 0) cboVaiTro.SelectedIndex = 0;
            LoadNguoiDung();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadNguoiDung(txtTimKiem.Text.Trim());
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguoiDung.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["MaNguoiDung"].Value);
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtTenDangNhap.ReadOnly = true; // Không cho sửa username
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                cboVaiTro.SelectedValue = row.Cells["MaVaiTro"].Value;
                chkTrangThai.Checked = row.Cells["TrangThai"].Value.ToString() == "Hoạt động";
                txtMatKhau.Clear();
            }
        }
    }
}
