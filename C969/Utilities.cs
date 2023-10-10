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

        internal static string[] LoginQuery(string username, string password)
        {
            conn.Open();
            string query = "select * from user where userName = '" + username + "' and password = '" + password + "';";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string[] output = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)};
                    conn.Close();
                    return output;
                }
            }
            conn.Close();
            return null;
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
            else
            {
                conn.Close();
                return false;
            }
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
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        internal static Boolean CreateCustomer(string customerName, int addressId, string createdBy)
        {
            try
            {
                conn.Open();
                string sql = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES ('" + customerName + "','" + addressId + "',1, CURDATE(),'" + createdBy + "', CURDATE() ,'" + createdBy + "');";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
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
                        conn.Close();
                        return output;
                    }
                    conn.Close();
                    return null;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
            catch
            {
                conn.Close();
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
                    while (reader.Read())
                    {
                        string[] customer = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)};
                        output.Add(customer);
                    }
                    Console.WriteLine(output.Capacity);
                    conn.Close();
                    return output;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
            catch
            {
                conn.Close();
                return null;
            }
        }

        internal static Boolean UpdateCustomer(int customerId, string customerName, int addressId, int active, string createDate, string createdBy, string lastUpdateBy)
        {
            try
            {
                conn.Open();
                string sql = "update customer " +
                    "set customerName = '" + customerName + "', addressId = " + addressId + ", active = " + active + ", createDate = '" + createDate +
                    "', createdBy = '" + createdBy + "', lastUpdate = CURDATE(), lastUpdateBy ='" + lastUpdateBy +
                    "' where customerId = " + customerId + ";";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
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
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        internal static Boolean CreateAppointment(int customerId, int userId, string title, string description, string location,
                                                  string contact, string type, string url, string start, string end, string createdBy)
        {
            try
            {
                conn.Open();
                string sql = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, " +
                             "createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES (" + customerId + "," + userId + ", '" + title + "','" + description + "','" + location + "','" + contact + "','" +
                    type + "','" + url + "','" +start + "','" +end + "',CURDATE(),'" + createdBy + "', CURDATE() ,'" + createdBy + "');";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        internal static string[] ReadAppointment(int appointmentId)
        {
            try
            {
                conn.Open();
                string sql = "select * from appointment where appointmentId = " + appointmentId + ";";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] output = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                                            reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11),
                                            reader.GetString(12), reader.GetString(13), reader.GetString(14)};
                        conn.Close();
                        return output;
                    }
                    conn.Close();
                    return null;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        internal static ArrayList ReadAllAppointments()
        {
            ArrayList output = new ArrayList();
            try
            {
                conn.Open();
                string sql = "select * from appointment;";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] appointment = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                                            reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11),
                                            reader.GetString(12), reader.GetString(13), reader.GetString(14)};
                        output.Add(appointment);
                    }
                    Console.WriteLine(output.Capacity);
                    conn.Close();
                    return output;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
            catch
            {
                conn.Close();
                return null;
            }
        }

        internal static ArrayList ReadAllAppointmentsByCustomer(int customerId)
        {
            ArrayList output = new ArrayList();
            try
            {
                conn.Open();
                string sql = "select * from appointment where customerId = " + customerId + ";";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] appointment = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                                            reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11),
                                            reader.GetString(12), reader.GetString(13), reader.GetString(14)};
                        output.Add(appointment);
                    }
                    Console.WriteLine(output.Capacity);
                    conn.Close();
                    return output;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
            catch
            {
                conn.Close();
                return null;
            }
        }

        internal static ArrayList ReadAllAppointmentsByUser(int userId)
        {
            ArrayList output = new ArrayList();
            try
            {
                conn.Open();
                string sql = "select * from appointment where userId = " + userId + ";";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] appointment = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                                            reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11),
                                            reader.GetString(12), reader.GetString(13), reader.GetString(14)};
                        output.Add(appointment);
                    }
                    Console.WriteLine(output.Capacity);
                    conn.Close();
                    return output;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
            catch
            {
                conn.Close();
                return null;
            }
        }

        internal static string[][] ReadUserAppointmentsByDate(int userId, string dateTime)
        {
            string[][] output = { };
            try
            {
                conn.Open();
                string sql = "select customerName, title, description, location, " +
                    "contact, type, url, start, end from appointment right join " +
                    "customer on appointment.customerId = customer.customerId" +
                    " where userId = " + userId + " and start like '%"+dateTime +"%';";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] appointment = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                                            reader.GetString(8)};
                        int length = output.Length;
                        Array.Resize(ref output, length + 1);
                        output[length] = (appointment);
                    }
                    Console.WriteLine(output.Length);
                    conn.Close();
                    return output;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
            catch
            {
                conn.Close();
                return null;
            }
        }



        internal static Boolean UpdateAppointment(int appointmentId, int customerId, int userId, string title, string description, string location,
                                                  string contact, string type, string url, string start, string end,
                                                  string createDate, string createdBy, string lastUpdateBy)
        {
            try
            {
                conn.Open();
                string sql = "update appointment " +
                    "set customerId = " + customerId + ", userId = " + userId + ", title = '" + title + "', description = '" + description +
                    "', location = '" + location + "', contact = '" + contact +"', type = '" + type + "', url = '" + url +
                    "', start = '" + start + "', end = '" + end + "', createDate = '" + createDate +
                    "', createdBy = '" + createdBy + "', lastUpdate = CURDATE(), lastUpdateBy ='" + lastUpdateBy +
                    "' where appointmentId = " + appointmentId + ";";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        internal static Boolean DeleteAppointment(int appointmentId)
        {
            try
            {
                conn.Open();
                string sql = "delete from appointment where appointmentId = " + appointmentId + ";";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        internal static string ConvertDate(string calDate)
        {
            // Lambda 1: I needed to pad two different strings, but I don't need to do it outside of this function.
            Func<string, string> Pad = x => "0" + x;
            string[] split = calDate.Split('/');
            string month = split[0];
            if (month.Length == 1) month = Pad(month);
            string day = split[1];
            if (day.Length == 1) day = Pad(day);
            string year = split[2];
            return year + "-" + month + "-" + day;
        }

        internal static DateTime ConvertToLocalTime(string date)
        {
            // Lamba 2: I wanted to easily add an hour to the local DateTime value if DST is in effect.
            Func<DateTime, DateTime> addDST = x =>
            {
                System.Globalization.DaylightTime dl = TimeZone.CurrentTimeZone.GetDaylightChanges(DateTime.Now.Year);
                if (x >= dl.Start && x <= dl.End)
                {
                    return x.Add(new TimeSpan(1, 0, 0));
                }
                return x;
            };
            Console.WriteLine(date);
            DateTime dt = DateTime.Parse(date);
            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            TimeSpan currentOffset = curTimeZone.GetUtcOffset(DateTime.Now);
            DateTime local = addDST(dt.Add(currentOffset));
            Console.WriteLine(local);
            return local;
        }
    }
}
