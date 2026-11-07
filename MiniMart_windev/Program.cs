using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMart_windev
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tự động nhận diện SQL Server & tự khởi tạo CSDL lần đầu nếu máy chưa có
            try
            {
                string statusMsg;
                Helpers.DatabaseHelper.EnsureDatabaseAutoSetup(out statusMsg);
            }
            catch { }

            Application.Run(new Forms.HeThong.frmLogin());
        }
    }
}
