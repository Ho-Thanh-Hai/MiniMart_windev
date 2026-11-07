using MiniMart_windev.Helpers;
using MiniMart_windev.Models;
using Microsoft.Reporting.WinForms;
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
    public partial class frmInvoicePrint : Form
    {
        private int maHoaDon;
        private QuanLyBanHangKhoDataContext db = new QuanLyBanHangKhoDataContext();

        public frmInvoicePrint()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
        }

        public frmInvoicePrint(int maHD) : this()
        {
            maHoaDon = maHD;
        }

        private void frmInvoicePrint_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin Hóa đơn
                var hd = db.GetTable<HoaDon>().FirstOrDefault(h => h.MaHoaDon == maHoaDon);
                string maHDStr = "HD" + maHoaDon.ToString("D5");
                string ngayLapStr = (hd != null && hd.NgayLap.HasValue)
                    ? hd.NgayLap.Value.ToString("dd/MM/yyyy HH:mm")
                    : DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                string tenKH = "Khách vãng lai";
                if (hd != null && hd.MaKhachHang.HasValue)
                {
                    var kh = db.GetTable<KhachHang>().FirstOrDefault(k => k.MaKhachHang == hd.MaKhachHang.Value);
                    if (kh != null && !string.IsNullOrEmpty(kh.HoTen))
                    {
                        tenKH = kh.HoTen;
                    }
                }

                string tenNguoiLap = "Hệ thống";
                if (hd != null && hd.MaNguoiDung > 0)
                {
                    var nd = db.GetTable<NguoiDung>().FirstOrDefault(u => u.MaNguoiDung == hd.MaNguoiDung);
                    if (nd != null && !string.IsNullOrEmpty(nd.HoTen))
                    {
                        tenNguoiLap = nd.HoTen;
                    }
                }

                decimal tongTien = hd?.TongTien ?? 0;
                decimal giamGia = hd?.GiamGia ?? 0;
                decimal thanhTien = hd?.ThanhTien ?? 0;

                // Lấy chi tiết hóa đơn bằng LINQ to SQL
                var data = db.GetTable<ChiTietHoaDon>()
                    .Where(ct => ct.MaHoaDon == maHoaDon)
                    .Select(ct => new
                    {
                        ct.MaHoaDon,
                        ct.MaSanPham,
                        ct.SoLuong,
                        ct.DonGia,
                        ct.ThanhTien
                    })
                    .ToList();

                // Đưa tham số vào ReportParameter
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("MaHoaDon", maHDStr),
                    new ReportParameter("NgayLap", ngayLapStr),
                    new ReportParameter("TenKhachHang", tenKH),
                    new ReportParameter("TenNguoiLap", tenNguoiLap),
                    new ReportParameter("TongTien", tongTien.ToString("N0") + " VNĐ"),
                    new ReportParameter("GiamGia", giamGia.ToString("N0") + " VNĐ"),
                    new ReportParameter("ThanhTien", thanhTien.ToString("N0") + " VNĐ")
                };

                reportViewer1.LocalReport.SetParameters(parameters);

                // Đưa dữ liệu vào ReportViewer
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("dsChiTietHoaDon", data);
                reportViewer1.LocalReport.DataSources.Add(rds);

                // Cấu hình hiển thị chuẩn
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
