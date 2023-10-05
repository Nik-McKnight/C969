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
            // Create connection string
            string server = "localhost";
            string database = "mydb";
            string username = "root";
            //string username = "test";
            string password = "nikk";
            //string password = "test";
            string constring = "SERVER="+server+";DATABASE="+database+";UID="+username+";PASSWORD="+password+";";

            // Create mysql connection
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();
            //SeedData seed = new SeedData(conn);
            //popCountry(conn);
            Console.WriteLine("Done.");
            //// Query
            //string query = "select * from user";
            //MySqlCommand cmd = new MySqlCommand(query, conn);
            //MySqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.GetString(0));
            //    Console.WriteLine(reader.GetString(1));
            //    Console.WriteLine(reader.GetString(2));
            //    Console.WriteLine(reader.GetString(3));
            //    Console.WriteLine(reader.GetString(4));
            //    Console.WriteLine(reader.GetString(5));
            //    Console.WriteLine(reader.GetString(6));
            //    Console.WriteLine(reader.GetString(7));
            //}
            conn.Close();

            // Change this to test different cultures
            //System.Threading.Thread.CurrentThread.CurrentCulture =
            //System.Globalization.CultureInfo.GetCultureInfo("es-MX");

            Console.WriteLine(System.Globalization.CultureInfo.CurrentCulture);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new login());

        }
    }
}
