using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

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
            // A.   Create a log-in form that can determine the user’s location and translate log-in
            // and error control messages (e.g., “The username and password did not match.”) into the
            // user’s language and in one additional language.
            // Uncomment one of these to force different cultures
            //System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-us");
            //System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("es-MX");
            //System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("de");

            // Enable this to seed database
            // Utilities.SeedData();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Enable this to add an appointment in fourteen minutes for userId 1. Used to test appointment reminder.
            //Utilities.addAppointmentInFourteenMinutes();

            // Enable this to add an appointments over the next week for userId 1. Used to test weekly calendar.
            Utilities.addAppointmentsOverNextWeek();

            Application.Run(new Login());
        }
    }
}
