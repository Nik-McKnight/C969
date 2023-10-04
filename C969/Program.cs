using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            string password = "nikk";
            string constring = "SERVER="+server+";DATABASE="+database+";UID="+username+";PASSWORD="+password+";";

            // Create mysql connection
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();
            SeedData seed = new SeedData(conn);
            //popCountry(conn);
            conn.Close();
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





            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

        }

        //public static void popCountry(MySqlConnection conn)
        //{
        //    try
        //    {
        //        using (var reader = new System.IO.StreamReader(@"..\..\mock data\country.csv"))
        //        {
        //            while (!reader.EndOfStream)
        //            {
        //                var line = reader.ReadLine();
        //                var fields = line.Split('\u002C');
        //                string country = fields[0];
        //                if (country == "country") continue;
        //                string createDate = fields[1];
        //                string createdBy = fields[2];
        //                string lastUpdate = fields[3];
        //                string lastUpdateBy = fields[4];

        //                // Problem is probably that I'm passing a datetime into a string.

        //                string sql = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('" + country + "', CURDATE(),'" + createdBy + "', CURDATE() ,'" + lastUpdateBy + "');";
        //                Console.WriteLine(sql);
        //                MySqlCommand cmd = new MySqlCommand(sql, conn);
        //                cmd.ExecuteNonQuery();
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //}
    }
}
