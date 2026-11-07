using MiniMart_windev.Helpers;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiniMart_windev.Forms.HeThong
{
    public partial class frmConnectionConfig : Form
    {
        public frmConnectionConfig()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);
        }

        private void frmConnectionConfig_Load(object sender, EventArgs e)
        {
            try
            {
                // Đọc chuỗi kết nối hiện tại từ DatabaseHelper hoặc App.config
                string connStr = DatabaseHelper.ActiveConnectionString;
                if (!string.IsNullOrEmpty(connStr))
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connStr);
                    txtServer.Text = builder.DataSource;
                    cboDatabase.Text = builder.InitialCatalog;

                    if (builder.IntegratedSecurity)
                    {
                        rdoWindowsAuth.Checked = true;
                    }
                    else
                    {
                        rdoSqlAuth.Checked = true;
                        txtTaiKhoan.Text = builder.UserID;
                        txtMatKhau.Text = builder.Password;
                    }
                }
            }
            catch { }
        }

        private void rdoWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            bool isSqlAuth = rdoSqlAuth.Checked;
            txtTaiKhoan.Enabled = isSqlAuth;
            txtMatKhau.Enabled = isSqlAuth;
        }

        private string BuildConnectionString(bool includeDatabase = true)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = txtServer.Text.Trim();
            if (includeDatabase && !string.IsNullOrEmpty(cboDatabase.Text))
            {
                builder.InitialCatalog = cboDatabase.Text.Trim();
            }

            if (rdoWindowsAuth.Checked)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = txtTaiKhoan.Text.Trim();
                builder.Password = txtMatKhau.Text;
            }

            builder.TrustServerCertificate = true;
            builder.Encrypt = false;
            return builder.ConnectionString;
        }

        private void btnLayDanhSachDB_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text.Trim();
            if (string.IsNullOrEmpty(server))
            {
                MessageBox.Show("Vui lòng nhập Server name!", "Cảnh báo");
                return;
            }

            try
            {
                string connStr = BuildConnectionString(false);
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4 ORDER BY name", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    cboDatabase.Items.Clear();
                    while (reader.Read())
                    {
                        cboDatabase.Items.Add(reader["name"].ToString());
                    }
                    if (cboDatabase.Items.Count > 0)
                    {
                        cboDatabase.SelectedIndex = 0;
                        MessageBox.Show("Tải danh sách CSDL thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lấy danh sách database: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKiemTraKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = BuildConnectionString(true);
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    MessageBox.Show("Kết nối máy chủ SQL Server thành công 100%!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại!\nChi tiết: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuCauHinh_Click(object sender, EventArgs e)
        {
            string newConnStr = BuildConnectionString(true);

            try
            {
                // Cập nhật vào App.config thực tế của ứng dụng
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var section = config.ConnectionStrings;
                string key = "MiniMart_windev.Properties.Settings.QuanLySieuThiMiniConnectionString";

                if (section.ConnectionStrings[key] != null)
                {
                    section.ConnectionStrings[key].ConnectionString = newConnStr;
                }
                else
                {
                    section.ConnectionStrings.Add(new ConnectionStringSettings(key, newConnStr, "System.Data.SqlClient"));
                }

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                // Cập nhật DatabaseHelper cho phiên chạy hiện tại ngay lập tức
                DatabaseHelper.ActiveConnectionString = newConnStr;

                try
                {
                    MiniMart_windev.Properties.Settings.Default["QuanLySieuThiMiniConnectionString"] = newConnStr;
                    MiniMart_windev.Properties.Settings.Default.Save();
                }
                catch
                {
                    // Properties.Settings có thể ở chế độ ReadOnly tại runtime, bỏ qua vì đã lưu App.config và DatabaseHelper
                }

                MessageBox.Show("Đã lưu cấu hình kết nối thành công!\nỨng dụng sẽ sử dụng cấu hình mới này ngay lập tức.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
