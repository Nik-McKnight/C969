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
            // Change this to test different cultures
            //System.Threading.Thread.CurrentThread.CurrentCulture =
            //System.Globalization.CultureInfo.GetCultureInfo("es-MX");

            // Enable this to seed database
            //Utilities.SeedData();

            Console.WriteLine(Utilities.CreateUser("testt", "test"));      
            
            Console.WriteLine(System.Globalization.CultureInfo.CurrentCulture);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new login());

        }
    }
}
