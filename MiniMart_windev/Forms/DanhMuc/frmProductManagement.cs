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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            decimal donGia;
            int soLuong;

            if (!decimal.TryParse(txtDonGia.Text, out donGia) ||
                !int.TryParse(txtSoLuongTon.Text, out soLuong))
            {
                MessageBox.Show("Đơn giá hoặc số lượng không hợp lệ!");
                return;
            }

            if (donGia < 0 || soLuong < 0)
            {
                MessageBox.Show("Đơn giá và số lượng không được âm!");
                return;
            }

            SanPham sp = new SanPham();
            sp.MaSanPham = "SP" + (db.GetTable<SanPham>().Count() + 1).ToString("D3");
            sp.TenSanPham = txtTenSanPham.Text.Trim();
            sp.MaDanhMuc = Convert.ToInt32(cboDanhMuc.SelectedValue);
            sp.MaNCC = Convert.ToInt32(cboNhaCungCap.SelectedValue);
            sp.DonGia = donGia;
            sp.SoLuongTon = soLuong;

            db.GetTable<SanPham>().InsertOnSubmit(sp);
            db.SubmitChanges();

            MessageBox.Show("Thêm sản phẩm thành công!");
            LoadSanPham();
            LoadLocDanhMuc();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!");
                return;
            }

            if (txtTenSanPham.Text.Trim() == "" ||
                txtDonGia.Text.Trim() == "" ||
                txtSoLuongTon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            decimal donGia;
            int soLuong;

            if (!decimal.TryParse(txtDonGia.Text, out donGia) ||
                !int.TryParse(txtSoLuongTon.Text, out soLuong))
            {
                MessageBox.Show("Đơn giá hoặc số lượng không hợp lệ!");
                return;
            }

            if (donGia < 0 || soLuong < 0)
            {
                MessageBox.Show("Đơn giá và số lượng không được âm!");
                return;
            }

            string maSP = txtMaSanPham.Text.Trim();

            SanPham sp = db.GetTable<SanPham>()
                .FirstOrDefault(x => x.MaSanPham == maSP);

            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!");
                return;
            }

            sp.TenSanPham = txtTenSanPham.Text.Trim();
            sp.MaDanhMuc = Convert.ToInt32(cboDanhMuc.SelectedValue);
            sp.MaNCC = Convert.ToInt32(cboNhaCungCap.SelectedValue);
            sp.DonGia = donGia;
            sp.SoLuongTon = soLuong;

            db.SubmitChanges();

            MessageBox.Show("Cập nhật sản phẩm thành công!");
            LoadSanPham();
            LoadLocDanhMuc();
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sản phẩm này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maSP = txtMaSanPham.Text.Trim();

                SanPham sp = db.GetTable<SanPham>()
                    .FirstOrDefault(x => x.MaSanPham == maSP);

                if (sp != null)
                {
                    db.GetTable<SanPham>().DeleteOnSubmit(sp);
                    db.SubmitChanges();

                    MessageBox.Show("Xóa sản phẩm thành công!");
                    LoadSanPham();
            LoadLocDanhMuc();

                    txtMaSanPham.Clear();
                    txtTenSanPham.Clear();
                    txtDonGia.Clear();
                    txtSoLuongTon.Clear();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSanPham.Clear();
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