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

            ResourceManager pri = new ResourceManager("C969.strings_" + Utilities.getPrimaryCulture(),
                Assembly.GetExecutingAssembly());
            ResourceManager sec = new ResourceManager("C969.strings_" + Utilities.getSecondaryCulture(),
                Assembly.GetExecutingAssembly());

            Console.WriteLine(pri + " " + sec);

            String userPri = pri.GetString("USERNAME");
            String passPri = pri.GetString("PASSWORD");
            String loginPri = pri.GetString("LOGIN");
            UserLabelPri.Text = pri.GetString("USERNAME");
            PassLabelPri.Text = pri.GetString("PASSWORD");
            UserLabelSec.Text = sec.GetString("USERNAME");
            PassLabelSec.Text = sec.GetString("PASSWORD");
            SubmitButton.Text = pri.GetString("LOGIN") + " / " + sec.GetString("LOGIN");
        }


    }
}
