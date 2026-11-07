using MiniMart_windev.Helpers;
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
    public partial class frmSupplierManagement : Form
    {
        private QuanLyBanHangKhoDataContext db = new QuanLyBanHangKhoDataContext();

        public frmSupplierManagement()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
            KeyPreview = true;
            LoadNhaCungCap();
        }

        private void LoadNhaCungCap()
        {
            dgvNhaCungCap.DataSource = db.GetTable<NhaCungCap>()
                .Select(ncc => new
                {
                    ncc.MaNCC,
                    ncc.TenNCC,
                    ncc.DiaChi,
                    ncc.SoDienThoai,
                    ncc.Email
                })
                .ToList();

            dgvNhaCungCap.Columns["MaNCC"].HeaderText = "Mã nhà cung cấp";
            dgvNhaCungCap.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            dgvNhaCungCap.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvNhaCungCap.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvNhaCungCap.Columns["Email"].HeaderText = "Email";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp!");
                txtTenNCC.Focus();
                return;
            }

            NhaCungCap ncc = new NhaCungCap();

            ncc.TenNCC = txtTenNCC.Text.Trim();
            ncc.DiaChi = txtDiaChi.Text.Trim();
            ncc.SoDienThoai = txtSoDienThoai.Text.Trim();
            ncc.Email = txtEmail.Text.Trim();

            db.GetTable<NhaCungCap>().InsertOnSubmit(ncc);
            db.SubmitChanges();

            MessageBox.Show("Thêm nhà cung cấp thành công!");

            LoadNhaCungCap();

            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!");
                return;
            }

            if (txtTenNCC.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp!");
                txtTenNCC.Focus();
                return;
            }

            int ma = int.Parse(txtMaNCC.Text);

            var ncc = db.GetTable<NhaCungCap>()
                        .FirstOrDefault(x => x.MaNCC == ma);

            if (ncc != null)
            {
                ncc.TenNCC = txtTenNCC.Text.Trim();
                ncc.DiaChi = txtDiaChi.Text.Trim();
                ncc.SoDienThoai = txtSoDienThoai.Text.Trim();
                ncc.Email = txtEmail.Text.Trim();

                db.SubmitChanges();

                MessageBox.Show("Cập nhật nhà cung cấp thành công!");

                LoadNhaCungCap();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa nhà cung cấp này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int ma = int.Parse(txtMaNCC.Text);

                var ncc = db.GetTable<NhaCungCap>()
                            .FirstOrDefault(x => x.MaNCC == ma);

                if (ncc != null)
                {
                    db.GetTable<NhaCungCap>().DeleteOnSubmit(ncc);
                    db.SubmitChanges();

                    MessageBox.Show("Xóa nhà cung cấp thành công!");

                    LoadNhaCungCap();

                    txtMaNCC.Clear();
                    txtTenNCC.Clear();
                    txtDiaChi.Clear();
                    txtSoDienThoai.Clear();
                    txtEmail.Clear();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();

            dgvNhaCungCap.ClearSelection();

            txtTenNCC.Focus();

            LoadNhaCungCap();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ten = txtTenNCC.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (ten == "" && diaChi == "" && sdt == "" && email == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!");
                return;
            }

            var ketQua = db.GetTable<NhaCungCap>()
                .Where(ncc =>
                    (ten == "" || ncc.TenNCC.Contains(ten)) &&
                    (diaChi == "" || (ncc.DiaChi != null && ncc.DiaChi.Contains(diaChi))) &&
                    (sdt == "" || (ncc.SoDienThoai != null && ncc.SoDienThoai.Contains(sdt))) &&
                    (email == "" || (ncc.Email != null && ncc.Email.Contains(email)))
                )
                .Select(ncc => new
                {
                    ncc.MaNCC,
                    ncc.TenNCC,
                    ncc.DiaChi,
                    ncc.SoDienThoai,
                    ncc.Email
                })
                .ToList();

            dgvNhaCungCap.DataSource = ketQua;

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp phù hợp!");
            }
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNCC.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();

                txtTenNCC.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["TenNCC"].Value.ToString();

                txtDiaChi.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["DiaChi"].Value?.ToString();

                txtSoDienThoai.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["SoDienThoai"].Value?.ToString();

                txtEmail.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["Email"].Value?.ToString();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (ActiveControl == txtTenNCC)
                    txtDiaChi.Focus();
                else if (ActiveControl == txtDiaChi)
                    txtSoDienThoai.Focus();
                else if (ActiveControl == txtSoDienThoai)
                    txtEmail.Focus();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}