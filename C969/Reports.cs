
using System.Windows.Forms;

namespace C969
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void TypesButton_Click(object sender, System.EventArgs e)
        {
            if (Utilities.AppointmentTypesReport())
            {
                MessageBox.Show("Report Generated!");
            }
            else
            {
                MessageBox.Show("Report Not Generated!");
            }
        }

        private void ConsultantsButton_Click(object sender, System.EventArgs e)
        {
            if (Utilities.ConsultantSchedulesReport())
            {
                MessageBox.Show("Report Generated!");
            }
            else
            {
                MessageBox.Show("Report Not Generated!");
            }
        }
    }
}
