using C969.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace C969
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            ResourceManager rm = new ResourceManager("C969.strings",
                Assembly.GetExecutingAssembly());
            String user = rm.GetString("USERNAME", CultureInfo.CurrentCulture);
            String pass = rm.GetString("PASSWORD", CultureInfo.CurrentCulture);
            String login = rm.GetString("LOGIN", CultureInfo.CurrentCulture);
            UserLabel.Text = user;
            PassLabel.Text = pass;
            SubmitButton.Text = login;
        }
    }
}
