using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    internal class SeedData
    {
        internal SeedData(MySqlConnection conn)
        {
            popCountry(conn);
            popCity(conn);
            popAddress(conn);
            popCustomer(conn);
            popUser(conn);
            popAppointment(conn);

        }
        public static void popCountry(MySqlConnection conn)
        {
            try
            {
                using (var reader = new System.IO.StreamReader(@"..\..\mock data\country.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var fields = line.Split('\u002C');
                        string country = fields[0];
                        if (country == "country") continue;
                        string createDate = fields[1];
                        string createdBy = fields[2];
                        string lastUpdate = fields[3];
                        string lastUpdateBy = fields[4];
                        string sql = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('" + country + "', CURDATE(),'" + createdBy + "', CURDATE() ,'" + lastUpdateBy + "');";
                        Console.WriteLine(sql);
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void popCity(MySqlConnection conn)
        {
            try
            {
                using (var reader = new System.IO.StreamReader(@"..\..\mock data\city.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var fields = line.Split('\u002C');
                        string city = fields[0];
                        if (city == "city") continue;
                        string countryId =fields[1];
                        string createDate = fields[2];
                        string createdBy = fields[3];
                        string lastUpdate = fields[4];
                        string lastUpdateBy = fields[5];
                        string sql = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('" + city + "','" + countryId + "', CURDATE(),'" + createdBy + "', CURDATE() ,'" + lastUpdateBy + "');";
                        Console.WriteLine(sql);
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void popAddress(MySqlConnection conn)
        {
            try
            {
                using (var reader = new System.IO.StreamReader(@"..\..\mock data\address.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var fields = line.Split('\u002C');
                        string address = fields[0];
                        if (address == "address") continue;
                        string address2 = fields[1];
                        string cityId = fields[2];
                        string postalCode = fields[3];
                        string phone = fields[4];
                        string createDate = fields[5];
                        string createdBy = fields[6];
                        string lastUpdate = fields[7];
                        string lastUpdateBy = fields[8];
                        string sql = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                            "VALUES ('" + address + "','" + address2 + "','" + cityId + "','" + postalCode + "','" + phone + "', CURDATE(),'" + createdBy + "', CURDATE() ,'" + lastUpdateBy + "');";
                        Console.WriteLine(sql);
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void popCustomer(MySqlConnection conn)
        {
            try
            {
                using (var reader = new System.IO.StreamReader(@"..\..\mock data\customer.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var fields = line.Split('\u002C');
                        string customerName = fields[0];
                        if (customerName == "customerName") continue;
                        string addressId = fields[1];
                        string active = fields[2];
                        string createDate = fields[3];
                        string createdBy = fields[4];
                        string lastUpdate = fields[5];
                        string lastUpdateBy = fields[6];
                        string sql = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                            "VALUES ('" + customerName + "','" + addressId + "','" + active + "', CURDATE(),'" + createdBy + "', CURDATE() ,'" + lastUpdateBy + "');";
                        Console.WriteLine(sql);
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void popUser(MySqlConnection conn)
        {
            try
            {
                using (var reader = new System.IO.StreamReader(@"..\..\mock data\user.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var fields = line.Split('\u002C');
                        string userName = fields[0];
                        if (userName == "userName") continue;
                        string password = fields[1];
                        string active = fields[2];
                        string createDate = fields[3];
                        string createdBy = fields[4];
                        string lastUpdate = fields[5];
                        string lastUpdateBy = fields[6];
                        string sql = "INSERT INTO user (userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                            "VALUES ('" + userName + "','" + password + "','" + active + "', CURDATE(),'" + createdBy + "', CURDATE() ,'" + lastUpdateBy + "');";
                        Console.WriteLine(sql);
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void popAppointment(MySqlConnection conn)
        {
            try
            {
                using (var reader = new System.IO.StreamReader(@"..\..\mock data\appointment.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var fields = line.Split('\u002C');
                        string customerId = fields[0];
                        if (customerId == "customerId") continue;
                        string userId = fields[1];
                        string title = fields[2];
                        string description = fields[3];
                        string location = fields[4];
                        string contact = fields[5];
                        string type = fields[6];
                        string url = fields[7];
                        string start = fields[8];
                        string end = fields[9];
                        string createDate = fields[10];
                        string createdBy = fields[11];
                        string lastUpdate = fields[12];
                        string lastUpdateBy = fields[13];
                        string sql = "INSERT INTO appointment (customerId, userId, title, description, " +
                            "location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                            "VALUES ('" + customerId + "','" + userId + "','" + title + "','" + description + "','" + location +
                            "','" + contact + "','" + type + "','" + url + "','" + start  + "','" + end + "', CURDATE(),'" 
                            + createdBy + "', CURDATE() ,'" + lastUpdateBy + "');";
                        Console.WriteLine(sql);
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }

}
