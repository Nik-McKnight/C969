using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    internal static class Utilities
    {
        // Create connection string
        static string server = "localhost";
        static string database = "mydb";
        static string username = "root";
        //string username = "test";
        static string password = "nikk";
        //string password = "test";
        static string constring = "SERVER="+server+";DATABASE="+database+";UID="+username+";PASSWORD="+password+";";



        internal static void SeedData()
        {
            // Create mysql connection
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();
            SeedData seed = new SeedData(conn);
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
        }

        internal static void ExampleQuery()
        {
            // Create mysql connection
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();

            string query = "select * from user";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
                Console.WriteLine(reader.GetString(1));
                Console.WriteLine(reader.GetString(2));
                Console.WriteLine(reader.GetString(3));
                Console.WriteLine(reader.GetString(4));
                Console.WriteLine(reader.GetString(5));
                Console.WriteLine(reader.GetString(6));
                Console.WriteLine(reader.GetString(7));
            }
            conn.Close();
        }

        internal static Boolean LoginQuery(string username, string password)
        {
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();

            string query = "select * from user where userName = '" + username + "' and password = '" + password + "';";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else return false;
        }

        internal static Boolean UserNameExists(string username)
        {
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();

            string query = "select * from user where userName = '" + username + "';";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                //while (reader.Read())
                //{
                //    Console.WriteLine(reader.(1));
                //}
                return true;
            }
            else return false;
        }

        internal static Boolean CreateUser(string userName, string password)
        {
            try { 
                MySqlConnection conn = new MySqlConnection(constring);
                conn.Open();
                if (userName == null || userName == "" || password == null || password == "") return false;
                string sql = "INSERT INTO user (userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES ('" + userName + "','" + password + "',1, CURDATE(),'" + userName + "', CURDATE() ,'" + userName + "');";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static string GetPrimaryCulture()
        {
            return System.Globalization.CultureInfo.CurrentCulture.ToString();
        }

        internal static string GetSecondaryCulture()
        {
            if (System.Globalization.CultureInfo.CurrentCulture.ToString() == "en-US") {
                return "es-MX";
            }
            else {
                return "en-us";
            }
        }
    }
}
