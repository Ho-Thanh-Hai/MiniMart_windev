using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniMart_windev.Forms.NghiepVu;
using MiniMart_windev.Helpers;
using MiniMart_windev.Models;

namespace MiniMart_windev.Forms.BaoCao
{
    public partial class frmRevenueReport : Form
    {
        public frmRevenueReport()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
        }

        private void frmRevenueReport_Load(object sender, EventArgs e)
        {
            SetupGrid();

            // Mặc định từ đầu tháng đến hiện tại
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;

            LoadRevenueData();
        }

        private void SetupGrid()
        {
            dgvDoanhThu.AutoGenerateColumns = false;
        }

        private void LoadRevenueData()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Từ ngày không thể lớn hơn đến ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var db = new MiniMartDBDataContext())
                {
                    var query = from hd in db.HoaDons
                                where hd.NgayLap >= tuNgay && hd.NgayLap <= denNgay
                                orderby hd.NgayLap descending
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

                    // Cập nhật thẻ KPI
                    int count = list.Count;
                    decimal totalRevenue = list.Sum(x => x.ThanhTien);
                    decimal avgRevenue = count > 0 ? (totalRevenue / count) : 0;

                    lblTongSoHD.Text = count.ToString("N0");
                    lblTongDoanhThu.Text = totalRevenue.ToString("N0") + " VNĐ";
                    lblGiaTriTrungBinh.Text = avgRevenue.ToString("N0") + " VNĐ";

                    int stt = 1;
                    var gridData = list.Select(x => new
                    {
                        STT = stt++,
                        MaHoaDon = "HD" + x.MaHoaDon.ToString("D5"),
                        NgayLap = x.NgayLap.HasValue ? x.NgayLap.Value.ToString("dd/MM/yyyy HH:mm") : "",
                        x.TenThuNgan,
                        x.TenKhachHang,
                        TongTien = x.TongTien.ToString("N0") + " VNĐ",
                        GiamGia = x.GiamGia.ToString("N0") + " VNĐ",
                        ThanhTien = x.ThanhTien.ToString("N0") + " VNĐ"
                    }).ToList();

                    dgvDoanhThu.DataSource = gridData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadRevenueData();
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Từ ngày không thể lớn hơn đến ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmRevenuePrint frm = new frmRevenuePrint(tuNgay, denNgay);
            frm.ShowDialog();
        }

        private void dgvDoanhThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
