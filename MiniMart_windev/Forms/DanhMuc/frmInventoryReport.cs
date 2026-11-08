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
using Microsoft.Reporting.WinForms;

namespace MiniMart_windev.Forms.DanhMuc
{
    public partial class frmInventoryReport : Form
    {
        private QuanLyBanHangKhoDataContext db;
        private int? maDanhMuc = null;
        private string tenDanhMuc = "";

        public frmInventoryReport()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && !DesignMode)
            {
                ThemeHelper.SetupFormThemeAndNavigation(this);
            }
        }

        public frmInventoryReport(int maDanhMuc, string tenDanhMuc) : this()
        {
            this.maDanhMuc = maDanhMuc;
            this.tenDanhMuc = tenDanhMuc;
        }

        private void frmInventoryReport_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
            {
                return;
            }

            try
            {
                if (db == null)
                {
                    db = new QuanLyBanHangKhoDataContext();
                }

                if (string.IsNullOrEmpty(reportViewer1.LocalReport.ReportEmbeddedResource))
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyBanHangKho.rptInventory.rdlc";
                }

                var query = db.SanPhams.AsQueryable();

                if (maDanhMuc.HasValue)
                {
                    int maDM = maDanhMuc.Value;
                    query = query.Where(sp => sp.MaDanhMuc == maDM);
                }

                var ds = query
                    .Select(sp => new
                    {
                        sp.MaSanPham,
                        sp.TenSanPham,
                        DanhMuc = sp.DanhMuc.TenDanhMuc,
                        NhaCungCap = sp.NhaCungCap.TenNCC,
                        sp.DonGia,
                        sp.SoLuongTon
                    })
                    .ToList();

                reportViewer1.LocalReport.SetParameters(
                    new ReportParameter("TenDanhMuc", tenDanhMuc ?? "")
                );

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("dsSanPham", ds)
                );

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo tồn kho: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
