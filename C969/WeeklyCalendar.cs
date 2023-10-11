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
    public partial class WeeklyCalendar : Form
    {
        User user;
        string[][][] appointments;

        public WeeklyCalendar(User user)
        {
            this.user = user;
            this.appointments = Utilities.ReadUserAppointmentsNextWeek(this.user.userId, DateTime.Today);
            InitializeComponent();
            setUpViews();
        }

        internal void setUpViews()
        {
            DateTime today = DateTime.Today;
            DateTime plus1 = today.Add(new TimeSpan(24, 0, 0));
            DateTime plus2 = plus1.Add(new TimeSpan(24, 0, 0));
            DateTime plus3 = plus2.Add(new TimeSpan(24, 0, 0));
            DateTime plus4 = plus3.Add(new TimeSpan(24, 0, 0));
            DateTime plus5 = plus4.Add(new TimeSpan(24, 0, 0));
            DateTime plus6 = plus5.Add(new TimeSpan(24, 0, 0));
            //string[][] appointments0 = Utilities.ReadUserAppointmentsByDate(this.user.userId, today.ToString("yyyy-MM-dd"));
            //string[][] appointments1 = Utilities.ReadUserAppointmentsByDate(this.user.userId, plus1.ToString("yyyy-MM-dd"));
            //string[][] appointments2 = Utilities.ReadUserAppointmentsByDate(this.user.userId, plus2.ToString("yyyy-MM-dd"));
            //string[][] appointments3 = Utilities.ReadUserAppointmentsByDate(this.user.userId, plus3.ToString("yyyy-MM-dd"));
            //string[][] appointments4 = Utilities.ReadUserAppointmentsByDate(this.user.userId, plus4.ToString("yyyy-MM-dd"));
            //string[][] appointments5 = Utilities.ReadUserAppointmentsByDate(this.user.userId, plus5.ToString("yyyy-MM-dd"));
            //string[][] appointments6 = Utilities.ReadUserAppointmentsByDate(this.user.userId, plus6.ToString("yyyy-MM-dd"));
            //label1.Text = "Today";
            //initView(listView1, appointments[0]);
            //label2.Text = "Tomorrow";
            //initView(listView2, appointments[1]);
            //label3.Text = plus2.ToString("MMMM dd, yyyy");
            //initView(listView3, appointments[2]);
            //label4.Text = plus3.ToString("MMMM dd, yyyy");
            //initView(listView4, appointments[3]);
            //label5.Text = plus4.ToString("MMMM dd, yyyy");
            //initView(listView5, appointments[4]);
            //label6.Text = plus5.ToString("MMMM dd, yyyy");
            //initView(listView6, appointments[5]);
            //label7.Text = plus6.ToString("MMMM dd, yyyy");
            //initView(listView7, appointments[6]);
            label1.Text = "Today";
            label2.Text = "Tomorrow";
            label3.Text = plus2.ToString("MMMM dd, yyyy");
            label4.Text = plus3.ToString("MMMM dd, yyyy");
            label5.Text = plus4.ToString("MMMM dd, yyyy");
            label6.Text = plus5.ToString("MMMM dd, yyyy");
            label7.Text = plus6.ToString("MMMM dd, yyyy");
            initView(listView1);
            initView(listView2);
            initView(listView3);
            initView(listView4);
            initView(listView5);
            initView(listView6);
            initView(listView7);
            try
            {
                if (appointments[0] == null)
                {
                    listView1.Columns.Clear();
                    listView1.Columns.Add("No appointments today");
                    listView1.Columns[0].Width = -2;
                }
                else
                {
                    foreach (string[] appointment in appointments[0])
                    {
                        try
                        {

                            appointment[7] = Utilities.ConvertToLocalTime(appointment[7]).ToString();
                            appointment[8] = Utilities.ConvertToLocalTime(appointment[8]).ToString();
                            listView1.Items.Add(new ListViewItem(appointment));
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }
            catch
            {
                listView1.Columns.Clear();
                listView1.Columns.Add("No appointments today");
                listView1.Columns[0].Width = -2;
            }

            try
            {
                if (appointments[1] == null)
                {
                    listView2.Columns.Clear();
                    listView2.Columns.Add("No appointments today");
                    listView2.Columns[1].Width = -2;
                }
                else
                {
                    foreach (string[] appointment in appointments[1])
                    {
                        try
                        {

                            appointment[7] = Utilities.ConvertToLocalTime(appointment[7]).ToString();
                            appointment[8] = Utilities.ConvertToLocalTime(appointment[8]).ToString();
                            listView2.Items.Add(new ListViewItem(appointment));
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }
            catch
            {
                listView2.Columns.Clear();
                listView2.Columns.Add("No appointments today");
                listView2.Columns[1].Width = -2;
            }

            try
            {
                if (appointments[2] == null)
                {
                    listView3.Columns.Clear();
                    listView3.Columns.Add("No appointments today");
                    listView3.Columns[0].Width = -2;
                }
                else
                {
                    foreach (string[] appointment in appointments[2])
                    {
                        try
                        {

                            appointment[7] = Utilities.ConvertToLocalTime(appointment[7]).ToString();
                            appointment[8] = Utilities.ConvertToLocalTime(appointment[8]).ToString();
                            listView3.Items.Add(new ListViewItem(appointment));
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }
            catch
            {
                listView3.Columns.Clear();
                listView3.Columns.Add("No appointments today");
                listView3.Columns[0].Width = -2;
            }

            try
            {
                if (appointments[3] == null)
                {
                    listView4.Columns.Clear();
                    listView4.Columns.Add("No appointments today");
                    listView4.Columns[0].Width = -2;
                }
                else
                {
                    foreach (string[] appointment in appointments[3])
                    {
                        try
                        {

                            appointment[7] = Utilities.ConvertToLocalTime(appointment[7]).ToString();
                            appointment[8] = Utilities.ConvertToLocalTime(appointment[8]).ToString();
                            listView4.Items.Add(new ListViewItem(appointment));
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }
            catch
            {
                listView4.Columns.Clear();
                listView4.Columns.Add("No appointments today");
                listView4.Columns[0].Width = -2;
            }

            try
            {
                if (appointments[4] == null)
                {
                    listView5.Columns.Clear();
                    listView5.Columns.Add("No appointments today");
                    listView5.Columns[0].Width = -2;
                }
                else
                {
                    foreach (string[] appointment in appointments[4])
                    {
                        try
                        {

                            appointment[7] = Utilities.ConvertToLocalTime(appointment[7]).ToString();
                            appointment[8] = Utilities.ConvertToLocalTime(appointment[8]).ToString();
                            listView5.Items.Add(new ListViewItem(appointment));
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }
            catch
            {
                listView5.Columns.Clear();
                listView5.Columns.Add("No appointments today");
                listView5.Columns[0].Width = -2;
            }

            try
            {
                if (appointments[5] == null)
                {
                    listView6.Columns.Clear();
                    listView6.Columns.Add("No appointments today");
                    listView6.Columns[0].Width = -2;
                }
                else
                {
                    foreach (string[] appointment in appointments[5])
                    {
                        try
                        {

                            appointment[7] = Utilities.ConvertToLocalTime(appointment[7]).ToString();
                            appointment[8] = Utilities.ConvertToLocalTime(appointment[8]).ToString();
                            listView6.Items.Add(new ListViewItem(appointment));
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }
            catch
            {
                listView6.Columns.Clear();
                listView6.Columns.Add("No appointments today");
                listView6.Columns[0].Width = -2;
            }

            try
            {
                if (appointments[6] == null)
                {
                    listView7.Columns.Clear();
                    listView7.Columns.Add("No appointments today");
                    listView7.Columns[0].Width = -2;
                }
                else
                {
                    foreach (string[] appointment in appointments[6])
                    {
                        try
                        {

                            appointment[7] = Utilities.ConvertToLocalTime(appointment[7]).ToString();
                            appointment[8] = Utilities.ConvertToLocalTime(appointment[8]).ToString();
                            listView7.Items.Add(new ListViewItem(appointment));
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }
            catch
            {
                listView7.Columns.Clear();
                listView7.Columns.Add("No appointments today");
                listView7.Columns[0].Width = -2;
            }
        }

        internal void initView(ListView lv)
        {
            //try
            //{
                lv.GridLines = true;
                lv.Columns.Add("Customer Name");
                lv.Columns.Add("Title");
                lv.Columns.Add("Description");
                lv.Columns.Add("Location");
                lv.Columns.Add("Contact");
                lv.Columns.Add("Type");
                lv.Columns.Add("URL");
                lv.Columns.Add("Start");
                lv.Columns.Add("End");
                lv.Columns[0].Width = -2;
                lv.Columns[1].Width = -2;
                lv.Columns[4].Width = -2;
                lv.Columns[5].Width = -2;
                lv.Columns[6].Width = -2;
                lv.Columns[7].Width = -2;
                lv.Columns[8].Width = -2;
                //if (appointments == null)
                //{
                //    lv.Columns.Add("No appointments on this day");

                //}
                //else
                //{
                //    foreach (string[] appointment in appointments)
                //    {
                //        try
                //        {
                            
                //            appointment[7] = Utilities.ConvertToLocalTime(appointment[7]).ToString();
                //            appointment[8] = Utilities.ConvertToLocalTime(appointment[8]).ToString();
                //            listView1.Items.Add(new ListViewItem(appointment));
                //        }
                //        catch
                //        {
                //            break;
                //        }

                //    }
                //}
            //}
            //catch 
            //{ 
                //lv.Columns.Clear();
                //lv.Columns.Add("No appointments today");
                //lv.Columns[0].Width = -2;
            //}

        }

    }
}
