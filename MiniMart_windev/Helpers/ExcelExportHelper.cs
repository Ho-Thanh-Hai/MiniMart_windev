using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MiniMart_windev.Helpers
{
    public static class ExcelExportHelper
    {
        /// <summary>
        /// Xuất toàn bộ dữ liệu từ DataGridView ra tệp Excel (.csv UTF-8 kèm BOM mở trực tiếp bằng Excel không lỗi font)
        /// </summary>
        public static void ExportDataGridViewToExcel(DataGridView dgv, string defaultFileName, string reportTitle = "BÁO CÁO DỮ LIỆU")
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong bảng để xuất ra Excel!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Tệp Excel định dạng CSV (*.csv)|*.csv|Tệp văn bản (*.txt)|*.txt";
                sfd.FileName = defaultFileName.EndsWith(".csv") ? defaultFileName : defaultFileName + ".csv";
                sfd.Title = "Chọn nơi lưu tệp xuất Excel";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();

                        // Tiêu đề báo cáo
                        sb.AppendLine($"\"{reportTitle.ToUpper()}\"");
                        sb.AppendLine($"\"Thời gian xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\"");
                        sb.AppendLine();

                        // Hàng tiêu đề cột
                        int visibleColCount = 0;
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            if (dgv.Columns[i].Visible)
                            {
                                string header = dgv.Columns[i].HeaderText.Replace("\"", "\"\"");
                                sb.Append($"\"{header}\",");
                                visibleColCount++;
                            }
                        }
                        if (visibleColCount > 0) sb.Length--; // bỏ dấu phẩy cuối
                        sb.AppendLine();

                        // Các hàng dữ liệu
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow) continue;
                            int count = 0;
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                if (dgv.Columns[i].Visible)
                                {
                                    object val = row.Cells[i].Value;
                                    string cellText = val != null ? val.ToString().Replace("\"", "\"\"") : "";
                                    sb.Append($"\"{cellText}\",");
                                    count++;
                                }
                            }
                            if (count > 0) sb.Length--;
                            sb.AppendLine();
                        }

                        // Ghi file với Encoding UTF8 có BOM (Preamble) để Microsoft Excel mở tiếng Việt không bao giờ bị lỗi font
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        var result = MessageBox.Show(
                            "Xuất dữ liệu ra tệp Excel thành công!\n\nBạn có muốn mở tệp vừa xuất ngay bây giờ không?",
                            "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất tệp Excel: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
