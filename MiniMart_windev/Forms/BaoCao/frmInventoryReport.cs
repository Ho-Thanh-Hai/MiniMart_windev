using MiniMart_windev.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MiniMart_windev.Models;

namespace MiniMart_windev.Forms.BaoCao
{
    public partial class frmInventoryReport : Form
    {
        public frmInventoryReport()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
        }

        private void frmInventoryReport_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadCategories();
            LoadInventoryData();
        }

        private void SetupGrid()
        {
            dgvTonKho.AutoGenerateColumns = false;
        }

        private void LoadCategories()
        {
            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    var cats = db.DanhMucs.OrderBy(c => c.TenDanhMuc).ToList();
                    cats.Insert(0, new MiniMart_windev.Models.DanhMuc { MaDanhMuc = 0, TenDanhMuc = "-- Tất cả danh mục --" });

                    cboDanhMuc.DataSource = cats;
                    cboDanhMuc.DisplayMember = "TenDanhMuc";
                    cboDanhMuc.ValueMember = "MaDanhMuc";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadInventoryData();
        }

        private void chkCanhBaoSapHet_CheckedChanged(object sender, EventArgs e)
        {
            LoadInventoryData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadInventoryData();
        }

        private void LoadInventoryData()
        {
            try
            {
                int selectedCategory = 0;
                if (cboDanhMuc.SelectedValue != null && int.TryParse(cboDanhMuc.SelectedValue.ToString(), out int cId))
                {
                    selectedCategory = cId;
                }

                bool onlyLowStock = chkCanhBaoSapHet.Checked;
                int threshold = (int)numNguongTon.Value;
                string keyword = txtTimKiem.Text.Trim().ToLower();

                using (var db = new MiniMartDBDataContext())
                {
                    var query = from sp in db.SanPhams
                                join dm in db.DanhMucs on sp.MaDanhMuc equals dm.MaDanhMuc into dmGroup
                                from dm in dmGroup.DefaultIfEmpty()
                                select new
                                {
                                    sp.MaSanPham,
                                    sp.TenSanPham,
                                    sp.MaDanhMuc,
                                    TenDanhMuc = dm != null ? dm.TenDanhMuc : "Chưa phân loại",
                                    sp.DonGia,
                                    SoLuongTon = sp.SoLuongTon ?? 0
                                };

                    if (selectedCategory > 0)
                    {
                        query = query.Where(x => x.MaDanhMuc == selectedCategory);
                    }

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        query = query.Where(x => x.MaSanPham.ToLower().Contains(keyword) || x.TenSanPham.ToLower().Contains(keyword));
                    }

                    var allList = query.ToList();

                    // Cập nhật thẻ KPI
                    lblTongMatHang.Text = allList.Count.ToString("N0");
                    lblTongTonKho.Text = allList.Sum(x => x.SoLuongTon).ToString("N0");
                    lblCanhBao.Text = allList.Count(x => x.SoLuongTon <= threshold).ToString("N0");

                    // Nếu người dùng chọn xem các SP sắp hết
                    var displayList = allList;
                    if (onlyLowStock)
                    {
                        displayList = displayList.Where(x => x.SoLuongTon <= threshold).ToList();
                    }

                    int stt = 1;
                    var gridData = displayList.Select(x => new
                    {
                        STT = stt++,
                        x.MaSanPham,
                        x.TenSanPham,
                        x.TenDanhMuc,
                        DonGiaFormat = x.DonGia.ToString("N0") + " đ",
                        x.SoLuongTon,
                        TinhTrang = x.SoLuongTon <= threshold ? "⚠ Sắp hết hàng" : "✔ Còn hàng"
                    }).ToList();

                    dgvTonKho.DataSource = gridData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo tồn kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTonKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}