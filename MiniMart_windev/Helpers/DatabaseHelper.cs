using System;
using System.Configuration;

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
    }
}
