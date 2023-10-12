﻿using System;
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
    public partial class CreateAppointment : Form
    {
        User user;
        public CreateAppointment(User user)
        {
            this.user = user;
            InitializeComponent();
            StartBox.Text = DateTime.Now.ToString();
            EndBox.Text = DateTime.Now.ToString();
        }

        internal void EnableButtons()
        {
            if (CustIdBox.Text != "" && UserIDBox.Text != "" && TitleBox.Text != "" && DescBox.Text != "" && LocationBox.Text != "" &&
                EmailBox.Text != "" && TypeBox.Text != "" && URLBox.Text != "" && StartBox.Text != "" && EndBox.Text != "")
            {
                SubmitButton.Enabled = true;
            }
            else
            {
                SubmitButton.Enabled = false;
            }
        }

        private void EmailBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void TypeBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void UserIDBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void URLBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void TitleBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void StartBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void DescBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void EndBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void LocationBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void CustIdBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string start = DateTime.Parse(StartBox.Text).ToString("yyyy-MM-dd HH:mm:ss");
                string end = DateTime.Parse(StartBox.Text).ToString("yyyy-MM-dd HH:mm:ss");
                if (Utilities.CreateAppointment(Int32.Parse(CustIdBox.Text), Int32.Parse(UserIDBox.Text), TitleBox.Text, DescBox.Text,
                LocationBox.Text, EmailBox.Text, TypeBox.Text, URLBox.Text, start, end, this.user.userName))
                {
                    MessageBox.Show("Appointment has been created!");
                }
                else
                {
                    MessageBox.Show("Appointment has not been created.");
                }
            }
            catch
            {
                MessageBox.Show("Appointment has not been created.");
            }
        }
    }
}