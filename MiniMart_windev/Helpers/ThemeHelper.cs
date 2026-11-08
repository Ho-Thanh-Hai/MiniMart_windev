using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniMart_windev.Helpers
{
    public static class ThemeHelper
    {
        public static bool IsDarkMode { get; set; } = false;

        public static event Action ThemeChanged;

        public static void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;

            // Cập nhật ngay lập tức cho tất cả Form đang mở
            foreach (Form f in Application.OpenForms)
            {
                ApplyTheme(f);

                var themeButtons = f.Controls.Find("btnToggleTheme", true);
                foreach (Control tb in themeButtons)
                {
                    tb.Text = IsDarkMode ? "Light Mode" : "Dark Mode";
                }

                var mainThemeButtons = f.Controls.Find("btnThemeMain", true);
                foreach (Control tb in mainThemeButtons)
                {
                    tb.Text = IsDarkMode ? "Light Mode" : "Dark Mode";
                }
            }

            ThemeChanged?.Invoke();
        }

        public static void ApplyTheme(Form form)
        {
            if (form == null || form.IsDisposed) return;

            if (IsDarkMode)
            {
                // Dark Mode Colors
                form.BackColor = Color.FromArgb(32, 34, 37);
                form.ForeColor = Color.WhiteSmoke;

                ApplyDarkModeToControls(form.Controls);
            }
            else
            {
                // Light Mode Colors
                form.BackColor = Color.FromArgb(245, 247, 250);
                form.ForeColor = Color.FromArgb(33, 33, 33);

                ApplyLightModeToControls(form.Controls);
            }
        }

        private static void ApplyDarkModeToControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is Panel p)
                {
                    if (p.Name == "panelTop" || p.Name == "panelHeader")
                    {
                        p.BackColor = Color.FromArgb(24, 25, 28);
                    }
                    else if (p.Name.StartsWith("panelCard"))
                    {
                        // Giữ nguyên màu nền thẻ KPI doanh thu
                    }
                    else
                    {
                        p.BackColor = Color.FromArgb(42, 45, 49);
                        p.ForeColor = Color.WhiteSmoke;
                    }
                }
                else if (c is GroupBox gb)
                {
                    gb.ForeColor = Color.FromArgb(100, 181, 246);
                    gb.BackColor = Color.Transparent;
                }
                else if (c is Button btn)
                {
                    // Xử lý nút bấm trong Dark Mode để chữ luôn luôn rõ ràng
                    if (btn.Name == "btnThoatMain" || btn.Name == "btnVeMenuChinh" || btn.Name == "btnDong")
                    {
                        btn.BackColor = Color.FromArgb(217, 83, 79); // Đỏ nổi bật
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else if (btn.Name == "btnAboutMain")
                    {
                        btn.BackColor = Color.FromArgb(46, 204, 113); // Xanh lá nổi bật
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else if (btn.Name == "btnThemeMain" || btn.Name == "btnToggleTheme")
                    {
                        btn.BackColor = Color.FromArgb(52, 152, 219); // Xanh dương
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else if (btn.Name == "btnXemBaoCao")
                    {
                        btn.BackColor = Color.FromArgb(40, 167, 69); // Xanh lá
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else if (btn.Name == "btnInBaoCao")
                    {
                        btn.BackColor = Color.FromArgb(0, 122, 204); // Xanh biển
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else if (btn.Name.StartsWith("btnQuick"))
                    {
                        // Giữ màu thẻ dashboard của btnQuick, chữ luôn trắng
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        // Tất cả nút bấm thông thường (Thêm, Sửa, Xóa, Làm mới, Tìm kiếm, v.v.)
                        btn.UseVisualStyleBackColor = false;
                        btn.BackColor = Color.FromArgb(55, 62, 75); // Nền xám xanh đậm
                        btn.ForeColor = Color.White;                // Chữ trắng cực rõ nét
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(90, 105, 125);
                        btn.FlatAppearance.BorderSize = 1;
                    }
                }
                else if (c is Label lbl)
                {
                    if (lbl.Parent != null && (lbl.Parent.Name == "panelTop" || lbl.Parent.Name == "panelHeader" || lbl.Parent.Name.StartsWith("panelCard")))
                    {
                        lbl.ForeColor = Color.White;
                    }
                    else if (lbl.ForeColor != Color.White && lbl.ForeColor != Color.Red && lbl.ForeColor != Color.FromArgb(192, 0, 0))
                    {
                        lbl.ForeColor = Color.FromArgb(230, 235, 240);
                    }
                }
                else if (c is TextBox tb)
                {
                    tb.BackColor = Color.FromArgb(48, 51, 56);
                    tb.ForeColor = Color.White;
                    tb.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is ComboBox cb)
                {
                    cb.BackColor = Color.FromArgb(48, 51, 56);
                    cb.ForeColor = Color.White;
                    cb.FlatStyle = FlatStyle.Flat;
                }
                else if (c is DateTimePicker dtp)
                {
                    dtp.CalendarMonthBackground = Color.FromArgb(48, 51, 56);
                    dtp.CalendarTitleBackColor = Color.FromArgb(24, 25, 28);
                    dtp.CalendarForeColor = Color.White;
                }
                else if (c is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.FromArgb(40, 43, 48);
                    dgv.GridColor = Color.FromArgb(65, 70, 78);
                    dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 48, 53);
                    dgv.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 30, 33);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.EnableHeadersVisualStyles = false;
                }
                else if (c is MenuStrip ms)
                {
                    ms.BackColor = Color.FromArgb(24, 25, 28);
                    ms.ForeColor = Color.White;
                    foreach (ToolStripMenuItem item in ms.Items)
                    {
                        item.ForeColor = Color.White;
                    }
                }
                else if (c is StatusStrip ss)
                {
                    ss.BackColor = Color.FromArgb(24, 25, 28);
                    ss.ForeColor = Color.WhiteSmoke;
                }

                if (c.HasChildren)
                {
                    ApplyDarkModeToControls(c.Controls);
                }
            }
        }

        private static void ApplyLightModeToControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is Panel p)
                {
                    if (p.Name == "panelTop" || p.Name == "panelHeader")
                    {
                        p.BackColor = Color.FromArgb(0, 122, 204);
                    }
                    else if (p.Name.StartsWith("panelCard"))
                    {
                        // Giữ nguyên màu thẻ KPI doanh thu
                    }
                    else
                    {
                        p.BackColor = Color.White;
                        p.ForeColor = Color.FromArgb(33, 33, 33);
                    }
                }
                else if (c is GroupBox gb)
                {
                    gb.ForeColor = Color.FromArgb(0, 102, 204);
                    gb.BackColor = Color.Transparent;
                }
                else if (c is Button btn)
                {
                    if (btn.Name == "btnThoatMain" || btn.Name == "btnVeMenuChinh" || btn.Name == "btnDong")
                    {
                        btn.BackColor = Color.FromArgb(231, 76, 60);
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else if (btn.Name == "btnAboutMain")
                    {
                        btn.BackColor = Color.FromArgb(46, 204, 113);
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else if (btn.Name == "btnThemeMain" || btn.Name == "btnToggleTheme")
                    {
                        btn.BackColor = Color.FromArgb(41, 128, 185);
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else if (btn.Name == "btnXemBaoCao")
                    {
                        btn.BackColor = Color.FromArgb(40, 167, 69);
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else if (btn.Name == "btnInBaoCao")
                    {
                        btn.BackColor = Color.FromArgb(0, 122, 204);
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }
                    else if (btn.Name.StartsWith("btnQuick"))
                    {
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        btn.UseVisualStyleBackColor = false;
                        btn.BackColor = Color.FromArgb(240, 243, 246);
                        btn.ForeColor = Color.FromArgb(30, 41, 59);
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                        btn.FlatAppearance.BorderSize = 1;
                    }
                }
                else if (c is Label lbl)
                {
                    if (lbl.Parent != null && (lbl.Parent.Name == "panelTop" || lbl.Parent.Name == "panelHeader" || lbl.Parent.Name.StartsWith("panelCard")))
                    {
                        lbl.ForeColor = Color.White;
                    }
                    else if (lbl.ForeColor != Color.Red && lbl.ForeColor != Color.FromArgb(192, 0, 0))
                    {
                        lbl.ForeColor = Color.FromArgb(44, 62, 80);
                    }
                }
                else if (c is TextBox tb)
                {
                    tb.BackColor = Color.White;
                    tb.ForeColor = Color.Black;
                    tb.BorderStyle = BorderStyle.Fixed3D;
                }
                else if (c is ComboBox cb)
                {
                    cb.BackColor = Color.White;
                    cb.ForeColor = Color.Black;
                    cb.FlatStyle = FlatStyle.Standard;
                }
                else if (c is DateTimePicker dtp)
                {
                    dtp.CalendarMonthBackground = Color.White;
                    dtp.CalendarTitleBackColor = Color.FromArgb(0, 122, 204);
                    dtp.CalendarForeColor = Color.Black;
                }
                else if (c is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.White;
                    dgv.GridColor = Color.FromArgb(224, 224, 224);
                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = Color.Black;
                    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    dgv.EnableHeadersVisualStyles = true;
                }
                else if (c is MenuStrip ms)
                {
                    ms.BackColor = Color.White;
                    ms.ForeColor = Color.Black;
                    foreach (ToolStripMenuItem item in ms.Items)
                    {
                        item.ForeColor = Color.Black;
                    }
                }
                else if (c is StatusStrip ss)
                {
                    ss.BackColor = Color.FromArgb(240, 240, 240);
                    ss.ForeColor = Color.FromArgb(60, 60, 60);
                }

                if (c.HasChildren)
                {
                    ApplyLightModeToControls(c.Controls);
                }
            }
        }

        /// <summary>
        /// Tự động thêm nút Chuyển Theme (Dark/Light) và nút Về Menu Chính (Thoát) vào Form
        /// </summary>
        public static void SetupFormThemeAndNavigation(Form form, bool isMain = false)
        {
            if (form == null) return;

            // Áp dụng theme ngay lập tức
            ApplyTheme(form);

            // Đăng ký nhận sự kiện đổi theme
            form.Load += (s, e) =>
            {
                ApplyTheme(form);
            };

            Action onThemeChanged = () =>
            {
                ApplyTheme(form);
            };

            ThemeChanged += onThemeChanged;

            form.FormClosed += (s, e) =>
            {
                ThemeChanged -= onThemeChanged;
            };

            // Tự động tạo thanh Header (panelTop) chuẩn cho các form in ấn/báo cáo chứa ReportViewer nếu chưa có
            bool hasReportViewer = false;
            foreach (Control c in form.Controls)
            {
                if (c.GetType().FullName != null && c.GetType().FullName.Contains("ReportViewer"))
                {
                    hasReportViewer = true;
                    break;
                }
            }

            if (hasReportViewer && form.Controls.Find("panelTop", true).Length == 0)
            {
                Panel topHeader = new Panel
                {
                    Name = "panelTop",
                    Dock = DockStyle.Top,
                    Height = 46,
                    BackColor = IsDarkMode ? Color.FromArgb(45, 45, 48) : Color.FromArgb(0, 122, 204)
                };

                Label lblReportTitle = new Label
                {
                    Name = "lblTopHeaderTitle",
                    Text = "📄 " + form.Text,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Location = new Point(16, 12)
                };
                topHeader.Controls.Add(lblReportTitle);

                form.Controls.Add(topHeader);
                topHeader.SendToBack();
            }

            // Thêm nút Theme vào Form nếu chưa có
            if (form.Controls.Find("btnToggleTheme", true).Length == 0)
            {
                Button btnTheme = new Button
                {
                    Name = "btnToggleTheme",
                    Text = IsDarkMode ? "Light Mode" : "Dark Mode",
                    Size = new Size(100, 30),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    BackColor = Color.FromArgb(52, 152, 219),
                    ForeColor = Color.White
                };
                btnTheme.FlatAppearance.BorderSize = 0;

                btnTheme.Click += (s, e) =>
                {
                    ToggleTheme();
                };

                Control container = form.Controls.Find("panelTop", true).Length > 0
                    ? form.Controls.Find("panelTop", true)[0]
                    : (Control)form;

                if (container != form)
                {
                    btnTheme.Location = new Point(container.ClientSize.Width - 110, 8);
                }
                else
                {
                    btnTheme.Location = new Point(form.ClientSize.Width - 110, 8);
                }

                container.Controls.Add(btnTheme);
                btnTheme.BringToFront();
            }

            // Thêm nút Thoát ra Menu chính (cho các form con)
            if (!isMain && form.Controls.Find("btnVeMenuChinh", true).Length == 0)
            {
                Button btnBack = new Button
                {
                    Name = "btnVeMenuChinh",
                    Text = "Về Menu Chính",
                    Size = new Size(120, 30),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    BackColor = Color.FromArgb(231, 76, 60),
                    ForeColor = Color.White
                };
                btnBack.FlatAppearance.BorderSize = 0;

                btnBack.Click += (s, e) =>
                {
                    form.Close();
                };

                Control container = form.Controls.Find("panelTop", true).Length > 0
                    ? form.Controls.Find("panelTop", true)[0]
                    : (Control)form;

                if (container != form)
                {
                    btnBack.Location = new Point(container.ClientSize.Width - 238, 8);
                }
                else
                {
                    btnBack.Location = new Point(form.ClientSize.Width - 238, 8);
                }

                container.Controls.Add(btnBack);
                btnBack.BringToFront();
            }
        }
    }
}
