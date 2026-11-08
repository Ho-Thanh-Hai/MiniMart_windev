using MiniMart_windev.Helpers;
using MiniMart_windev.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMart_windev.Forms.NghiepVu
{
    public partial class frmCustomerManagement : Form
    {
        public frmCustomerManagement()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
            dgvKhachHang.AutoGenerateColumns = false;
            LoadKhachHang();
        }

        private void LoadKhachHang()
        {
            using (QuanLyBanHangKhoDataContext db =
                   new QuanLyBanHangKhoDataContext())
            {
                var danhSach = db.GetTable<KhachHang>()
                    .Select(kh => new
                    {
                        kh.MaKhachHang,
                        kh.HoTen,
                        kh.SoDienThoai,
                        kh.Email,
                        kh.DiaChi
                    }).ToList();

                dgvKhachHang.DataSource = danhSach;
            }
        }
        private object GetRowCellValue(DataGridViewRow row, string primaryColName, string fallbackColName)
        {
            if (row == null || row.DataGridView == null) return null;
            if (row.DataGridView.Columns.Contains(primaryColName))
                return row.Cells[primaryColName].Value;
            if (row.DataGridView.Columns.Contains(fallbackColName))
                return row.Cells[fallbackColName].Value;
            return null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!");
                return;
            }

            object maVal = GetRowCellValue(dgvKhachHang.CurrentRow, "MaKhachHang", "colMaKhachHang");
            if (maVal == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!");
                return;
            }
            int maKH = Convert.ToInt32(maVal);

            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!");
                txtHoTen.Focus();
                return;
            }

            using (QuanLyBanHangKhoDataContext db =
                   new QuanLyBanHangKhoDataContext())
            {
                KhachHang kh = db.GetTable<KhachHang>()
                                 .FirstOrDefault(x => x.MaKhachHang == maKH);

                if (kh != null)
                {
                    kh.HoTen = txtHoTen.Text.Trim();
                    kh.SoDienThoai = txtSoDienThoai.Text.Trim();
                    kh.Email = txtEmail.Text.Trim();
                    kh.DiaChi = txtDiaChi.Text.Trim();

                    db.SubmitChanges();

                    MessageBox.Show("Cập nhật khách hàng thành công!");

                    LoadKhachHang();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!");
                txtHoTen.Focus();
                return;
            }

            using (QuanLyBanHangKhoDataContext db =
                   new QuanLyBanHangKhoDataContext())
            {
                KhachHang kh = new KhachHang();

                kh.HoTen = txtHoTen.Text.Trim();
                kh.SoDienThoai = txtSoDienThoai.Text.Trim();
                kh.Email = txtEmail.Text.Trim();
                kh.DiaChi = txtDiaChi.Text.Trim();

                db.GetTable<KhachHang>().InsertOnSubmit(kh);
                db.SubmitChanges();

                MessageBox.Show("Thêm khách hàng thành công!");

                LoadKhachHang();
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                txtHoTen.Text = GetRowCellValue(row, "HoTen", "colHoTen")?.ToString() ?? "";
                txtSoDienThoai.Text = GetRowCellValue(row, "SoDienThoai", "colSoDienThoai")?.ToString() ?? "";
                txtEmail.Text = GetRowCellValue(row, "Email", "colEmail")?.ToString() ?? "";
                txtDiaChi.Text = GetRowCellValue(row, "DiaChi", "colDiaChi")?.ToString() ?? "";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
                return;
            }

            object maVal = GetRowCellValue(dgvKhachHang.CurrentRow, "MaKhachHang", "colMaKhachHang");
            if (maVal == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
                return;
            }
            int maKH = Convert.ToInt32(maVal);

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khách hàng này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (QuanLyBanHangKhoDataContext db =
                       new QuanLyBanHangKhoDataContext())
                {
                    KhachHang kh = db.GetTable<KhachHang>()
                                     .FirstOrDefault(x => x.MaKhachHang == maKH);

                    if (kh != null)
                    {
                        db.GetTable<KhachHang>().DeleteOnSubmit(kh);
                        db.SubmitChanges();

                        MessageBox.Show("Xóa khách hàng thành công!");

                        LoadKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng!");
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtTimKiem.Clear();

            LoadKhachHang();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            using (QuanLyBanHangKhoDataContext db =
                   new QuanLyBanHangKhoDataContext())
            {
                var danhSach = db.GetTable<KhachHang>()
                    .Where(kh => kh.HoTen.Contains(tuKhoa)
                              || kh.SoDienThoai.Contains(tuKhoa))
                    .Select(kh => new
                    {
                        kh.MaKhachHang,
                        kh.HoTen,
                        kh.SoDienThoai,
                        kh.Email,
                        kh.DiaChi
                    }).ToList();

                dgvKhachHang.DataSource = danhSach;

                if (danhSach.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng!");
                }
            }
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            frmSalesInvoice frm = new frmSalesInvoice();
            frm.ShowDialog();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frmInvoiceReport frm = new frmInvoiceReport();
            frm.ShowDialog();
        }
    }
}
