using MiniMart_windev.Helpers;
using DanhMuc = MiniMart_windev.Models.DanhMuc;
using MiniMart_windev.Models;
using QuanLyBanHangKhoDataContext = MiniMart_windev.Models.MiniMartDBDataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMart_windev.Forms.DanhMuc
{
    using DanhMuc = MiniMart_windev.Models.DanhMuc;
    public partial class frmProductManagement : Form
    {
        private QuanLyBanHangKhoDataContext db = new QuanLyBanHangKhoDataContext();

        public frmProductManagement()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
            LoadDanhMuc();
            LoadNhaCungCap();
            LoadSanPham();
            LoadLocDanhMuc();
            txtMaSanPham.Text = TaoMaSanPhamMoi();
        }

        private string TaoMaSanPhamMoi()
        {
            try
            {
                var listMa = db.GetTable<SanPham>()
                               .Select(s => s.MaSanPham)
                               .ToList();

                int maxSo = 0;
                foreach (var ma in listMa)
                {
                    if (!string.IsNullOrEmpty(ma) && ma.StartsWith("SP", StringComparison.OrdinalIgnoreCase))
                    {
                        if (int.TryParse(ma.Substring(2), out int so))
                        {
                            if (so > maxSo) maxSo = so;
                        }
                    }
                }

                int nextSo = maxSo + 1;
                string nextMa = "SP" + nextSo.ToString("D3");

                while (listMa.Any(m => string.Equals(m, nextMa, StringComparison.OrdinalIgnoreCase)))
                {
                    nextSo++;
                    nextMa = "SP" + nextSo.ToString("D3");
                }

                return nextMa;
            }
            catch
            {
                return "SP" + (db.GetTable<SanPham>().Count() + 1).ToString("D3");
            }
        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {
        }

        private void LoadSanPham()
        {
            dgvSanPham.DataSource = db.GetTable<SanPham>()
                .Select(sp => new
                {
                    sp.MaSanPham,
                    sp.TenSanPham,
                    TenDanhMuc = sp.DanhMuc.TenDanhMuc,
                    TenNCC = sp.NhaCungCap.TenNCC,
                    sp.DonGia,
                    sp.SoLuongTon
                })
                .ToList();
        }

        private void LoadDanhMuc()
        {
            var danhSach = db.GetTable<DanhMuc>()
                .ToList()
                .GroupBy(dm => dm.TenDanhMuc)
                .Select(g => new
                {
                    MaDanhMuc = g.Min(dm => dm.MaDanhMuc),
                    TenDanhMuc = g.Key
                })
                .ToList();

            cboDanhMuc.DataSource = danhSach;
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void LoadNhaCungCap()
        {
            cboNhaCungCap.DataSource = db.GetTable<NhaCungCap>().ToList();
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenSanPham.Text.Trim() == "" ||
                txtDonGia.Text.Trim() == "" ||
                txtSoLuongTon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDanhMuc.SelectedValue == null || cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục và nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal donGia;
            int soLuong;

            string cleanDonGia = txtDonGia.Text.Trim().Replace(",", "");
            if (!decimal.TryParse(cleanDonGia, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out donGia) &&
                !decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuongTon.Text.Trim(), out soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (donGia < 0 || soLuong < 0)
            {
                MessageBox.Show("Đơn giá và số lượng không được âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SanPham sp = new SanPham();
                sp.MaSanPham = TaoMaSanPhamMoi();
                sp.TenSanPham = txtTenSanPham.Text.Trim();
                sp.MaDanhMuc = Convert.ToInt32(cboDanhMuc.SelectedValue);
                sp.MaNCC = Convert.ToInt32(cboNhaCungCap.SelectedValue);
                sp.DonGia = donGia;
                sp.SoLuongTon = soLuong;

                db.GetTable<SanPham>().InsertOnSubmit(sp);
                db.SubmitChanges();

                MessageBox.Show("Thêm sản phẩm thành công! Mã sản phẩm: " + sp.MaSanPham, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSanPham();
                LoadLocDanhMuc();

                txtMaSanPham.Text = TaoMaSanPhamMoi();
                txtTenSanPham.Clear();
                txtDonGia.Clear();
                txtSoLuongTon.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTenSanPham.Text.Trim() == "" ||
                txtDonGia.Text.Trim() == "" ||
                txtSoLuongTon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDanhMuc.SelectedValue == null || cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục và nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal donGia;
            int soLuong;

            string cleanDonGia = txtDonGia.Text.Trim().Replace(",", "");
            if (!decimal.TryParse(cleanDonGia, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out donGia) &&
                !decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuongTon.Text.Trim(), out soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (donGia < 0 || soLuong < 0)
            {
                MessageBox.Show("Đơn giá và số lượng không được âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maSP = txtMaSanPham.Text.Trim();

                SanPham sp = db.GetTable<SanPham>()
                    .FirstOrDefault(x => x.MaSanPham == maSP);

                if (sp == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                sp.TenSanPham = txtTenSanPham.Text.Trim();
                sp.MaDanhMuc = Convert.ToInt32(cboDanhMuc.SelectedValue);
                sp.MaNCC = Convert.ToInt32(cboNhaCungCap.SelectedValue);
                sp.DonGia = donGia;
                sp.SoLuongTon = soLuong;

                db.SubmitChanges();

                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSanPham();
                LoadLocDanhMuc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSanPham.Rows.Count)
                return;

            try
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                string maSP = row.Cells["MaSanPham"].Value?.ToString();

                SanPham sp = db.GetTable<SanPham>()
                    .FirstOrDefault(x => x.MaSanPham == maSP);

                if (sp == null)
                    return;

                txtMaSanPham.Text = sp.MaSanPham.ToString();
                txtTenSanPham.Text = sp.TenSanPham;
                cboDanhMuc.SelectedValue = sp.MaDanhMuc;
                cboNhaCungCap.SelectedValue = sp.MaNCC;
                txtDonGia.Text = sp.DonGia.ToString("#,##0");
                txtSoLuongTon.Text = sp.SoLuongTon.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi click dòng sản phẩm: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sản phẩm này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string maSP = txtMaSanPham.Text.Trim();

                    SanPham sp = db.GetTable<SanPham>()
                        .FirstOrDefault(x => x.MaSanPham == maSP);

                    if (sp != null)
                    {
                        db.GetTable<SanPham>().DeleteOnSubmit(sp);
                        db.SubmitChanges();

                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSanPham();
                        LoadLocDanhMuc();

                        txtMaSanPham.Text = TaoMaSanPhamMoi();
                        txtTenSanPham.Clear();
                        txtDonGia.Clear();
                        txtSoLuongTon.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa sản phẩm này do đã phát sinh hóa đơn hoặc phiếu nhập liên quan!\n\nChi tiết: " + ex.Message,
                        "Cảnh báo ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSanPham.Text = TaoMaSanPhamMoi();
            txtTenSanPham.Clear();
            txtDonGia.Clear();
            txtSoLuongTon.Clear();
            txtTimKiem.Clear();

            cboDanhMuc.SelectedIndex = -1;
            cboNhaCungCap.SelectedIndex = -1;

            LoadSanPham();
            LoadLocDanhMuc();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            dgvSanPham.DataSource = db.GetTable<SanPham>()
                .Where(sp => sp.TenSanPham.Contains(tuKhoa))
                .Select(sp => new
                {
                    sp.MaSanPham,
                    sp.TenSanPham,
                    TenDanhMuc = sp.DanhMuc.TenDanhMuc,
                    TenNCC = sp.NhaCungCap.TenNCC,
                    sp.DonGia,
                    sp.SoLuongTon
                })
                .ToList();

            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!");
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (ActiveControl == txtTenSanPham)
                {
                    cboDanhMuc.Focus();
                    return true;
                }
                else if (ActiveControl == cboDanhMuc)
                {
                    cboNhaCungCap.Focus();
                    return true;
                }
                else if (ActiveControl == cboNhaCungCap)
                {
                    txtDonGia.Focus();
                    return true;
                }
                else if (ActiveControl == txtDonGia)
                {
                    txtSoLuongTon.Focus();
                    return true;
                }
                else if (ActiveControl == txtSoLuongTon)
                {
                    btnThem.Focus();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    
        private void LoadLocDanhMuc()
        {
            try
            {
                cboLocDanhMuc.DataSource = db.GetTable<DanhMuc>().ToList();
                cboLocDanhMuc.DisplayMember = "TenDanhMuc";
                cboLocDanhMuc.ValueMember = "MaDanhMuc";
            }
            catch { }
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (cboLocDanhMuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDanhMuc = Convert.ToInt32(cboLocDanhMuc.SelectedValue);
            string tenDM = cboLocDanhMuc.Text;

            frmInventoryReport f = new frmInventoryReport(maDanhMuc, tenDM);
            f.ShowDialog();
        }
    }
}