using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969
{
    public partial class Appointments : Form
    {
        string[][] appointments;
        public Appointments(string[][] appointments)
        {
            InitializeComponent();

            this.appointments = appointments;
            if (appointments != null)
            {
                listView1.GridLines = true;
                listView1.Columns.Add("Customer Name");
                listView1.Columns.Add("Title");
                listView1.Columns.Add("Description");
                listView1.Columns.Add("Location");
                listView1.Columns.Add("Contact");
                listView1.Columns.Add("Type");
                listView1.Columns.Add("URL");
                listView1.Columns.Add("Start");
                listView1.Columns.Add("End");
                listView1.Columns[0].Width = -2;
                listView1.Columns[1].Width = -2;
                listView1.Columns[4].Width = -2;
                listView1.Columns[5].Width = -2;
                listView1.Columns[6].Width = -2;
                listView1.Columns[7].Width = -2;
                listView1.Columns[8].Width = -2;
                foreach (string[] appointment in this.appointments)
                {
                    try
                    {
                        listView1.Items.Add(new ListViewItem(appointment));
                    }
                    catch
                    {
                        break;
                    }

                }
            }
            else
            {
                listView1.Items.Add("No appointments today");
            }
        }

        internal string[] CastObjToStringArray(Object obj)
        {
            return Array.ConvertAll((object[])obj, Convert.ToString);
        }
    }
}
