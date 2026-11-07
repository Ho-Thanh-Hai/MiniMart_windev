using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MiniMart_windev.Helpers
{
    public static class DatabaseHelper
    {
        private static string _activeConnectionString = null;

        public static string ActiveConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_activeConnectionString))
                {
                    try
                    {
                        var cs = ConfigurationManager.ConnectionStrings["MiniMart_windev.Properties.Settings.QuanLySieuThiMiniConnectionString"];
                        if (cs != null && !string.IsNullOrEmpty(cs.ConnectionString))
                        {
                            _activeConnectionString = cs.ConnectionString;
                        }
                    }
                    catch { }

                    if (string.IsNullOrEmpty(_activeConnectionString))
                    {
                        try
                        {
                            _activeConnectionString = Properties.Settings.Default.QuanLySieuThiMiniConnectionString;
                        }
                        catch { }
                    }
                }
                return _activeConnectionString;
            }
            set
            {
                _activeConnectionString = value;
            }
        }

        public static bool TestConnection(string connStr, int timeoutSeconds = 2)
        {
            if (string.IsNullOrEmpty(connStr)) return false;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connStr);
                builder.ConnectTimeout = timeoutSeconds;
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Tự động nhận diện SQL Server trên máy người dùng và tự khởi tạo CSDL lần đầu nếu chưa có.
        /// Giúp người khác tải repo về chỉ việc bấm Start (F5) là chạy luôn không cần cấu hình thủ công.
        /// </summary>
        public static bool EnsureDatabaseAutoSetup(out string statusMessage)
        {
            // 1. Nếu chuỗi kết nối hiện tại đã kết nối được và CSDL tồn tại -> Xong ngay lập tức
            if (TestConnection(ActiveConnectionString, 2))
            {
                statusMessage = "Kết nối CSDL sẵn sàng.";
                return true;
            }

            // 2. Danh sách các máy chủ SQL Server thông dụng trên các máy tính Windows/Visual Studio
            string[] candidateServers = new string[]
            {
                @".\MSSQLSERVER02",
                @".",
                @".\SQLEXPRESS",
                @"(localdb)\MSSQLLocalDB",
                @"localhost",
                @"127.0.0.1"
            };

            string workingServer = null;

            // Thử kết nối tới master của từng server với timeout ngắn (1.5 giây)
            foreach (var server in candidateServers)
            {
                string masterConn = $"Server={server};Database=master;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=2";
                if (TestConnection(masterConn, 2))
                {
                    workingServer = server;
                    break;
                }
            }

            if (string.IsNullOrEmpty(workingServer))
            {
                statusMessage = "Không tìm thấy máy chủ SQL Server nào đang hoạt động trên máy tính.";
                return false;
            }

            // 3. Kiểm tra xem database QuanLySieuThiMini đã tồn tại trên workingServer chưa
            bool dbExists = false;
            try
            {
                using (SqlConnection conn = new SqlConnection($"Server={workingServer};Database=master;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=3"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT database_id FROM sys.databases WHERE name = 'QuanLySieuThiMini'", conn))
                    {
                        var res = cmd.ExecuteScalar();
                        dbExists = (res != null && res != DBNull.Value);
                    }
                }
            }
            catch { }

            string targetConnStr = $"Data Source={workingServer};Initial Catalog=QuanLySieuThiMini;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

            // 4. Nếu chưa có database, tự động thực thi script tạo CSDL kèm dữ liệu mẫu
            if (!dbExists)
            {
                bool created = ExecuteSqlInitScript(workingServer, out string err);
                if (!created)
                {
                    statusMessage = $"Tìm thấy SQL Server ({workingServer}) nhưng không thể tự động tạo CSDL: {err}";
                    return false;
                }
            }

            // 5. Cập nhật chuỗi kết nối đang hoạt động và lưu vào App.config
            ActiveConnectionString = targetConnStr;
            SaveConnectionStringToConfig(targetConnStr);

            statusMessage = $"Đã tự động kết nối máy chủ SQL Server: {workingServer}" + (dbExists ? "" : " và khởi tạo CSDL thành công!");
            return true;
        }

        private static bool ExecuteSqlInitScript(string server, out string error)
        {
            error = null;
            string script = FindSqlScriptContent();

            if (string.IsNullOrEmpty(script))
            {
                error = "Không tìm thấy tệp kịch bản Database/QuanLySieuThiMini.sql!";
                return false;
            }

            try
            {
                // Tách script theo lệnh GO
                string[] batches = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                using (SqlConnection conn = new SqlConnection($"Server={server};Database=master;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=15"))
                {
                    conn.Open();
                    foreach (var rawBatch in batches)
                    {
                        string batch = rawBatch.Trim();
                        if (string.IsNullOrEmpty(batch)) continue;

                        using (SqlCommand cmd = new SqlCommand(batch, conn))
                        {
                            cmd.CommandTimeout = 60;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        private static string FindSqlScriptContent()
        {
            // 1. Thử đọc từ tài nguyên nhúng (Embedded Resource)
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (var stream = assembly.GetManifestResourceStream("QuanLySieuThiMini.sql"))
                {
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch { }

            // 2. Thử tìm tệp trên ổ đĩa từ thư mục chạy ứng dụng
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] possiblePaths = new string[]
            {
                Path.Combine(baseDir, @"Database\QuanLySieuThiMini.sql"),
                Path.Combine(baseDir, @"..\..\..\Database\QuanLySieuThiMini.sql"),
                Path.Combine(baseDir, @"..\..\Database\QuanLySieuThiMini.sql"),
                Path.Combine(baseDir, @"..\Database\QuanLySieuThiMini.sql")
            };

            foreach (var path in possiblePaths)
            {
                try
                {
                    string fullPath = Path.GetFullPath(path);
                    if (File.Exists(fullPath))
                    {
                        return File.ReadAllText(fullPath);
                    }
                }
                catch { }
            }

            return null;
        }

        public static void SaveConnectionStringToConfig(string newConnStr)
        {
            try
            {
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
            }
            catch { }
        }
    }
}
