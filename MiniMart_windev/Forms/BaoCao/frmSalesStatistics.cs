using MiniMart_windev.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MiniMart_windev.Models;

namespace MiniMart_windev.Forms.BaoCao
{
    public partial class frmSalesStatistics : Form
    {
        public frmSalesStatistics()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
        }

        private void frmSalesStatistics_Load(object sender, EventArgs e)
        {
            cboTopCount.SelectedIndex = 0; // Top 5
            cboChartType.SelectedIndex = 0; // Biểu đồ Cột mặc định
            SetupGrid();
            LoadStatistics();
        }

        private void SetupGrid()
        {
            dgvTopProducts.AutoGenerateColumns = true;
        }

        private void cboTopCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void cboChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu chọn biểu đồ 12 tháng hoặc danh mục thì ẩn chọn top count cho hợp lý
            cboTopCount.Enabled = (cboChartType.SelectedIndex == 0);
            LoadStatistics();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            int chartMode = cboChartType.SelectedIndex;
            if (chartMode == 0)
            {
                LoadColumnChartTopProducts();
            }
            else if (chartMode == 1)
            {
                LoadLineChartMonthlyRevenue();
            }
            else if (chartMode == 2)
            {
                LoadPieChartCategoryRevenue();
            }
        }

        /// <summary>
        /// 1. Biểu đồ Cột (Column Chart): Top sản phẩm bán chạy nhất trong tháng / hệ thống
        /// </summary>
        private void LoadColumnChartTopProducts()
        {
            try
            {
                int topCount = 5;
                if (cboTopCount.SelectedIndex == 1) topCount = 10;
                else if (cboTopCount.SelectedIndex == 2) topCount = 15;
                else if (cboTopCount.SelectedIndex == 3) topCount = int.MaxValue;

                chartTopProducts.Series.Clear();
                chartTopProducts.Titles.Clear();
                chartTopProducts.Legends.Clear();

                var title = chartTopProducts.Titles.Add($"BIỂU ĐỒ CỘT: TOP {topCount} SẢN PHẨM BÁN CHẠY NHẤT");
                title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                title.ForeColor = Color.FromArgb(0, 122, 204);

                Series series = new Series("Số lượng bán")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Color = Color.FromArgb(52, 152, 219)
                };
                chartTopProducts.Series.Add(series);

                chartTopProducts.ChartAreas[0].AxisX.Interval = 1;
                chartTopProducts.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8.5F);
                chartTopProducts.ChartAreas[0].AxisX.Title = "Tên sản phẩm";
                chartTopProducts.ChartAreas[0].AxisY.Title = "Số lượng bán";
                chartTopProducts.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);

                using (var db = new MiniMartDBDataContext())
                {
                    var rawList = (from ct in db.ChiTietHoaDons
                                   group ct by ct.MaSanPham into g
                                   select new
                                   {
                                       MaSanPham = g.Key,
                                       TotalQuantity = g.Sum(x => x.SoLuong),
                                       TotalRevenue = g.Sum(x => x.ThanhTien)
                                   })
                                   .OrderByDescending(x => x.TotalQuantity)
                                   .Take(topCount)
                                   .ToList();

                    var productIds = rawList.Select(r => r.MaSanPham).ToList();
                    var spDict = db.SanPhams
                                   .Where(s => productIds.Contains(s.MaSanPham))
                                   .ToDictionary(s => s.MaSanPham, s => s);

                    int rank = 1;
                    var finalData = rawList.Select(r =>
                    {
                        string ten = r.MaSanPham;
                        if (spDict.TryGetValue(r.MaSanPham, out var sp))
                        {
                            ten = sp.TenSanPham;
                        }

                        return new
                        {
                            Thứ_Hạng = rank++,
                            Mã_SP = r.MaSanPham,
                            Tên_Sản_Phẩm = ten,
                            Số_Lượng_Bán = r.TotalQuantity,
                            Tổng_Doanh_Thu = r.TotalRevenue.ToString("N0") + " đ"
                        };
                    }).ToList();

                    dgvTopProducts.DataSource = finalData;

                    foreach (var item in finalData)
                    {
                        string shortName = item.Tên_Sản_Phẩm.Length > 15 ? 
                                           item.Tên_Sản_Phẩm.Substring(0, 12) + "..." : item.Tên_Sản_Phẩm;
                        series.Points.AddXY(shortName, item.Số_Lượng_Bán);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ cột: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 2. Biểu đồ Đường (Line Chart): Xu hướng Doanh thu các tháng trong năm (LINQ GroupBy Month)
        /// </summary>
        private void LoadLineChartMonthlyRevenue()
        {
            try
            {
                chartTopProducts.Series.Clear();
                chartTopProducts.Titles.Clear();
                chartTopProducts.Legends.Clear();

                int currentYear = DateTime.Now.Year;
                var title = chartTopProducts.Titles.Add($"BIỂU ĐỒ ĐƯỜNG: XU HƯỚNG DOANH THU 12 THÁNG NĂM {currentYear}");
                title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                title.ForeColor = Color.FromArgb(46, 204, 113);

                Series series = new Series("Doanh thu (VNĐ)")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 8,
                    MarkerColor = Color.FromArgb(231, 76, 60),
                    IsValueShownAsLabel = true,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    Color = Color.FromArgb(46, 204, 113)
                };
                chartTopProducts.Series.Add(series);

                chartTopProducts.ChartAreas[0].AxisX.Interval = 1;
                chartTopProducts.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8.5F);
                chartTopProducts.ChartAreas[0].AxisX.Title = "Tháng trong năm";
                chartTopProducts.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
                chartTopProducts.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);

                using (var db = new MiniMartDBDataContext())
                {
                    var monthlyData = (from hd in db.HoaDons
                                       where hd.NgayLap != null && hd.NgayLap.Value.Year == currentYear
                                       group hd by hd.NgayLap.Value.Month into g
                                       select new
                                       {
                                           Thang = g.Key,
                                           DoanhThu = g.Sum(x => x.ThanhTien),
                                           SoDonHang = g.Count()
                                       })
                                       .OrderBy(x => x.Thang)
                                       .ToList();

                    // Chuẩn bị 12 tháng đầy đủ
                    var fullMonths = Enumerable.Range(1, 12).Select(m =>
                    {
                        var found = monthlyData.FirstOrDefault(x => x.Thang == m);
                        return new
                        {
                            Tháng = $"Tháng {m}",
                            Số_Lượng_Đơn = found != null ? found.SoDonHang : 0,
                            Doanh_Thu_So = (found != null && found.DoanhThu.HasValue) ? found.DoanhThu.Value : 0m,
                            Doanh_Thu = ((found != null && found.DoanhThu.HasValue) ? found.DoanhThu.Value : 0m).ToString("N0") + " đ"
                        };
                    }).ToList();

                    dgvTopProducts.DataSource = fullMonths.Select(x => new
                    {
                        x.Tháng,
                        x.Số_Lượng_Đơn,
                        x.Doanh_Thu
                    }).ToList();

                    foreach (var m in fullMonths)
                    {
                        var pt = series.Points.AddXY(m.Tháng, (double)m.Doanh_Thu_So);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ đường: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 3. Biểu đồ Tròn (Pie / Doughnut Chart): Tỷ lệ doanh thu theo Danh mục hàng hóa (LINQ GroupBy Category)
        /// </summary>
        private void LoadPieChartCategoryRevenue()
        {
            try
            {
                chartTopProducts.Series.Clear();
                chartTopProducts.Titles.Clear();
                chartTopProducts.Legends.Clear();

                var title = chartTopProducts.Titles.Add("BIỂU ĐỒ TRÒN: TỶ LỆ DOANH THU THEO DANH MỤC HÀNG HÓA");
                title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                title.ForeColor = Color.FromArgb(142, 68, 173);

                Legend legend = new Legend("DanhMucLegend")
                {
                    Docking = Docking.Right,
                    Font = new Font("Segoe UI", 9F)
                };
                chartTopProducts.Legends.Add(legend);

                Series series = new Series("Tỷ lệ doanh thu")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
                };
                series["PieLabelStyle"] = "Outside";
                chartTopProducts.Series.Add(series);

                using (var db = new MiniMartDBDataContext())
                {
                    var catData = (from ct in db.ChiTietHoaDons
                                   join sp in db.SanPhams on ct.MaSanPham equals sp.MaSanPham
                                   join dm in db.DanhMucs on sp.MaDanhMuc equals dm.MaDanhMuc
                                   group ct by dm.TenDanhMuc into g
                                   select new
                                   {
                                       TenDanhMuc = g.Key,
                                       DoanhThu = g.Sum(x => x.ThanhTien),
                                       SoLuongBan = g.Sum(x => x.SoLuong)
                                   })
                                   .OrderByDescending(x => x.DoanhThu)
                                   .ToList();

                    var gridList = catData.Select(c => new
                    {
                        Danh_Mục = c.TenDanhMuc,
                        Số_Lượng_Bán = c.SoLuongBan,
                        Doanh_Thu_So = c.DoanhThu,
                        Doanh_Thu = c.DoanhThu.ToString("N0") + " đ"
                    }).ToList();

                    dgvTopProducts.DataSource = gridList.Select(x => new
                    {
                        x.Danh_Mục,
                        x.Số_Lượng_Bán,
                        x.Doanh_Thu
                    }).ToList();

                    decimal tongDoanhThu = catData.Sum(x => x.DoanhThu);
                    if (tongDoanhThu <= 0) tongDoanhThu = 1;

                    foreach (var c in catData)
                    {
                        double percent = (double)(c.DoanhThu / tongDoanhThu * 100);
                        int ptIdx = series.Points.AddXY(c.TenDanhMuc, (double)c.DoanhThu);
                        series.Points[ptIdx].LegendText = $"{c.TenDanhMuc} ({percent:F1}%)";
                        series.Points[ptIdx].Label = $"{percent:F1}%";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ tròn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string chartName = cboChartType.Text;
            ExcelExportHelper.ExportDataGridViewToExcel(
                dgvTopProducts, 
                $"ThongKe_DoanhThu_{DateTime.Now:yyyyMMdd_HHmmss}", 
                $"BÁO CÁO THỐNG KÊ DOANH THU & BÁN HÀNG - {chartName.ToUpper()}");
        }

        private void dgvTopProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
