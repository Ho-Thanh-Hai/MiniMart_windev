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
            SetupGrid();
            SetupChart();
            LoadStatistics();
        }

        private void SetupChart()
        {
            chartTopProducts.Series.Clear();
            chartTopProducts.Titles.Clear();

            var title = chartTopProducts.Titles.Add("BIỂU ĐỒ TOP SẢN PHẨM BÁN CHẠY NHẤT");
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
            chartTopProducts.ChartAreas[0].AxisY.Title = "Số lượng";
            chartTopProducts.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void SetupGrid()
        {
            dgvTopProducts.AutoGenerateColumns = false;
        }

        private void cboTopCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            try
            {
                int topCount = 5;
                if (cboTopCount.SelectedIndex == 1) topCount = 10;
                else if (cboTopCount.SelectedIndex == 2) topCount = 15;
                else if (cboTopCount.SelectedIndex == 3) topCount = int.MaxValue;

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
                            Rank = rank++,
                            r.MaSanPham,
                            TenSanPham = ten,
                            r.TotalQuantity,
                            TotalRevenueFormat = r.TotalRevenue.ToString("N0") + " đ"
                        };
                    }).ToList();

                    dgvTopProducts.DataSource = finalData;

                    // Vẽ biểu đồ
                    chartTopProducts.Series["Số lượng bán"].Points.Clear();
                    foreach (var item in finalData)
                    {
                        string shortName = item.TenSanPham.Length > 15 ? 
                                           item.TenSanPham.Substring(0, 12) + "..." : item.TenSanPham;
                        chartTopProducts.Series["Số lượng bán"].Points.AddXY(shortName, item.TotalQuantity);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTopProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}