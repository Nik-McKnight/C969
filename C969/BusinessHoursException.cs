using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace C969
{
    internal class BusinessHoursException : Exception
    {
        internal BusinessHoursException()
        {
            MessageBox.Show("You may only schedule an appointment if it falls between 8 am and 5 pm local time.");
        }
    }
}
