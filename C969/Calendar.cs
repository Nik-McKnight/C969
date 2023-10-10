using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969
{
    public partial class Calendar : Form
    {
        internal string[][] userAppointments;
        internal int userId;
        public Calendar(User user)
        {
            InitializeComponent();
            this.userId = user.userId;
            userAppointments = Utilities.ReadAllAppointmentsByUser(userId);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            string dateTime = Utilities.ConvertDate(e.Start.ToShortDateString());
            string[][] tempAppointments = Utilities.ReadUserAppointmentsByDate(userId, dateTime);
            if (tempAppointments == null)
            {
                MessageBox.Show("No appointments on this day");

            }
            else
            {
                var appointments = new Appointments(tempAppointments);
                appointments.Show();
            }
        }
    }
}
