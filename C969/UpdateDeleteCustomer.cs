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
    public partial class UpdateDeleteCustomer : Form
    {
        User user;
        string[] customer;
        string customerId;
        public UpdateDeleteCustomer(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        internal void EnableButtons()
        {
            if (NameBox.Text != "" && Ad1Box.Text != "" && Ad2Box.Text != "" && PhoneBox.Text != "" && PCBox.Text != "" && CityBox.Text != "")
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
            if (this.customer != null)
            {
                NameBox.Enabled = true;
                Ad1Box.Enabled = true;
                Ad2Box.Enabled = true;
                PhoneBox.Enabled = true;
                PCBox.Enabled = true;
                CityBox.Enabled = true;
            }
            else
            {
                NameBox.Enabled = false;
                Ad1Box.Enabled = false;
                Ad2Box.Enabled = false;
                PhoneBox.Enabled = false;
                PCBox.Enabled = false;
                CityBox.Enabled = false;
            }
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void Ad1Box_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void Ad2Box_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void PhoneBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void PCBox_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void CityBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (CityBox.Text != "")
                {
                    Int32.Parse(CityBox.Text);
                }
            }
            catch
            {
                MessageBox.Show("City ID must be an integer");
                CityBox.Text="";
            }
            EnableButtons();
        }

        private void CustIDBox_TextChanged(object sender, EventArgs e)
        {
            if (CustIDBox.Text != "")
            {
                LookupButton.Enabled = true;
            }
            else
            {
                LookupButton.Enabled = false;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try {
                Utilities.DeleteCustomer(Int32.Parse(this.customerId));
                MessageBox.Show("Customer has been deleted!");
                CustIDBox.Text = "";
                this.customer = null;
                NameBox.Text = "";
                Ad1Box.Text = "";
                Ad2Box.Text = "";
                PhoneBox.Text = "";
                PCBox.Text = "";
                CityBox.Text = "";
                EnableFields();
            }
            catch
            {
                MessageBox.Show("Customer has not been deleted.");
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try {
                if (Utilities.UpdateCustomer(NameBox.Text, Ad1Box.Text, Ad2Box.Text, this.user.userName, PhoneBox.Text,
                Int32.Parse(CityBox.Text), this.user.userName, PCBox.Text, Int32.Parse(this.customerId), 1))
                {
                    MessageBox.Show("Customer has been updated!");
                    string temp = CustIDBox.Text;
                    CustIDBox.Text = "";
                    CustIDBox.Text = temp;
                }
                else
                {
                    MessageBox.Show("Customer has not been updated.");
                }
            }
            catch
            {
                MessageBox.Show("Customer has not been updated.");
            }
        }

        private void LookupButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.customerId = CustIDBox.Text;
                this.customer = Utilities.ReadCustomer(Int32.Parse(this.customerId));
                NameBox.Text = this.customer[1];
                Ad1Box.Text = this.customer[9];
                Ad2Box.Text = this.customer[10];
                PhoneBox.Text = this.customer[13];
                PCBox.Text = this.customer[12];
                CityBox.Text = this.customer[11];
            }
            catch
            {
                MessageBox.Show($"Customer with ID {this.customerId} does not exist");
                this.customer = null;
                this.customerId = null;
                NameBox.Text = "";
                Ad1Box.Text = "";
                Ad2Box.Text = "";
                PhoneBox.Text = "";
                PCBox.Text = "";
                CityBox.Text = "";
            }
            EnableFields();
        }
    }
}
