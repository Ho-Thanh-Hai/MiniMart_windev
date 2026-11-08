using System;
using System.Linq;
using System.Windows.Forms;
using MiniMart_windev.Helpers;
using MiniMart_windev.Models;
using MiniMart_windev.Forms.DanhMuc;
using MiniMart_windev.Forms.NghiepVu;
using MiniMart_windev.Forms.BaoCao;

namespace MiniMart_windev.Forms.HeThong
{
    public partial class frmMain : Form
    {
        public bool IsLoggingOut { get; private set; } = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // 1. Hiển thị thông tin người dùng và thời gian
            lblNguoiDung.Text = "  Xin chào: " + (string.IsNullOrEmpty(CurrentUserSession.HoTen) ? "Admin" : CurrentUserSession.HoTen)
                                + "  |  Vai trò: " + (string.IsNullOrEmpty(CurrentUserSession.TenVaiTro) ? "Quản trị viên" : CurrentUserSession.TenVaiTro);
            lblThoiGian.Text = DateTime.Now.ToString("HH:mm  dd/MM/yyyy") + "  ";

            // 2. Phân quyền người dùng theo vai trò
            ApplyRolePermissions();

            // 3. Cấu hình Theme & Dark Mode
            ThemeHelper.ApplyTheme(this);
            btnThemeMain.Text = ThemeHelper.IsDarkMode ? "Light Mode" : "Dark Mode";
        }

        private void ApplyRolePermissions()
        {
            string roleName = CurrentUserSession.TenVaiTro?.Trim().ToLower() ?? "";

            // Nếu là Quản trị viên hoặc Admin thì có toàn quyền
            if (roleName.Contains("quản trị") || roleName.Contains("admin") || roleName.Contains("giám đốc"))
            {
                return;
            }

            try
            {
                using (var db = new MiniMartDBDataContext())
                {
                    // Lấy danh sách mã chức năng mà vai trò này được cấp quyền
                    var allowedChucNangs = db.PhanQuyens
                        .Where(pq => pq.MaVaiTro == CurrentUserSession.MaVaiTro && pq.DuocPhep == true)
                        .Select(pq => pq.MaChucNang)
                        .ToList();

                    // Nếu có cấu hình chi tiết trong bảng PhanQuyen, có thể kiểm tra ở đây.
                    // Kiểm tra theo vai trò phổ biến:
                    if (roleName.Contains("thu ngân") || roleName.Contains("bán hàng"))
                    {
                        // Thu ngân chỉ được bán hàng, tra cứu hóa đơn, xem khách hàng
                        menuQuanLyTaiKhoan.Visible = false;
                        menuQuanLyVaiTro.Visible = false;
                        menuCauHinhKetNoi.Visible = false;

                        menuQuanLySanPham.Enabled = false;
                        menuQuanLyDanhMuc.Enabled = false;
                        menuQuanLyNhaCungCap.Enabled = false;
                        menuNhapKho.Enabled = false;
                        menuChiTietPhieuNhap.Enabled = false;

                        menuDoanhThu.Visible = false;

                        btnQuickSanPham.Enabled = false;
                        btnQuickNhapKho.Enabled = false;
                        btnQuickDoanhThu.Enabled = false;
                    }
                    else if (roleName.Contains("kho"))
                    {
                        // Thủ kho chỉ được quản lý sản phẩm, danh mục, nhà cung cấp, nhập kho, xem tồn kho
                        menuQuanLyTaiKhoan.Visible = false;
                        menuQuanLyVaiTro.Visible = false;
                        menuCauHinhKetNoi.Visible = false;

                        menuBanHang.Enabled = false;
                        menuInHoaDon.Enabled = false;
                        menuDoanhThu.Visible = false;

                        btnQuickBanHang.Enabled = false;
                        btnQuickDoanhThu.Enabled = false;
                    }
                }
            }
            catch
            {
                // Fallback nếu không có kết nối DB
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblThoiGian.Text = DateTime.Now.ToString("HH:mm  dd/MM/yyyy") + "  ";
        }

        // =================== MENU HỆ THỐNG ===================
        private void menuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }

        private void menuQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            frmUserManagement frm = new frmUserManagement();
            frm.ShowDialog();
        }

        private void menuQuanLyVaiTro_Click(object sender, EventArgs e)
        {
            frmRoleManagement frm = new frmRoleManagement();
            frm.ShowDialog();
        }

        private void menuCauHinhKetNoi_Click(object sender, EventArgs e)
        {
            frmConnectionConfig frm = new frmConnectionConfig();
            frm.ShowDialog();
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất khỏi hệ thống?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IsLoggingOut = true;
                CurrentUserSession.ClearSession();
                this.Close();
            }
        }

        // =================== MENU DANH MỤC & NHẬP KHO (NGƯỜI 2) ===================
        private void menuQuanLySanPham_Click(object sender, EventArgs e)
        {
            frmProductManagement frm = new frmProductManagement();
            frm.ShowDialog();
        }

        private void menuQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            frmCategoryManagement frm = new frmCategoryManagement();
            frm.ShowDialog();
        }

        private void menuQuanLyNhaCungCap_Click(object sender, EventArgs e)
        {
            frmSupplierManagement frm = new frmSupplierManagement();
            frm.ShowDialog();
        }

        private void menuNhapKho_Click(object sender, EventArgs e)
        {
            frmStockReceipt frm = new frmStockReceipt();
            frm.ShowDialog();
        }

        private void menuChiTietPhieuNhap_Click(object sender, EventArgs e)
        {
            frmStockReceiptDetail frm = new frmStockReceiptDetail();
            frm.ShowDialog();
        }

        // =================== MENU NGHIỆP VỤ BÁN HÀNG (NGƯỜI 3) ===================
        private void menuBanHang_Click(object sender, EventArgs e)
        {
            frmSalesInvoice frm = new frmSalesInvoice();
            frm.ShowDialog();
        }

        private void menuChiTietHoaDon_Click(object sender, EventArgs e)
        {
            frmInvoiceDetail frm = new frmInvoiceDetail();
            frm.ShowDialog();
        }

        private void menuInHoaDon_Click(object sender, EventArgs e)
        {
            frmInvoiceReport frm = new frmInvoiceReport();
            frm.ShowDialog();
        }

        private void menuKhachHang_Click(object sender, EventArgs e)
        {
            frmCustomerManagement frm = new frmCustomerManagement();
            frm.ShowDialog();
        }

        // =================== MENU BÁO CÁO & THỐNG KÊ (NGƯỜI 4) ===================
        private void menuDoanhThu_Click(object sender, EventArgs e)
        {
            frmRevenueReport frm = new frmRevenueReport();
            frm.ShowDialog();
        }

        private void menuTonKho_Click(object sender, EventArgs e)
        {
            MiniMart_windev.Forms.BaoCao.frmInventoryReport frm = new MiniMart_windev.Forms.BaoCao.frmInventoryReport();
            frm.ShowDialog();
        }

        private void menuThongKe_Click(object sender, EventArgs e)
        {
            frmSalesStatistics frm = new frmSalesStatistics();
            frm.ShowDialog();
        }

        // =================== CÁC CHỨC NĂNG THOÁT, THEME & GIỚI THIỆU ===================
        private void btnAboutMain_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void btnThemeMain_Click(object sender, EventArgs e)
        {
            ThemeHelper.ToggleTheme();
            ThemeHelper.ApplyTheme(this);
            btnThemeMain.Text = ThemeHelper.IsDarkMode ? "Light Mode" : "Dark Mode";
        }

        private void btnThoatMain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình MiniMart?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuThoatChuongTrinh_Click(object sender, EventArgs e)
        {
            btnThoatMain_Click(sender, e);
        }

        private void menuGioiThieu_Click(object sender, EventArgs e)
        {
            btnAboutMain_Click(sender, e);
        }

        private void menuThemeToggle_Click(object sender, EventArgs e)
        {
            btnThemeMain_Click(sender, e);
        }
    }
}