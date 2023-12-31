﻿using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace C969
{
    public partial class Login : Form
    {
        ResourceManager pri;
        ResourceManager sec;
        User user;
        public Login()
        {
            InitializeComponent();

            // A.   Create a log-in form that can determine the user’s location and translate log-in
            // and error control messages (e.g., “The username and password did not match.”) into the
            // user’s language and in one additional language.

            pri = new ResourceManager("C969.strings_" + Utilities.GetPrimaryCulture(),
                Assembly.GetExecutingAssembly());
            sec = new ResourceManager("C969.strings_" + Utilities.GetSecondaryCulture(),
                Assembly.GetExecutingAssembly());

            string loginTruePri = pri.GetString("LOGINTRUE");
            string loginFalsePri = pri.GetString("LOGINFALSE");


            UserLabelPri.Text = pri.GetString("USERNAME");
            PassLabelPri.Text = pri.GetString("PASSWORD");
            UserLabelSec.Text = sec.GetString("USERNAME");
            PassLabelSec.Text = sec.GetString("PASSWORD");
            SubmitButton.Text = pri.GetString("LOGIN") + " / " + sec.GetString("LOGIN");
            RegisterButton.Text = pri.GetString("REGISTER") + " / " + sec.GetString("REGISTER");
        }

        internal Boolean LogIn()
        {
            string[] user = Utilities.LoginQuery(this.UserBox.Text, this.PassBox.Text);
            if (user != null)
            {
                this.user = new User(user);

                //J.Provide the ability to track user activity by recording timestamps for user log-ins
                //in a.txt file.Each new record should be appended to the log file if the file already exists.
                Utilities.Log(this.user);

                // H.  Write code to provide reminders and alerts 15 minutes in advance of an appointment, based on the user’s log-in.
                if (Utilities.checkForUpcomingAppointment(this.user) == true)
                {
                    MessageBox.Show(pri.GetString("APPOINTMENT") + " / " + sec.GetString("APPOINTMENT"));
                }

                var calendar = new Calendar(this.user);
                calendar.Show();
                return true;
            }
            else
            {
                // F. Exception Controls: entering an incorrect username and password
                MessageBox.Show(pri.GetString("LOGINFALSE") + " / " + sec.GetString("LOGINFALSE"));
                return false;
            }
        }

        internal Boolean Register()
        {
            if (Utilities.CreateUser(this.UserBox.Text, this.PassBox.Text))
            {
                MessageBox.Show(pri.GetString("REGISTERTRUE") + " / " + sec.GetString("REGISTERTRUE"));
                return true;
            }
            else
            {
                MessageBox.Show(pri.GetString("REGISTERFALSE") + " / " + sec.GetString("REGISTERFALSE"));
                return false;
            }
        }

        internal void EnableButtons()
        {
            if (UserBox.Text != "" && PassBox.Text != "")
            {
                SubmitButton.Enabled = true;
                RegisterButton.Enabled = true;
            }
            else
            {
                SubmitButton.Enabled = false;
                RegisterButton.Enabled = false;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            LogIn();
            
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void UserBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void PassBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

    }
}
