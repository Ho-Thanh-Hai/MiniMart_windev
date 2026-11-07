using MiniMart_windev.Helpers;
using DanhMuc = MiniMart_windev.Models.DanhMuc;
using MiniMart_windev.Models;
using QuanLyBanHangKhoDataContext = MiniMart_windev.Models.MiniMartDBDataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMart_windev.Forms.DanhMuc
{
    using DanhMuc = MiniMart_windev.Models.DanhMuc;
    public partial class frmCategoryManagement : Form
    {
        private QuanLyBanHangKhoDataContext db = new QuanLyBanHangKhoDataContext();

        public frmCategoryManagement()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
            LoadDanhMuc();
        }

        private void LoadDanhMuc()
        {
            dgvDanhMuc.DataSource = db.GetTable<DanhMuc>()
                .Select(dm => new
                {
                    dm.MaDanhMuc,
                    dm.TenDanhMuc,
                    dm.MoTa
                })
                .ToList();
            dgvDanhMuc.Columns["MaDanhMuc"].HeaderText = "Mã danh mục";
            dgvDanhMuc.Columns["TenDanhMuc"].HeaderText = "Tên danh mục";
            dgvDanhMuc.Columns["MoTa"].HeaderText = "Mô tả";
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ten = txtTenDanhMuc.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (ten == "" && moTa == "")
            {
                MessageBox.Show("Vui lòng nhập tên danh mục hoặc mô tả cần tìm!");
                return;
            }

            var ketQua = db.GetTable<DanhMuc>()
                .Where(dm =>
                    (ten == "" || dm.TenDanhMuc.Contains(ten)) &&
                    (moTa == "" || (dm.MoTa != null && dm.MoTa.Contains(moTa)))
                )
                .Select(dm => new
                {
                    dm.MaDanhMuc,
                    dm.TenDanhMuc,
                    dm.MoTa
                })
                .ToList();

            dgvDanhMuc.DataSource = ketQua;

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy danh mục phù hợp!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenDanhMuc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!");
                txtTenDanhMuc.Focus();
                return;
            }

            DanhMuc dm = new DanhMuc();
            dm.TenDanhMuc = txtTenDanhMuc.Text.Trim();
            dm.MoTa = txtMoTa.Text.Trim();

            db.GetTable<DanhMuc>().InsertOnSubmit(dm);
            db.SubmitChanges();

            MessageBox.Show("Thêm danh mục thành công!");

            LoadDanhMuc();
            txtTenDanhMuc.Clear();
            txtMoTa.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDanhMuc.Text == "")
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!");
                return;
            }

            if (txtTenDanhMuc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!");
                txtTenDanhMuc.Focus();
                return;
            }

            int ma = int.Parse(txtMaDanhMuc.Text);

            var dm = db.GetTable<DanhMuc>()
                       .FirstOrDefault(x => x.MaDanhMuc == ma);

            if (dm != null)
            {
                dm.TenDanhMuc = txtTenDanhMuc.Text.Trim();
                dm.MoTa = txtMoTa.Text.Trim();

                db.SubmitChanges();

                MessageBox.Show("Cập nhật danh mục thành công!");
                LoadDanhMuc();
            }
            else
            {
                MessageBox.Show("Không tìm thấy danh mục!");
            }
        }

        private void dgvDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhMuc.CurrentRow != null)
            {
                txtMaDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["MaDanhMuc"].Value.ToString();
                txtTenDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["TenDanhMuc"].Value.ToString();
                txtMoTa.Text = dgvDanhMuc.CurrentRow.Cells["MoTa"].Value?.ToString();
            }
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaDanhMuc.Text = dgvDanhMuc.Rows[e.RowIndex].Cells["MaDanhMuc"].Value.ToString();
                txtTenDanhMuc.Text = dgvDanhMuc.Rows[e.RowIndex].Cells["TenDanhMuc"].Value.ToString();
                txtMoTa.Text = dgvDanhMuc.Rows[e.RowIndex].Cells["MoTa"].Value?.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDanhMuc.Text == "")
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa danh mục này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int ma = int.Parse(txtMaDanhMuc.Text);

                var dm = db.GetTable<DanhMuc>()
                           .FirstOrDefault(x => x.MaDanhMuc == ma);

                if (dm != null)
                {
                    bool coSanPham = db.GetTable<SanPham>()
                        .Any(sp => sp.MaDanhMuc == ma);

                    if (coSanPham)
                    {
                        MessageBox.Show("Không thể xóa danh mục này vì đang có sản phẩm sử dụng!");
                        return;
                    }

                    db.GetTable<DanhMuc>().DeleteOnSubmit(dm);
                    db.SubmitChanges();

                    MessageBox.Show("Xóa danh mục thành công!");

                    LoadDanhMuc();
                    txtMaDanhMuc.Clear();
                    txtTenDanhMuc.Clear();
                    txtMoTa.Clear();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDanhMuc.Clear();
            txtTenDanhMuc.Clear();
            txtMoTa.Clear();

            dgvDanhMuc.ClearSelection();
            txtTenDanhMuc.Focus();

            LoadDanhMuc();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (ActiveControl == txtTenDanhMuc)
                {
                    txtMoTa.Focus();
                    return true;
                }
                else if (ActiveControl == txtMoTa)
                {
                    btnThem.Focus();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
