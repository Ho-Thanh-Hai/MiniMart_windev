using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && !DesignMode)
            {
                ThemeHelper.SetupFormThemeAndNavigation(this);
            }
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
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
            {
                return;
            }

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

                    DataTable dt = new DataTable("dsDoanhThu");
                    dt.Columns.Add("STT", typeof(int));
                    dt.Columns.Add("MaHoaDon", typeof(string));
                    dt.Columns.Add("NgayLap", typeof(string));
                    dt.Columns.Add("TenThuNgan", typeof(string));
                    dt.Columns.Add("TenKhachHang", typeof(string));
                    dt.Columns.Add("TongTien", typeof(decimal));
                    dt.Columns.Add("GiamGia", typeof(decimal));
                    dt.Columns.Add("ThanhTien", typeof(decimal));

                    int stt = 1;
                    foreach (var x in list)
                    {
                        dt.Rows.Add(
                            stt++,
                            "HD" + x.MaHoaDon.ToString("D5"),
                            x.NgayLap.HasValue ? x.NgayLap.Value.ToString("dd/MM/yyyy HH:mm") : "",
                            x.TenThuNgan ?? "",
                            x.TenKhachHang ?? "",
                            x.TongTien,
                            x.GiamGia,
                            x.ThanhTien
                        );
                    }

                    // Thiết lập parameters chuẩn xác với các tham số định nghĩa trong rptDoanhThu.rdlc:
                    // 1. TuNgay, 2. DenNgay, 3. NguoiLap, 4. NgayIn
                    string nguoiLap = !string.IsNullOrEmpty(CurrentUserSession.HoTen)
                        ? CurrentUserSession.HoTen
                        : "Quản trị viên";
                    string ngayIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                    reportViewer1.LocalReport.ReportEmbeddedResource = "MiniMart_windev.Forms.BaoCao.rptDoanhThu.rdlc";
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[]
                    {
                        new ReportParameter("TuNgay", _tuNgay.ToString("dd/MM/yyyy")),
                        new ReportParameter("DenNgay", _denNgay.ToString("dd/MM/yyyy")),
                        new ReportParameter("NguoiLap", nguoiLap),
                        new ReportParameter("NgayIn", ngayIn)
                    });

                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDoanhThu", dt));
                    reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 100;
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                {
                    msg += "\nChi tiết: " + ex.InnerException.Message;
                }
                MessageBox.Show("Lỗi hiển thị báo cáo: " + msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
