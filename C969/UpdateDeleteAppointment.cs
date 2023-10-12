using System;
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
    public partial class UpdateDeleteAppointment : Form
    {
        User user;
        int appointmentId;
        string[] appointment;

        public UpdateDeleteAppointment(User user)
        {
            this.user = user;
            InitializeComponent();
        }
        internal void EnableButtons()
        {
            if (CustIdBox.Text != "" && UserIDBox.Text != "" && TitleBox.Text != "" && DescBox.Text != "" && LocationBox.Text != "" &&
                EmailBox.Text != "" && TypeBox.Text != "" && URLBox.Text != "" && StartBox.Text != "" && EndBox.Text != "")
            {
                DeleteButton.Enabled = true;
                UpdateButton.Enabled = true;
            }
            else
            {
                DeleteButton.Enabled = false;
                UpdateButton.Enabled = false;
            }
        }

        internal void EnableFields()
        {
            if (this.appointment != null)
            {
                CustIdBox.Enabled = true;
                UserIDBox.Enabled = true;
                TitleBox.Enabled = true;
                DescBox.Enabled = true;
                LocationBox.Enabled = true;
                EmailBox.Enabled = true;
                TypeBox.Enabled = true;
                URLBox.Enabled = true;
                StartBox.Enabled = true;
                EndBox.Enabled = true;
            }
            else
            {
                CustIdBox.Enabled = false;
                UserIDBox.Enabled = false;
                TitleBox.Enabled = false;
                DescBox.Enabled = false;
                LocationBox.Enabled = false;
                EmailBox.Enabled = false;
                TypeBox.Enabled = false;
                URLBox.Enabled = false;
                StartBox.Enabled = false;
                EndBox.Enabled = false;
            }
        }
        private void AppIDBox_TextChanged(object sender, EventArgs e)
        {
            if (AppIDBox.Text != "")
            {
                LookupButton.Enabled = true;
            }
            else
            {
                LookupButton.Enabled = false;
            }
        }

        private void CustIdBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (CustIdBox.Text != "")
                {
                    Int32.Parse(CustIdBox.Text);
                }
            }
            catch
            {
                MessageBox.Show("Customer ID must be an integer");
                CustIdBox.Text="";
            }
            EnableButtons();
        }

        private void UserIDBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserIDBox.Text != "")
                {
                    Int32.Parse(UserIDBox.Text);
                }
            }
            catch
            {
                MessageBox.Show("User ID must be an integer");
                UserIDBox.Text="";
            }
            EnableButtons();
        }

        private void TitleBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void DescBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void LocationBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void EmailBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void TypeBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void URLBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void StartBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void EndBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Utilities.DeleteAppointment(this.appointmentId);
                this.appointment =null;
                MessageBox.Show("Appointment has been deleted!");
                AppIDBox.Text = "";
                CustIdBox.Text = "";
                UserIDBox.Text = "";
                TitleBox.Text = "";
                DescBox.Text = "";
                LocationBox.Text = "";
                EmailBox.Text = "";
                TypeBox.Text  = "";
                URLBox.Text  = "";
                StartBox.Text  = "";
                EndBox.Text  = "";
                EnableFields();
            }
            catch
            {
                MessageBox.Show("Customer has not been deleted.");
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                Utilities.CheckCustomerAndUserExist(Int32.Parse(CustIdBox.Text), Int32.Parse(UserIDBox.Text));

                if (!Utilities.CheckHours(StartBox.Text, EndBox.Text))
                {
                    throw new BusinessHoursException();
                }

                if (Utilities.DoesOverlap(Int32.Parse(UserIDBox.Text), Int32.Parse(CustIdBox.Text), Utilities.ConvertToUtc(DateTime.Parse(StartBox.Text)), Utilities.ConvertToUtc(DateTime.Parse(EndBox.Text)), this.appointmentId))
                {
                    throw new OverlapException();
                }

                string start = Utilities.ConvertToUtc(DateTime.Parse(StartBox.Text)).ToString("yyyy-MM-dd HH:mm:ss");
                string end = Utilities.ConvertToUtc(DateTime.Parse(EndBox.Text)).ToString("yyyy-MM-dd HH:mm:ss");
                if (Utilities.UpdateAppointment(this.appointmentId, Int32.Parse(CustIdBox.Text), Int32.Parse(UserIDBox.Text), TitleBox.Text, DescBox.Text,
                LocationBox.Text, EmailBox.Text, TypeBox.Text, URLBox.Text, start, end, this.user.userName))
                {
                    MessageBox.Show("Appointment has been updated!");
                    string temp = AppIDBox.Text;
                    AppIDBox.Text = "";
                    AppIDBox.Text = temp;
                }
                else
                {
                    MessageBox.Show("Appointment has not been updated.");
                }
            }
            catch
            {
                MessageBox.Show("Appointment has not been updated.");
            }
        }

        private void LookupButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.appointmentId = Int32.Parse(AppIDBox.Text);
                this.appointment = Utilities.ReadAppointment(this.appointmentId);
                CustIdBox.Text = appointment[1];
                UserIDBox.Text = appointment[2];
                TitleBox.Text = appointment[3];
                DescBox.Text = appointment[4];
                LocationBox.Text = appointment[5];
                EmailBox.Text = appointment[6];
                TypeBox.Text = appointment[7];
                URLBox.Text = appointment[8];
                StartBox.Text = Utilities.ConvertToLocalTime(appointment[9]).ToString();
                EndBox.Text = Utilities.ConvertToLocalTime(appointment[10]).ToString();
            }
            catch
            {
                this.appointment = null;
                CustIdBox.Text = "";
                UserIDBox.Text = "";
                TitleBox.Text = "";
                DescBox.Text = "";
                LocationBox.Text = "";
                EmailBox.Text = "";
                TypeBox.Text  = "";
                URLBox.Text  = "";
                StartBox.Text  = "";
                EndBox.Text  = "";
            }
            EnableFields();
        }
    }
}
