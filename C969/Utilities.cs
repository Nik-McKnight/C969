﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969
{
    internal static class Utilities
    {
        internal static string GetPrimaryCulture()
        {
            Console.WriteLine(System.Globalization.CultureInfo.CurrentCulture.ToString());
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
                return "en-US";
            }
        }



        // Create connection string
        static string server = "localhost";
        //static string database = "mydb";
        //static string username = "root";
        //static string password = "nikk";
        static string database = "client_schedule";
        static string username = "sqlUser";
        static string password = "Passw0rd!";
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
                conn.Close();
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
                if (UserNameExists(userName))
                {
                    return false;
                }
                conn.Open();
                string now = ConvertToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
                if (userName == null || userName == "" || password == null || password == "") return false;
                string sql = "INSERT INTO user (userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES ('" + userName + "','" + password + "',1, '"+ now+"','" + userName + "', '"+ now+"' ,'" + userName + "');";
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


        internal static Boolean CreateCustomer(string customerName, string address, string address2, string createdBy, string phone, int cityId, string userName, string postalCode)
        {
            try
            {
                int addressId = ReadAddressIdByAddress(address);
                if (addressId == 0)
                {
                    CreateAddress(address, address2, phone, cityId, userName, postalCode);
                    addressId = ReadAddressIdByAddress(address);
                }
                string now = ConvertToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
                conn.Open();
                string sql = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES ('" + customerName + "'," + addressId + ",1, '"+ now+"','" + createdBy + "', '"+ now+"' ,'" + createdBy + "');";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                if (addressId != 0)
                {
                    UpdateAddress(address, address2, cityId, postalCode, phone, userName, addressId);
                }
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
                string sql = $"select * from customer inner join address on customer.addressId = address.addressId where customerId = {customerId};";
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
                                            reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15),
                                            reader.GetString(16), reader.GetString(17) };
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

        internal static string[] ReadUser (int userId)
        {
            try
            {
                conn.Open();
                string sql = $"select * from user where userId = {userId};";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] output = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)};
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

        internal static Boolean UpdateCustomer(string customerName, string address, string address2, string lastUpdateBy, string phone, int cityId, string userName, string postalCode, int customerId, int active)
        {
            try
            {
                int addressId = ReadAddressIdByAddress(address);
                if (addressId == 0)
                {
                    CreateAddress(address, address2, phone, cityId, postalCode, userName);
                    addressId = ReadAddressIdByAddress(address);
                }
                if (addressId != 0)
                {
                    UpdateAddress(address, address2, cityId, postalCode, phone, userName, addressId);
                }
                string now = ConvertToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
                conn.Open();
                string sql = "update customer " +
                    $"set customerName='{customerName}', addressId={addressId}, active={active}, lastUpdate='{now}', lastUpdateBy='{lastUpdateBy}' " +
                    $"where customerId={customerId};";
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
        internal static Boolean CreateAddress(string address, string address2, string phone, int cityId, string postalCode, string createdBy)
        {
            try
            {
                conn.Open();
                string sql = $"insert into address (address,address2,cityId,postalCode,phone,createDate,createdBy,lastUpdate,lastUpdateBy)" +
                    $" values ('{address}','{address2}','{cityId}','{postalCode}','{phone}',curdate(),'{createdBy}',curdate(),'{createdBy}');";
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

        internal static int ReadAddressIdByAddress(string address)
        {
            try
            {
                conn.Open();
                string sql = "select * from address where address = '" + address + "';";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int output = Int32.Parse(reader.GetString(0));
                        conn.Close();
                        return output;
                    }
                    conn.Close();
                    return 0;
                }
                else
                {
                    conn.Close();
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }



        internal static Boolean UpdateAddress(string address, string address2, int cityId, string postalCode, string phone, string lastUpdateBy, int addressId)
        {
            try
            {
                conn.Open();
                string sql = "update address " +
                    "set address = '"+address+"', address2 ='"+address2+"', phone = '" + phone + "', lastUpdate = CURDATE(), " +
                    "lastUpdateBy ='" + lastUpdateBy + "', cityId = "+cityId+", postalCode = '"+postalCode+"'" +
                    " where addressId = " + addressId + ";";
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
                string now = ConvertToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
                string sql = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, " +
                             "createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES (" + customerId + "," + userId + ", '" + title + "','" + description + "','" + location + "','" + contact + "','" +
                    type + "','" + url + "','" +start + "','" +end + "','"+ now+"','" + createdBy + "', '"+ now+"' ,'" + createdBy + "');";
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

        internal static void addAppointmentInFourteenMinutes()
        {
            // G. Lambda: I wanted to easily add 14 minutes to a Datetime and convert it into the format acceptable by the database.
            Func<DateTime, string> addFourteen = x =>
            {
                return x.Add(new TimeSpan(0,14,0)).ToString("yyyy-MM-dd HH:mm:ss");
            };
            conn.Open();

            string sql = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, " +
                         "createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (3,1, 'test', 'test', 'test', 'test', 'test', 'test','" + addFourteen(DateTime.UtcNow) +"','"+addFourteen(DateTime.UtcNow) +"','"+addFourteen(DateTime.UtcNow) +"', 'test', '" + addFourteen(DateTime.UtcNow) + "','test'); ";
            Console.WriteLine(sql);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        internal static void addAppointmentsOverNextWeek()
        {
            // G. Lambda: I wanted to easily add one day to a Datetime.
            Func<DateTime, DateTime> addOneDay = x =>
            {
                return x.Add(new TimeSpan(24,0, 0));
            };
            conn.Open();

            // G. Lambda: I needed to repeatedly make a similar sql query inside this function.
            Func<DateTime, DateTime> addApp = x =>
            {
                string sql = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, " +
             "createDate, createdBy, lastUpdate, lastUpdateBy) " +
            "VALUES (3,1, 'test', 'test', 'test', 'test', 'test', 'test','" + x.ToString("yyyy-MM-dd") +" 18:00:00','"+  x.ToString("yyyy-MM-dd") + " 18:00:00','"
            +  x.ToString("yyyy-MM-dd") +" 18:00:00', 'test', '" +  x.ToString("yyyy-MM-dd") + " 18:00:00','test'); ";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return DateTime.Now;
            };

            DateTime today = DateTime.Today;
            DateTime plus1 = addOneDay(today);
            DateTime plus2 = addOneDay(plus1);
            DateTime plus3 = addOneDay(plus2);
            DateTime plus4 = addOneDay(plus3);
            DateTime plus5 = addOneDay(plus4);

            addApp(today);
            addApp(plus1);
            addApp(plus2);
            addApp(plus3);
            addApp(plus4);
            addApp(plus5);

            conn.Close();
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

        internal static string[][] ReadAllAppointmentsByCustomer(int customerId)
        {
            string[][] output = { };
            try
            {
                conn.Open();
                string sql = "select customerName, title, description, location, " +
                    "contact, type, url, start, end from appointment right join " +
                    "customer on appointment.customerId = customer.customerId" +
                    " where customerId = '" + customerId + "';";
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

        internal static string[][] ReadAllAppointmentsByUser(int userId)
        {
            string[][] output = { };
            try
            {
                conn.Open();
                string sql = "select customerName, title, description, location, " +
                    "contact, type, url, start, end from appointment right join " +
                    "customer on appointment.customerId = customer.customerId" +
                    " where userId = '" + userId + "';"; 
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

        internal static string[][] ReadAllAppointmentsByUserAndCustomer(int userId, int customerId)
        {
            string[][] output = { };
            try
            {
                conn.Open();
                string sql = $"select start, end, appointmentId from appointment where userId = {userId} or customerId={customerId};";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] appointment = { reader.GetString(0), reader.GetString(1), reader.GetString(2)};
                        int length = output.Length;
                        Array.Resize(ref output, length + 1);
                        output[length] = (appointment);
                    }
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
                    " where userId = " + userId + " and start like '"+dateTime +"%';";
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

        internal static string[][][] ReadUserAppointmentsNextWeek(int userId, DateTime dateTime)
        {
            string[][][] output = new string[7][][];
            string[][] day = { };
            try
            {
                output[0] = ReadUserAppointmentsByDate(userId, dateTime.ToString("yyyy-MM-dd"));
                for (int i = 1; i < 7; i++)
                {
                    output[i] = ReadUserAppointmentsByDate(userId, dateTime.Add(new TimeSpan(24*i,0,0)).ToString("yyyy-MM-dd"));
                }
                return output;
            }
            catch
            {
                return null;
            }
        }

        internal static List<string[]> ReadAppointmentTypesByMonth(string month)
        {
            List<string[]> output = new List<string[]>();
            try
            {
                conn.Open();
                string sql = "select type, count(type) from appointment where start like '%-" + month + "-%' group by type order by count(type) desc;";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] type = { reader.GetString(0), reader.GetString(1)};
                        output.Add(type);
                    }
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

        internal static List<string[]> ReadUserAppointmentsUpcoming(string user)
        {
            List<string[]> output = new List<string[]>();
            try
            {
                conn.Open();
                string sql = "select userId, customerName, title, description, start, end from appointment " +
                    "right join customer on appointment.customerId = customer.customerId " +
                    "where userId = " + user + " and start > curdate() " +
                    "group by userId, customerName, title, description, start, end " +
                    "order by userId asc;";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] appointment = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                            reader.GetString(4), reader.GetString(5)};
                        output.Add(appointment);
                    }
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

        internal static List<string> ReadUsersWithUpcomingAppointments()
        {
            List<string> output = new List<string>();
            try
            {
                conn.Open();
                string sql = "select userId from appointment " +
                    "where start > curdate() " +
                    "group by userId " +
                    "order by userId asc;";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        output.Add(reader.GetString(0));
                    }
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

        internal static List<string[]> ReadAppointmentsByCustomerName(string customerName)
        {
            List<string[]> output = new List<string[]>();
            try
            {
                conn.Open();
                string sql = "select customerName, title, description, location, contact, type, url, start, end " +
                    "from appointment right join customer on appointment.customerId = customer.customerId " +
                    "where customerName = '" + customerName +"' order by start asc;";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] appointment = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8)};
                        output.Add(appointment);
                    }
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

        internal static List<string> ReadCustomersWithAppointments()
        {
            List<string> output = new List<string>();
            try
            {
                conn.Open();
                string sql = "select customerName from appointment right join customer " +
                    "on appointment.customerId = customer.customerId group by customerName order by customerName asc;";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        output.Add(reader.GetString(0));
                    }
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
                                                  string contact, string type, string url, string start, string end, string lastUpdateBy)
        {
            try
            {
                conn.Open();
                string now = ConvertToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
                string sql = "update appointment " +
                    "set customerId = " + customerId + ", userId = " + userId + ", title = '" + title + "', description = '" + description +
                    "', location = '" + location + "', contact = '" + contact +"', type = '" + type + "', url = '" + url +
                    "', start = '" + start + "', end = '" + end + "', lastUpdate = '" + now + "', lastUpdateBy ='" + lastUpdateBy +
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
            // G. Lambda: I needed to pad two different strings, but I don't need to do it outside of this function.
            Func<string, string> Pad = x => "0" + x;
            string[] split = calDate.Split('/');
            string month = split[0];
            if (month.Length == 1) month = Pad(month);
            string day = split[1];
            if (day.Length == 1) day = Pad(day);
            string year = split[2];
            return year + "-" + month + "-" + day;
        }

        // E.   Provide the ability to automatically adjust appointment times based on user time zones and daylight-saving time.
        internal static DateTime ConvertToLocalTime(string date)
        {
            DateTime dt = DateTime.Parse(date);
            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            TimeSpan currentOffset = curTimeZone.GetUtcOffset(DateTime.Now);
            return dt.Add(currentOffset);
        }

        // E.   Provide the ability to automatically adjust appointment times based on user time zones and daylight-saving time.
        internal static DateTime ConvertToUtc(DateTime local)
        {
            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            TimeSpan currentOffset = curTimeZone.GetUtcOffset(DateTime.Now);
            return local.Subtract(currentOffset);
        }

        // H.  Write code to provide reminders and alerts 15 minutes in advance of an appointment, based on the user’s log-in.
        internal static Boolean checkForUpcomingAppointment(User user)
        {
            string[][] appointments = ReadAllAppointmentsByUser(user.userId);
            if (appointments != null)
            {
                DateTime login = DateTime.UtcNow;
                DateTime start;
                TimeSpan timeSpan;
                foreach (string[] appointment in appointments)
                {
                    start = DateTime.Parse(appointment[7]);
                    timeSpan = start - login;
                    if (timeSpan.TotalMinutes > 0 && timeSpan.TotalMinutes < 15) return true;
                }
                return false;
            }
            return false;
        }

        //J.Provide the ability to track user activity by recording timestamps for user log-ins
        //in a.txt file.Each new record should be appended to the log file if the file already exists.
        internal static void Log(User user)
        {
            using (StreamWriter writer = new StreamWriter("../../Logs and Reports/Log.txt", true))
            {
                string log = $"Login Time: {DateTime.Now.ToString()}, User ID: {user.userId}, Username: {user.userName}";
                writer.WriteLine(log);
            }
        }

        // I. Provide the ability to generate number of appointment types by month report
        internal static Boolean AppointmentTypesReport()
        {
            // G. Lambda Func: I needed to call a function many times that would only be used inside this report function.
            Func<List<string[]>, StreamWriter, String, Boolean> MonthReport = (x, y, z) =>
            {
                y.WriteLine(z);
                y.WriteLine("---------------------------------------------------------------------------------------------------");
                if (x != null) {
                    foreach (string[] appointment in x)
                    {
                        y.WriteLine($"Type: {appointment[0]}, Number: {appointment[1]}");
                    }
                }
                else
                {
                    y.WriteLine("No appointments this month");
                }
                y.WriteLine("===================================================================================================");
                y.WriteLine();
                return true;
            };

            try
            {
                using (StreamWriter writer = new StreamWriter("../../Logs and Reports/AppointmentTypesReport.txt"))
                {
                    MonthReport(ReadAppointmentTypesByMonth("01"), writer, "January");
                    MonthReport(ReadAppointmentTypesByMonth("02"), writer, "February");
                    MonthReport(ReadAppointmentTypesByMonth("03"), writer, "March");
                    MonthReport(ReadAppointmentTypesByMonth("04"), writer, "April");
                    MonthReport(ReadAppointmentTypesByMonth("05"), writer, "May");
                    MonthReport(ReadAppointmentTypesByMonth("06"), writer, "June");
                    MonthReport(ReadAppointmentTypesByMonth("07"), writer, "July");
                    MonthReport(ReadAppointmentTypesByMonth("08"), writer, "August");
                    MonthReport(ReadAppointmentTypesByMonth("09"), writer, "September");
                    MonthReport(ReadAppointmentTypesByMonth("10"), writer, "October");
                    MonthReport(ReadAppointmentTypesByMonth("11"), writer, "November");
                    MonthReport(ReadAppointmentTypesByMonth("12"), writer, "December");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // I. Provide the ability to generate the schedule for each consultant report
        internal static Boolean ConsultantSchedulesReport()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("../../Logs and Reports/ConsultantAppointmentsReport.txt"))
                {
                    List<string> users = ReadUsersWithUpcomingAppointments();
                    foreach (string user in users)
                    {
                        writer.WriteLine("User ID: " + user);
                        writer.WriteLine("---------------------------------------------------------------------------------------------------");
                        List<string[]> appointments = ReadUserAppointmentsUpcoming(user);
                        if (appointments != null)
                        {

                            foreach (string[] appointment in appointments)
                            {
                                writer.WriteLine($"Start Time: {appointment[4]}, End Time: {appointment[5]}, Customer: {appointment[1]}, Title: {appointment[2]}, Description: {appointment[3]}");
                                writer.WriteLine("----------");
                            }
                        }
                        else
                        {
                            writer.WriteLine($"{user} has no appointments");
                        }
                        writer.WriteLine("===================================================================================================");
                        writer.WriteLine();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // I. Provide the ability to generate one additional report (A report of every appointment for each customer)
        internal static Boolean CustomerAppointmentsReport()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("../../Logs and Reports/CustomerAppointmentsReport.txt"))
                {
                    List<string> customers = ReadCustomersWithAppointments();
                    foreach (string customer in customers)
                    {
                        writer.WriteLine(customer);
                        writer.WriteLine("---------------------------------------------------------------------------------------------------");
                        List<string[]> appointments = ReadAppointmentsByCustomerName(customer);
                        if (appointments != null)
                        {
                            foreach (string[] appointment in appointments)
                            {
                                try
                                {
                                    writer.WriteLine($"Start Time: {appointment[4]}, End Time: {appointment[5]}, Customer: {appointment[1]}, Title: {appointment[2]}, Description: {appointment[3]}");
                                    writer.WriteLine("----------");
                                }
                                catch
                                {

                                }
                            }
                        }
                        else
                        {
                            writer.WriteLine($"{customer} has no appointments");
                        }
                        writer.WriteLine("===================================================================================================");
                        writer.WriteLine();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // F. Exception Controls: scheduling an appointment outside business hours
        internal static Boolean CheckHours(string st, string e)
        {
            DateTime start = DateTime.Parse(st);
            DateTime end = DateTime.Parse(e);
            DateTime open = DateTime.Parse(start.ToShortDateString()).Add(new TimeSpan(8, 0, 0));
            DateTime close = open.Add(new TimeSpan(9, 0, 0));
            
            if (start > close || start < open || end > close || end < open)
            {
                return false;
            }

            return true;
        }

        // F. Exception Controls: scheduling overlapping appointments
        internal static Boolean DoesOverlap(int userId, int customerId, DateTime start, DateTime end, int appointmentId = 0)
        {
            string[][] appointments = ReadAllAppointmentsByUserAndCustomer(userId, customerId);

            foreach (string[] appointment in appointments)
            {
                if ((start >= DateTime.Parse(appointment[0]) && start < DateTime.Parse(appointment[1]) ||
                    (end > DateTime.Parse(appointment[0]) && end <= DateTime.Parse(appointment[1])) ||
                    (start <= DateTime.Parse(appointment[0]) && end >= DateTime.Parse(appointment[1])) ||
                    (start > end)) && (appointmentId != Int32.Parse(appointment[2]))){
                    return true;
                }
            }

            return false;
        }

        // F. Exception Controls: entering nonexistent or invalid customer data
        internal static void CheckCustomerAndUserExist(int customerId, int userId)
        {
            if (ReadCustomer(customerId) == null)
            {
                throw new DoesNotExistException("Customer", customerId);
            }
            if (ReadUser(userId) == null)
            {
                throw new DoesNotExistException("User", userId);
            }
        }
    }

    // F. Exception Controls: scheduling overlapping appointments
    internal class OverlapException : Exception
    {
        internal OverlapException()
        {
            MessageBox.Show("Appointment overlaps with an existing appointment.");
        }
    }

    // F. Exception Controls: entering nonexistent or invalid customer data
    internal class DoesNotExistException : Exception
    {
        internal DoesNotExistException(string s, int i)
        {
            MessageBox.Show($"{s} with ID {i} does not exist.");
        }
    }
}
