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
    public partial class frmSalesInvoice : Form
    {
        public frmSalesInvoice()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
            dgvHoaDon.AutoGenerateColumns = false;

            LoadKhachHang();
            LoadNguoiDung();
            LoadHoaDon();

            txtMaHoaDon.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtThanhTien.ReadOnly = true;

            dtpNgayLap.Value = DateTime.Now;
        }

        private void lblMaHoaDon_Click(object sender, EventArgs e)
        {

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
                        kh.HoTen
                    })
                    .ToList();

                cboKhachHang.DataSource = danhSach;
                cboKhachHang.DisplayMember = "HoTen";
                cboKhachHang.ValueMember = "MaKhachHang";
            }
        }
        private void LoadNguoiDung()
        {
            using (QuanLyBanHangKhoDataContext db =
                   new QuanLyBanHangKhoDataContext())
            {
                var danhSach = db.GetTable<NguoiDung>()
                    .Select(nd => new
                    {
                        nd.MaNguoiDung,
                        nd.HoTen
                    })
                    .ToList();

                cboNguoiDung.DataSource = danhSach;
                cboNguoiDung.DisplayMember = "HoTen";
                cboNguoiDung.ValueMember = "MaNguoiDung";
            }
        }
        private void LoadHoaDon()
        {
            using (QuanLyBanHangKhoDataContext db =
                   new QuanLyBanHangKhoDataContext())
            {
                var danhSach = (from hd in db.GetTable<HoaDon>()
                                join kh in db.GetTable<KhachHang>()
                                on hd.MaKhachHang equals kh.MaKhachHang
                                join nd in db.GetTable<NguoiDung>()
                                on hd.MaNguoiDung equals nd.MaNguoiDung
                                select new
                                {
                                    hd.MaHoaDon,
                                    hd.MaKhachHang,
                                    hd.MaNguoiDung,
                                    TenKhachHang = kh.HoTen,
                                    TenNguoiLap = nd.HoTen,
                                    hd.NgayLap,
                                    hd.TongTien,
                                    hd.GiamGia,
                                    hd.ThanhTien
                                }).ToList();

                dgvHoaDon.DataSource = danhSach;
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

                txtMaHoaDon.Text =
                    row.Cells["MaHoaDon"].Value.ToString();

                dtpNgayLap.Value =
                    Convert.ToDateTime(row.Cells["NgayLap"].Value);

                txtTongTien.Text =
                    row.Cells["TongTien"].Value.ToString();

                txtGiamGia.Text =
                    row.Cells["GiamGia"].Value.ToString();

                txtThanhTien.Text =
                    row.Cells["ThanhTien"].Value.ToString();

                cboKhachHang.Text =
                    row.Cells["TenKhachHang"].Value.ToString();

                cboNguoiDung.Text =
                    row.Cells["TenNguoiLap"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra khách hàng
            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!");
                cboKhachHang.Focus();
                return;
            }

            // Kiểm tra người lập hóa đơn
            if (cboNguoiDung.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn người lập hóa đơn!");
                cboNguoiDung.Focus();
                return;
            }

            try
            {
                using (QuanLyBanHangKhoDataContext db =
                       new QuanLyBanHangKhoDataContext())
                {
                    // Tạo hóa đơn mới
                    HoaDon hd = new HoaDon();

                    hd.MaKhachHang =
                        Convert.ToInt32(cboKhachHang.SelectedValue);

                    hd.MaNguoiDung =
                        Convert.ToInt32(cboNguoiDung.SelectedValue);

                    hd.NgayLap = dtpNgayLap.Value;

                    hd.TongTien = 0;
                    hd.GiamGia = 0;
                    hd.ThanhTien = 0;

                    // Thêm vào database
                    db.GetTable<HoaDon>().InsertOnSubmit(hd);

                    // Lưu thay đổi
                    db.SubmitChanges();

                    MessageBox.Show(
                        "Thêm hóa đơn thành công!\nMã hóa đơn: "
                        + hd.MaHoaDon);

                    // Tải lại danh sách hóa đơn
                    LoadHoaDon();

                    // Hiển thị mã hóa đơn vừa tạo
                    txtMaHoaDon.Text = hd.MaHoaDon.ToString();

                    // Hiển thị giá trị ban đầu
                    txtTongTien.Text = "0";
                    txtGiamGia.Text = "0";
                    txtThanhTien.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi thêm hóa đơn: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn hóa đơn chưa
            if (txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!");
                return;
            }

            // Kiểm tra khách hàng
            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!");
                return;
            }

            // Kiểm tra người lập
            if (cboNguoiDung.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn người lập hóa đơn!");
                return;
            }

            try
            {
                using (QuanLyBanHangKhoDataContext db =
                       new QuanLyBanHangKhoDataContext())
                {
                    // Lấy mã hóa đơn
                    int maHD = Convert.ToInt32(txtMaHoaDon.Text);

                    // Tìm hóa đơn trong database
                    HoaDon hd = db.GetTable<HoaDon>()
                        .FirstOrDefault(x => x.MaHoaDon == maHD);

                    if (hd == null)
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn!");
                        return;
                    }

                    // Cập nhật thông tin
                    hd.MaKhachHang =
                        Convert.ToInt32(cboKhachHang.SelectedValue);

                    hd.MaNguoiDung =
                        Convert.ToInt32(cboNguoiDung.SelectedValue);

                    hd.NgayLap = dtpNgayLap.Value;

                    // Không tự ý thay đổi tổng tiền
                    // và thành tiền tại form này.

                    db.SubmitChanges();

                    MessageBox.Show("Cập nhật hóa đơn thành công!");

                    LoadHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi sửa hóa đơn: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn hóa đơn chưa
            if (txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!");
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa hóa đơn này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (ketQua == DialogResult.No)
            {
                return;
            }

            try
            {
                using (QuanLyBanHangKhoDataContext db =
                       new QuanLyBanHangKhoDataContext())
                {
                    // Lấy mã hóa đơn
                    int maHD = Convert.ToInt32(txtMaHoaDon.Text);

                    // Tìm hóa đơn cần xóa
                    HoaDon hd = db.GetTable<HoaDon>()
                        .FirstOrDefault(x => x.MaHoaDon == maHD);

                    if (hd == null)
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn!");
                        return;
                    }

                    // Xóa hóa đơn
                    db.GetTable<HoaDon>().DeleteOnSubmit(hd);

                    // Lưu thay đổi
                    db.SubmitChanges();

                    MessageBox.Show("Xóa hóa đơn thành công!");

                    // Tải lại danh sách
                    LoadHoaDon();

                    // Xóa thông tin trên form
                    txtMaHoaDon.Clear();
                    txtTongTien.Text = "0";
                    txtGiamGia.Text = "0";
                    txtThanhTien.Text = "0";
                    cboKhachHang.SelectedIndex = -1;
                    cboNguoiDung.SelectedIndex = -1;
                    dtpNgayLap.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xóa hóa đơn!\n" + ex.Message
                );
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Xóa mã hóa đơn
            txtMaHoaDon.Clear();

            // Đặt lại ngày lập
            dtpNgayLap.Value = DateTime.Now;

            // Đặt lại ComboBox khách hàng
            cboKhachHang.SelectedIndex = -1;

            // Đặt lại ComboBox người dùng
            cboNguoiDung.SelectedIndex = -1;

            // Đặt lại các giá trị tiền
            txtTongTien.Text = "0";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";

            // Xóa nội dung tìm kiếm
            txtTimKiem.Clear();

            // Bỏ chọn dòng trong DataGridView
            dgvHoaDon.ClearSelection();

            // Tải lại danh sách hóa đơn
            LoadHoaDon();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            // Nếu không nhập từ khóa thì hiển thị tất cả hóa đơn
            if (tuKhoa == "")
            {
                LoadHoaDon();
                return;
            }

            try
            {
                using (QuanLyBanHangKhoDataContext db =
                       new QuanLyBanHangKhoDataContext())
                {
                    // Kết hợp hóa đơn, khách hàng và người dùng
                    var query = from hd in db.GetTable<HoaDon>()
                                join kh in db.GetTable<KhachHang>()
                                on hd.MaKhachHang equals kh.MaKhachHang
                                join nd in db.GetTable<NguoiDung>()
                                on hd.MaNguoiDung equals nd.MaNguoiDung
                                select new
                                {
                                    hd,
                                    kh,
                                    nd
                                };

                    // Tìm theo mã hóa đơn hoặc tên khách hàng
                    int maHD;

                    if (int.TryParse(tuKhoa, out maHD))
                    {
                        query = query.Where(x =>
                            x.hd.MaHoaDon == maHD ||
                            x.kh.HoTen.Contains(tuKhoa));
                    }
                    else
                    {
                        query = query.Where(x =>
                            x.kh.HoTen.Contains(tuKhoa));
                    }

                    // Lấy kết quả tìm kiếm
                    var danhSach = query.Select(x => new
                    {
                        x.hd.MaHoaDon,
                        x.hd.MaKhachHang,
                        x.hd.MaNguoiDung,
                        TenKhachHang = x.kh.HoTen,
                        TenNguoiLap = x.nd.HoTen,
                        x.hd.NgayLap,
                        x.hd.TongTien,
                        x.hd.GiamGia,
                        x.hd.ThanhTien
                    }).ToList();

                    // Hiển thị kết quả
                    dgvHoaDon.DataSource = danhSach;

                    if (danhSach.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tìm kiếm hóa đơn: " + ex.Message);
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn hóa đơn chưa
            if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xem chi tiết!");
                return;
            }

            // Lấy mã hóa đơn
            int maHD = Convert.ToInt32(txtMaHoaDon.Text);

            // Mở form chi tiết hóa đơn và truyền mã hóa đơn
            frmInvoiceDetail frm = new frmInvoiceDetail(maHD);

            frm.ShowDialog();
        }
    }
}
