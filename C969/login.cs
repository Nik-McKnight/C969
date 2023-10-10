using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace C969
{
    public partial class Login : Form
    {
        ResourceManager pri;
        ResourceManager sec;
        public Login()
        {
            InitializeComponent();

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
            if (Utilities.LoginQuery(this.UserBox.Text, this.PassBox.Text))
            {
                MessageBox.Show(pri.GetString("LOGINTRUE"));
                return true;
            }
            else
            {
                MessageBox.Show(pri.GetString("LOGINFALSE"));
                return false;
            }
        }

        internal Boolean Register()
        {
            if (Utilities.CreateUser(this.UserBox.Text, this.PassBox.Text))
            {
                MessageBox.Show(pri.GetString("REGISTERTRUE"));
                return true;
            }
            else
            {
                MessageBox.Show(pri.GetString("REGISTERFALSE"));
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
