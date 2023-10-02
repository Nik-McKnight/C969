﻿using MySql.Data.MySqlClient;
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

            // Query
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

            using (var reader = new System.IO.StreamReader(@"..\..\mock data\address.csv"))
            {
                List<string> listA = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    listA.Add(line);
                }
                Console.WriteLine(listA[1]);
            }



            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

        }
    }
}