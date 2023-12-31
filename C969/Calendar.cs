﻿using System;
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
    // D.Provide the ability to view the calendar by month.
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

        private void UDCustButton_Click(object sender, EventArgs e)
        {
            UpdateDeleteCustomer udc = new UpdateDeleteCustomer(user);
            udc.Show();
        }

        private void createAppButton_Click(object sender, EventArgs e)
        {
            CreateAppointment ca = new CreateAppointment(user);
            ca.Show();
        }

        private void UDAppButton_Click(object sender, EventArgs e)
        {
            UpdateDeleteAppointment uda = new UpdateDeleteAppointment(user);
            uda.Show();
        }
    }
}
