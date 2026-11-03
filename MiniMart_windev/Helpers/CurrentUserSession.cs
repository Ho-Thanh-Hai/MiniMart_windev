namespace MiniMart_windev.Helpers
{
    public static class CurrentUserSession
    {
        public static int MaNguoiDung { get; set; }
        public static string TenDangNhap { get; set; }
        public static string HoTen { get; set; }
        public static int MaVaiTro { get; set; }
        public static string TenVaiTro { get; set; }

        public static void ClearSession()
        {
            MaNguoiDung = 0;
            TenDangNhap = string.Empty;
            HoTen = string.Empty;
            MaVaiTro = 0;
            TenVaiTro = string.Empty;
        }
    }
}