using MiniMart_windev.Helpers;
using MiniMart_windev.Models;
using QuanLyBanHangKho;
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
    public partial class frmStockReceipt : Form
    {
        private QuanLyBanHangKhoDataContext db = new QuanLyBanHangKhoDataContext();

        public frmStockReceipt()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);

            dtpNgayNhap.MaxDate = DateTime.Today;

            LoadNhaCungCap();
            CapNhatTatCaTongTien();
            LoadPhieuNhap();
        }

        private void LoadNhaCungCap()
        {
            cboNhaCungCap.DataSource = db.GetTable<NhaCungCap>().ToList();
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
        }
        private void LoadPhieuNhap()
        {
            var danhSach = db.GetTable<PhieuNhap>()
                .Select(p => new
                {
                    p.MaPhieuNhap,
                    TenNCC = p.NhaCungCap.TenNCC,
                    TenNguoiLap = p.NguoiDung.HoTen,
                    p.NgayNhap,
                    p.TongTien
                })
                .ToList();

            dgvPhieuNhap.DataSource = danhSach.Select(p => new
            {
                p.MaPhieuNhap,
                p.TenNCC,
                p.TenNguoiLap,
                p.NgayNhap,
                TongTien = (p.TongTien ?? 0).ToString("#,##0")
            }).ToList();
        }

        private void CapNhatTatCaTongTien()
        {
            var danhSachPhieu = db.GetTable<PhieuNhap>().ToList();

            foreach (var pn in danhSachPhieu)
            {
                pn.TongTien = db.GetTable<ChiTietPhieuNhap>()
                    .Where(ct => ct.MaPhieuNhap == pn.MaPhieuNhap)
                    .Select(ct => (decimal?)ct.ThanhTien)
                    .Sum() ?? 0;
            }

            db.SubmitChanges();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                return;
            }
            
            if (ThongTinDangNhap.MaNguoiDungDangNhap <= 0)
            {
                MessageBox.Show("Vui lòng đăng nhập trước khi tạo phiếu nhập!");
                return;
            }

            PhieuNhap pn = new PhieuNhap();

            pn.MaNCC = Convert.ToInt32(cboNhaCungCap.SelectedValue);
            pn.MaNguoiDung = ThongTinDangNhap.MaNguoiDungDangNhap;
            pn.NgayNhap = dtpNgayNhap.Value;
            pn.TongTien = 0;

            db.GetTable<PhieuNhap>().InsertOnSubmit(pn);
            db.SubmitChanges();

            MessageBox.Show("Thêm phiếu nhập thành công!");

            LoadPhieuNhap();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieuNhap.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập cần xóa!");
                return;
            }

            int maPN = Convert.ToInt32(txtMaPhieuNhap.Text);

            PhieuNhap pn = db.GetTable<PhieuNhap>()
                .FirstOrDefault(p => p.MaPhieuNhap == maPN);

            if (pn == null)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa phiếu nhập này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            var chiTiet = db.GetTable<ChiTietPhieuNhap>()
                .Where(ct => ct.MaPhieuNhap == maPN)
                .ToList();

            // Kiểm tra tồn kho trước khi hoàn tác
            foreach (var ct in chiTiet)
            {
                SanPham sp = db.GetTable<SanPham>()
                    .FirstOrDefault(s => s.MaSanPham == ct.MaSanPham);

                if (sp == null || sp.SoLuongTon < ct.SoLuong)
                {
                    MessageBox.Show(
                        "Không thể xóa phiếu nhập vì tồn kho không đủ để hoàn tác!");
                    return;
                }
            }

            // Hoàn lại số lượng tồn kho
            foreach (var ct in chiTiet)
            {
                SanPham sp = db.GetTable<SanPham>()
                    .FirstOrDefault(s => s.MaSanPham == ct.MaSanPham);

                sp.SoLuongTon -= ct.SoLuong;
            }

            // Xóa các chi tiết phiếu nhập
            db.GetTable<ChiTietPhieuNhap>().DeleteAllOnSubmit(chiTiet);

            // Xóa phiếu nhập
            db.GetTable<PhieuNhap>().DeleteOnSubmit(pn);

            db.SubmitChanges();

            MessageBox.Show("Xóa phiếu nhập thành công!");

            txtMaPhieuNhap.Clear();
            txtTongTien.Clear();
            txtNguoiLap.Clear();

            LoadPhieuNhap();
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int maPN = Convert.ToInt32(
                dgvPhieuNhap.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value);

            PhieuNhap pn = db.GetTable<PhieuNhap>()
                .FirstOrDefault(p => p.MaPhieuNhap == maPN);

            if (pn == null)
                return;

            txtMaPhieuNhap.Text = pn.MaPhieuNhap.ToString();
            cboNhaCungCap.SelectedValue = pn.MaNCC;
            txtNguoiLap.Text = pn.NguoiDung.HoTen;

            DateTime ngay = pn.NgayNhap ?? DateTime.Now;
            dtpNgayNhap.MaxDate = ngay.Date > DateTime.Today
                ? ngay.Date.AddDays(1).AddTicks(-1)
                : DateTime.Today.AddDays(1).AddTicks(-1);

            dtpNgayNhap.Value = ngay;

            txtTongTien.Text = (pn.TongTien ?? 0).ToString("#,##0");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieuNhap.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập cần sửa!");
                return;
            }

            int maPN = Convert.ToInt32(txtMaPhieuNhap.Text);

            PhieuNhap pn = db.GetTable<PhieuNhap>()
                .FirstOrDefault(p => p.MaPhieuNhap == maPN);

            if (pn == null)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập!");
                return;
            }

            pn.MaNCC = Convert.ToInt32(cboNhaCungCap.SelectedValue);
            pn.NgayNhap = dtpNgayNhap.Value;

            db.SubmitChanges();

            MessageBox.Show("Cập nhật phiếu nhập thành công!");

            LoadPhieuNhap();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaPhieuNhap.Clear();
            txtNguoiLap.Clear();
            txtTongTien.Clear();

            cboNhaCungCap.SelectedIndex = -1;

            dtpNgayNhap.MaxDate = DateTime.Today.AddDays(1).AddTicks(-1);
            dtpNgayNhap.Value = DateTime.Now;

            txtTimKiem.Clear();

            LoadPhieuNhap();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            var danhSach = db.GetTable<PhieuNhap>()
                .Where(p => p.MaPhieuNhap.ToString().Contains(tuKhoa))
                .Select(p => new
                {
                    p.MaPhieuNhap,
                    TenNCC = p.NhaCungCap.TenNCC,
                    TenNguoiLap = p.NguoiDung.HoTen,
                    p.NgayNhap,
                    p.TongTien
                })
                .ToList();

            dgvPhieuNhap.DataSource = danhSach.Select(p => new
            {
                p.MaPhieuNhap,
                p.TenNCC,
                p.TenNguoiLap,
                p.NgayNhap,
                TongTien = (p.TongTien ?? 0).ToString("#,##0")
            }).ToList();

            if (danhSach.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập!");
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (ActiveControl == cboNhaCungCap)
                {
                    dtpNgayNhap.Focus();
                    return true;
                }
                else if (ActiveControl == dtpNgayNhap)
                {
                    btnThem.Focus();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
