using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MiniMart_windev.Helpers;
using MiniMart_windev.Models;

namespace MiniMart_windev.Forms.BaoCao
{
    public partial class frmRevenuePrint : Form
    {
        private DateTime _tuNgay;
        private DateTime _denNgay;

        public frmRevenuePrint()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
            _tuNgay = DateTime.Today;
            _denNgay = DateTime.Today;
        }

        public frmRevenuePrint(DateTime tuNgay, DateTime denNgay) : this()
        {
            _tuNgay = tuNgay;
            _denNgay = denNgay;
        }

        private void frmRevenuePrint_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    var query = from hd in db.HoaDons
                                where hd.NgayLap >= _tuNgay && hd.NgayLap <= _denNgay
                                orderby hd.NgayLap ascending
                                join u in db.NguoiDungs on hd.MaNguoiDung equals u.MaNguoiDung into uGroup
                                from u in uGroup.DefaultIfEmpty()
                                join k in db.KhachHangs on hd.MaKhachHang equals k.MaKhachHang into kGroup
                                from k in kGroup.DefaultIfEmpty()
                                select new
                                {
                                    hd.MaHoaDon,
                                    hd.NgayLap,
                                    TenThuNgan = u != null ? u.HoTen : "Hệ thống",
                                    TenKhachHang = k != null ? k.HoTen : "Khách vãng lai",
                                    TongTien = hd.TongTien ?? 0,
                                    GiamGia = hd.GiamGia ?? 0,
                                    ThanhTien = hd.ThanhTien ?? 0
                                };

                    var list = query.ToList();

                    int stt = 1;
                    var reportData = list.Select(x => new
                    {
                        STT = stt++,
                        MaHoaDon = "HD" + x.MaHoaDon.ToString("D5"),
                        NgayLap = x.NgayLap.HasValue ? x.NgayLap.Value.ToString("dd/MM/yyyy HH:mm") : "",
                        TenThuNgan = x.TenThuNgan ?? "",
                        TenKhachHang = x.TenKhachHang ?? "",
                        TongTien = x.TongTien,
                        GiamGia = x.GiamGia,
                        ThanhTien = x.ThanhTien
                    }).ToList();

                    // Thiết lập parameters
                    string nguoiLap = !string.IsNullOrEmpty(CurrentUserSession.HoTen)
                        ? CurrentUserSession.HoTen
                        : "Quản trị viên";

                    reportViewer1.LocalReport.ReportEmbeddedResource = "MiniMart_windev.Forms.BaoCao.rptDoanhThu.rdlc";

                    ReportParameter[] parameters = new ReportParameter[]
                    {
                        new ReportParameter("TuNgay", _tuNgay.ToString("dd/MM/yyyy")),
                        new ReportParameter("DenNgay", _denNgay.ToString("dd/MM/yyyy")),
                        new ReportParameter("NguoiLap", nguoiLap),
                        new ReportParameter("NgayIn", DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
                    };

                    reportViewer1.LocalReport.SetParameters(parameters);

                    // Thiết lập DataSource
                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rds = new ReportDataSource("dsDoanhThu", reportData);
                    reportViewer1.LocalReport.DataSources.Add(rds);

                    reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 100;
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
