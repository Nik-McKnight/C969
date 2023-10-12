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
        internal User user;
        public Calendar(User user)
        {
            InitializeComponent();
            this.user = user;
            userAppointments = Utilities.ReadAllAppointmentsByUser(this.user.userId);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            string dateTime = Utilities.ConvertDate(e.Start.ToShortDateString());
            string[][] tempAppointments = Utilities.ReadUserAppointmentsByDate(this.user.userId, dateTime);
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

        private void button1_Click(object sender, EventArgs e)
        {
            WeeklyCalendar wc = new WeeklyCalendar(this.user);
            wc.Show();
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
        }

        private void CreateUserButton_Click(object sender, EventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer(this.user);
            createCustomer.Show(); 
        }
    }
}
