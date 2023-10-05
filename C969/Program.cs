using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;

namespace C969
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Uncomment and change this to test different cultures
            //System.Threading.Thread.CurrentThread.CurrentCulture =
            //System.Globalization.CultureInfo.GetCultureInfo("es-MX");

            // Enable this to seed database
            //Utilities.SeedData();
            //Utilities.DeleteAppointment(1);
            Utilities.UpdateAppointment(2, 3, 3, "test", "test", "test", "test", "test", "test", "2023-10-05 00:00:00", "2023-10-05 00:00:00", "2023-10-05 00:00:00", "test", "test");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new login());

        }
    }
}
