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
    public partial class frmInvoiceReport : Form
    {
        public frmInvoiceReport()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);

            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;

            LoadBaoCaoHoaDon();
            ThongKeTongQuan();
        }
        QuanLyBanHangKhoDataContext db =
    new QuanLyBanHangKhoDataContext();

        private void LoadBaoCaoHoaDon()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            var danhSach = from hd in db.HoaDons
                           join kh in db.KhachHangs
                           on hd.MaKhachHang equals kh.MaKhachHang
                           join nd in db.NguoiDungs
                           on hd.MaNguoiDung equals nd.MaNguoiDung
                           where hd.NgayLap >= tuNgay
                              && hd.NgayLap < denNgay
                           select new
                           {
                               hd.MaHoaDon,
                               TenKhachHang = kh.HoTen,
                               TenNguoiLap = nd.HoTen,
                               hd.NgayLap,
                               hd.TongTien,
                               hd.GiamGia,
                               hd.ThanhTien
                           };

            dgvBaoCaoHoaDon.DataSource = danhSach.ToList();
        }
        private void ThongKeTongQuan()
        {
            // Lấy ngày bắt đầu và kết thúc
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            // Lấy danh sách hóa đơn trong khoảng thời gian
            var danhSach = db.HoaDons.Where(hd =>
                hd.NgayLap >= tuNgay &&
                hd.NgayLap < denNgay
            );

            // 1. Tổng số hóa đơn
            int tongHoaDon = danhSach.Count();

            // 2. Tổng doanh thu
            decimal tongDoanhThu = danhSach.Sum(hd => (decimal?)hd.ThanhTien) ?? 0;

            // 3. Tổng sản phẩm đã bán
            var danhSachMaHD = danhSach.Select(hd => hd.MaHoaDon);

            int tongSanPham = db.ChiTietHoaDons
                .Where(ct => danhSachMaHD.Contains(ct.MaHoaDon))
                .Sum(ct => (int?)ct.SoLuong) ?? 0;

            // Hiển thị kết quả lên giao diện
            lblSoHoaDon.Text = tongHoaDon.ToString();
            lblDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
            lblSoSanPham.Text = tongSanPham.ToString();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Kiểm tra ngày bắt đầu và ngày kết thúc
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Cập nhật danh sách hóa đơn
            LoadBaoCaoHoaDon();

            // Cập nhật các chỉ số thống kê
            ThongKeTongQuan();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            // Hiển thị toàn bộ hóa đơn
            var danhSach = from hd in db.HoaDons
                           join kh in db.KhachHangs
                           on hd.MaKhachHang equals kh.MaKhachHang
                           join nd in db.NguoiDungs
                           on hd.MaNguoiDung equals nd.MaNguoiDung
                           select new
                           {
                               hd.MaHoaDon,
                               TenKhachHang = kh.HoTen,
                               TenNguoiLap = nd.HoTen,
                               hd.NgayLap,
                               hd.TongTien,
                               hd.GiamGia,
                               hd.ThanhTien
                           };

            dgvBaoCaoHoaDon.DataSource = danhSach.ToList();

            // Cập nhật thống kê toàn bộ hóa đơn
            int tongHoaDon = db.HoaDons.Count();

            decimal tongDoanhThu = db.HoaDons
                .Sum(hd => (decimal?)hd.ThanhTien) ?? 0;

            int tongSanPham = db.ChiTietHoaDons
                .Sum(ct => (int?)ct.SoLuong) ?? 0;

            // Hiển thị kết quả
            lblSoHoaDon.Text = tongHoaDon.ToString();
            lblDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
            lblSoSanPham.Text = tongSanPham.ToString();
        }
    }
}
