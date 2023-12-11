using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace page1
{
    public partial class addfights : Form
    {
        

        public addfights()
        {
            InitializeComponent();
        }

        private void addfights_Load(object sender, EventArgs e)
        {
            
            price_text.BringToFront();
            Departuretime.ShowUpDown = true;
            Departuretime.CustomFormat = "hh:mm:ss tt";
            Departuretime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            Arrivaltime.ShowUpDown = true;
            Arrivaltime.CustomFormat = "hh:mm:ss tt";
            Arrivaltime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void reset_Click(object sender, EventArgs e)
        {
            price_text.Clear();
            Departuredate.Value = DateTime.Now;
            Departuretime.Value = DateTime.Now;
            Arrivaldate.Value = DateTime.Now;
            Arrivaltime.Value = DateTime.Now;
            Departure.SelectedIndex = 0;
            Arrival.SelectedIndex = 0;
            flightcode.SelectedIndex = 0;


        }

        private void back_Click(object sender, EventArgs e)
        {
            page4 p4 = new page4();
            this.Hide();
            p4.Show();
        }



        


        private void submit_Click(object sender, EventArgs e)
        {

            DateTime fromdate = DateTime.Parse(Convert.ToDateTime(Departuredate.Text).ToShortDateString());
            DateTime todate = DateTime.Parse(Convert.ToDateTime(Arrivaldate.Text).ToShortDateString());



            //check all field are filled or not

          if(string.IsNullOrEmpty(price_text.Text))
            {


                MessageBox.Show("Add Flight Info ", "NOT SELECT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            else
            {
                if (flightcode.SelectedIndex == 0)
                {
                    MessageBox.Show("SELECT FLIGHT NUMBER ", "NOT SELECT", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    flightinfo();
                }
               
            }
          

        }




        //database connection and flight information datastore in flight_info table
        void flightinfo()
                {
                    databaseconnections dbs = new databaseconnections();

                    String query = "INSERT into flight_info (flightcode,deptat,deptdate,depttime,arvat,arvdate,arvtime,price) values ('" + this.flightcode.Text + "','" + this.Departure.Text + "','" + this.Departuredate.Text + "','" + this.Departuretime.Text + "', '" + this.Arrival.Text + "' , '" + this.Arrivaldate.Text + "','" + this.Arrivaltime.Text + "','" + this.price_text.Text + "')";

                    try
                    {
                        dbs.setdata(query);
                        MessageBox.Show("FLIGHT SUCCESSFULLY ADD", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR TO CONNECT DATABASE",ex.Message);
                    }

                }


            
        
    }
}
