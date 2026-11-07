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
        private QuanLyBanHangKhoDataContext db = new QuanLyBanHangKhoDataContext();

        private int? maDanhMuc = null;

        private string tenDanhMuc = "";
        public frmInventoryReport()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
        }

        public frmInventoryReport(int maDanhMuc, string tenDanhMuc) : this()
        {
            this.maDanhMuc = maDanhMuc;
            this.tenDanhMuc = tenDanhMuc;
        }

        private void frmInventoryReport_Load(object sender, EventArgs e)
        {
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
                new ReportParameter("TenDanhMuc", tenDanhMuc)
            );
            

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("dsSanPham", ds)
            );

            reportViewer1.RefreshReport();
        }
    }
}
