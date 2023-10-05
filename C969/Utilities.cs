using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    internal static class Utilities
    {
        internal static string GetPrimaryCulture()
        {
            return System.Globalization.CultureInfo.CurrentCulture.ToString();
        }

        internal static string GetSecondaryCulture()
        {
            if (GetPrimaryCulture() == "en-US")
            {
                return "es-MX";
            }
            else
            {
                return "en-us";
            }
        }



        // Create connection string
        static string server = "localhost";
        static string database = "mydb";
        static string username = "root";
        //string username = "test";
        static string password = "nikk";
        //string password = "test";
        static string constring = "SERVER="+server+";DATABASE="+database+";UID="+username+";PASSWORD="+password+";";
        static MySqlConnection conn = new MySqlConnection(constring);


        internal static void SeedData()
        {
            conn.Open();
            SeedData seed = new SeedData(conn);
            Console.WriteLine("Done.");
            conn.Close();
        }

        internal static void ExampleQuery()
        {
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
            conn.Open();

            string query = "select * from user where userName = '" + username + "';";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else return false;
        }

        internal static Boolean CreateUser(string userName, string password)
        {
            try { 
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

        internal static Boolean CreateCustomer(string customerName, int addressId, string createdBy)
        {
            try
            {
                conn.Open();
                //if (customerName == null || customerName == "" || password == null || password == "") return false;
                string sql = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES ('" + customerName + "','" + addressId + "',1, CURDATE(),'" + createdBy + "', CURDATE() ,'" + createdBy + "');";
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

        internal static string[] ReadCustomer(int customerId)
        {
            try
            {
                conn.Open();
                string sql = "select * from customer where customerId = " + customerId + ";";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] output = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)};
                        Console.WriteLine(output[1]);
                        return output;
                    }
                    return null;
                }
                else return null;

            }
            catch
            {
                return null;
            }
        }

        internal static ArrayList ReadAllCustomers()
        {
            ArrayList output = new ArrayList();
            try
            {
                conn.Open();
                string sql = "select * from customer;";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read()) { 
                        string[] customer = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)};
                        output.Add(customer);
                    }
                    Console.WriteLine(output.Capacity);
                    return output;
                }
                else return null;
            }
            catch
            {
                return null;
            }
        }

        internal static Boolean UpdateCustomer(int customerId, string customerName, int addressId, int active, string createDate, string createdBy, string lastUpdateBy)
        {
            try
            {
                conn.Open();
                //if (customerName == null || customerName == "" || password == null || password == "") return false;
                //string sql = "update customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                //    "set ('" + customerName + "','" + addressId + "'," + active +", " + createDate + ",'" + createdBy + "', CURDATE() ,'" + lastUpdateBy + "')" +
                //    "where customerId = " + customerId +";";
                string sql = "update customer " +
                    "set customerName = '" + customerName + "', addressId = " + addressId + ", active = " + active + ", createDate = '" + createDate +
                    "', createdBy = '" + createdBy + "', lastUpdate = CURDATE(), lastUpdateBy ='" + lastUpdateBy +
                    "' where customerId = " + customerId + ";"; 
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

        internal static Boolean DeleteCustomer(int customerId)
        {
            try
            {
                conn.Open();
                string sql = "delete from customer where customerId = " + customerId + ";";
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
    }
}
