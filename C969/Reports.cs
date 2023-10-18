
using System.Windows.Forms;

namespace C969
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        // I. Provide the ability to generate number of appointment types by month report
        private void TypesButton_Click(object sender, System.EventArgs e)
        {
            if (Utilities.AppointmentTypesReport())
            {
                MessageBox.Show("Report generated to 'C969/Logs and Reports/AppointmentTypesReport.txt'.\n\n" +
                    "Be sure to look in file explorer if the file does not show up in the solution explorer.");
            }
            else
            {
                MessageBox.Show("Report not generated!");
            }
        }

        // I. Provide the ability to generate the schedule for each consultant report
        private void ConsultantsButton_Click(object sender, System.EventArgs e)
        {
            if (Utilities.ConsultantSchedulesReport())
            {
                MessageBox.Show("Report generated to 'C969/Logs and Reports/ConsultantAppointmentsReport.txt'.\n\n" +
                    "Be sure to look in file explorer if the file does not show up in the solution explorer.");
            }
            else
            {
                MessageBox.Show("Report not generated!");
            }
        }

        // I. Provide the ability to generate one additional report (A report of every appointment for each customer)
        private void CustomerButton_Click(object sender, System.EventArgs e)
        {
            if (Utilities.CustomerAppointmentsReport())
            {
                MessageBox.Show("Report generated to 'C969/Logs and Reports/CustomerAppointmentsReport.txt'.\n\n" +
                    "Be sure to look in file explorer if the file does not show up in the solution explorer.");
            }
            else
            {
                MessageBox.Show("Report not generated!");
            }
        }
    }
}
