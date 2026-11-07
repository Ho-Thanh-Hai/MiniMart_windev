using System;
using MiniMart_windev.Helpers;
using MiniMart_windev.Models;

namespace MiniMart_windev.Models
{
    public partial class MiniMartDBDataContext
    {
        partial void OnCreated()
        {
            string activeConn = Helpers.DatabaseHelper.ActiveConnectionString;
            if (!string.IsNullOrEmpty(activeConn) && this.Connection != null)
            {
                if (this.Connection.State == System.Data.ConnectionState.Closed)
                {
                    this.Connection.ConnectionString = activeConn;
                }
            }
        }
    }

    public partial class ChiTietPhieuNhap
    {
        public decimal DonGiaNhap
        {
            get => this.DongiaNhap;
            set => this.DongiaNhap = value;
        }
    }

    public class QuanLyBanHangKhoDataContext : MiniMartDBDataContext
    {
        public QuanLyBanHangKhoDataContext() : base() { }
        public QuanLyBanHangKhoDataContext(string connection) : base(connection) { }
    }
}

namespace MiniMart_windev.Forms.DanhMuc
{
    public class QuanLyBanHangKhoDataContext : MiniMart_windev.Models.MiniMartDBDataContext
    {
        public QuanLyBanHangKhoDataContext() : base() { }
        public QuanLyBanHangKhoDataContext(string connection) : base(connection) { }
    }
}

namespace MiniMart_windev.Forms.NghiepVu
{
    public class QuanLyBanHangKhoDataContext : MiniMart_windev.Models.MiniMartDBDataContext
    {
        public QuanLyBanHangKhoDataContext() : base() { }
        public QuanLyBanHangKhoDataContext(string connection) : base(connection) { }
    }
}

namespace QuanLyBanHangKho
{
    public class QuanLyBanHangKhoDataContext : MiniMart_windev.Models.MiniMartDBDataContext
    {
        public QuanLyBanHangKhoDataContext() : base() { }
        public QuanLyBanHangKhoDataContext(string connection) : base(connection) { }
    }

    public static class ThongTinDangNhap
    {
        public static int MaNguoiDungDangNhap
        {
            get => CurrentUserSession.MaNguoiDung > 0 ? CurrentUserSession.MaNguoiDung : 1;
            set => CurrentUserSession.MaNguoiDung = value;
        }
    }
}

namespace QuanLyBanHangKho.Properties
{
    public class Settings
    {
        private static Settings defaultInstance = new Settings();
        public static Settings Default => defaultInstance;
        public string QuanLyBanHangKhoConnectionString => global::MiniMart_windev.Helpers.DatabaseHelper.ActiveConnectionString;
    }
}
