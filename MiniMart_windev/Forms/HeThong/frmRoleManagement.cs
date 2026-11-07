using MiniMart_windev.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using MiniMart_windev.Models;

namespace MiniMart_windev.Forms.HeThong
{
    public partial class frmRoleManagement : Form
    {
        public frmRoleManagement()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
        }

        private void frmRoleManagement_Load(object sender, EventArgs e)
        {
            LoadVaiTro();
        }

        private void LoadVaiTro()
        {
            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    var roles = db.VaiTros.ToList();
                    cboVaiTro.DataSource = roles;
                    cboVaiTro.DisplayMember = "TenVaiTro";
                    cboVaiTro.ValueMember = "MaVaiTro";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải vai trò: " + ex.Message);
            }
        }

        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVaiTro.SelectedValue != null && int.TryParse(cboVaiTro.SelectedValue.ToString(), out int maVT))
            {
                LoadPhanQuyen(maVT);
            }
        }

        private void LoadPhanQuyen(int maVT)
        {
            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    // Lấy danh sách tất cả chức năng và trạng thái quyền của vai trò hiện tại
                    var list = (from cn in db.ChucNangs
                                join pq in db.PhanQuyens.Where(p => p.MaVaiTro == maVT)
                                on cn.MaChucNang equals pq.MaChucNang into g
                                from sub in g.DefaultIfEmpty()
                                select new
                                {
                                    cn.MaChucNang,
                                    cn.TenChucNang,
                                    cn.MoTa,
                                    DuocPhep = sub != null ? (sub.DuocPhep ?? false) : false
                                }).ToList();

                    // Chuyển sang DataTable để hiển thị cột checkbox có thể sửa được
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MaChucNang", typeof(string));
                    dt.Columns.Add("TenChucNang", typeof(string));
                    dt.Columns.Add("MoTa", typeof(string));
                    dt.Columns.Add("DuocPhep", typeof(bool));

                    foreach (var item in list)
                    {
                        dt.Rows.Add(item.MaChucNang, item.TenChucNang, item.MoTa, item.DuocPhep);
                    }

                    dgvPhanQuyen.AutoGenerateColumns = false;
                    dgvPhanQuyen.AutoGenerateColumns = false;
                    dgvPhanQuyen.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phân quyền: " + ex.Message);
            }
        }

        private void btnLuuPhanQuyen_Click(object sender, EventArgs e)
        {
            if (cboVaiTro.SelectedValue == null) return;
            int maVT = Convert.ToInt32(cboVaiTro.SelectedValue);

            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    // Xóa các quyền cũ của vai trò này
                    var oldPqs = db.PhanQuyens.Where(p => p.MaVaiTro == maVT);
                    db.PhanQuyens.DeleteAllOnSubmit(oldPqs);
                    db.SubmitChanges();

                    // Thêm quyền mới từ DataGridView
                    foreach (DataGridViewRow row in dgvPhanQuyen.Rows)
                    {
                        string maCN = row.Cells["MaChucNang"].Value.ToString();
                        bool duocPhep = Convert.ToBoolean(row.Cells["DuocPhep"].Value);

                        PhanQuyen pq = new PhanQuyen
                        {
                            MaVaiTro = maVT,
                            MaChucNang = maCN,
                            DuocPhep = duocPhep
                        };
                        db.PhanQuyens.InsertOnSubmit(pq);
                    }

                    db.SubmitChanges();
                    MessageBox.Show("Lưu cấu hình phân quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu phân quyền: " + ex.Message);
            }
        }

        private void btnThemVaiTro_Click(object sender, EventArgs e)
        {
            string roleName = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên vai trò mới:", "Thêm vai trò", "");
            if (!string.IsNullOrWhiteSpace(roleName))
            {
                try
                {
                    using (var db = new MiniMartDBDataContext())
                    {
                        if (db.VaiTros.Any(v => v.TenVaiTro == roleName.Trim()))
                        {
                            MessageBox.Show("Tên vai trò này đã tồn tại!", "Cảnh báo");
                            return;
                        }

                        VaiTro vt = new VaiTro { TenVaiTro = roleName.Trim() };
                        db.VaiTros.InsertOnSubmit(vt);
                        db.SubmitChanges();

                        MessageBox.Show("Thêm vai trò thành công!", "Thông báo");
                        LoadVaiTro();
                        cboVaiTro.SelectedValue = vt.MaVaiTro;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm vai trò: " + ex.Message);
                }
            }
        }

        private void btnXoaVaiTro_Click(object sender, EventArgs e)
        {
            if (cboVaiTro.SelectedValue == null) return;
            int maVT = Convert.ToInt32(cboVaiTro.SelectedValue);

            if (maVT == 1) // Giả định MaVaiTro = 1 là Admin
            {
                MessageBox.Show("Không được phép xóa vai trò Quản trị viên tối cao!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa vai trò này? (Các người dùng thuộc vai trò này sẽ mất nhóm quyền)", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new MiniMartDBDataContext())
                    {
                        var vt = db.VaiTros.FirstOrDefault(v => v.MaVaiTro == maVT);
                        if (vt != null)
                        {
                            // Xóa phân quyền của vai trò này trước
                            var pqs = db.PhanQuyens.Where(p => p.MaVaiTro == maVT);
                            db.PhanQuyens.DeleteAllOnSubmit(pqs);

                            db.VaiTros.DeleteOnSubmit(vt);
                            db.SubmitChanges();

                            MessageBox.Show("Đã xóa vai trò thành công!", "Thông báo");
                            LoadVaiTro();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa vai trò: " + ex.Message);
                }
            }
        }
    }
}
