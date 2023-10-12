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
    public partial class CreateCustomer : Form
    {
        User user;
        public CreateCustomer(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        internal void EnableButtons()
        {
            if (NameBox.Text != "" && Ad1Box.Text != "" && Ad2Box.Text != "" && PhoneBox.Text != "" && PCBox.Text != "" && CityBox.Text != "")
            {
                SubmitButton.Enabled = true;
            }
            else
            {
                SubmitButton.Enabled = false;
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
            EnableButtons();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Utilities.CreateCustomer(NameBox.Text, Ad1Box.Text, Ad2Box.Text, this.user.userName, PhoneBox.Text, 
                Int32.Parse(CityBox.Text), this.user.userName, PCBox.Text))
            {
                MessageBox.Show("Customer created!");
            }

            else
            {
                MessageBox.Show("Customer not created.");
            }
        }
    }
}
