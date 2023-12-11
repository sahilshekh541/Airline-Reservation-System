using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace page1
{
    public partial class finalupdateflight : Form
    {
        private string fc;
        private string deptat;
        private string deptdate;
        private string arvat;
        private string arvdate;
        private string price;
        private string dtime;
        private string atime;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
        public finalupdateflight(string fc,string deptat,string deptdate,string dtime,string arvat,string arvdate,string atime,string price)
        {
            InitializeComponent();
            this.fc = fc;
            this.deptat = deptat;
            this.deptdate = deptdate;
            this.dtime = dtime;
            this.arvat = arvat;
            this.arvdate = arvdate;
            this.atime = atime;
            this.price = price;

            DateTime dt;
            if (DateTime.TryParse(deptdate, out dt))
            {
                dateTimePicker1.Value = dt;
            }

            // Enable the DateTimePicker control to allow user changes
            dateTimePicker1.Enabled = true;

            DateTime at;
            if (DateTime.TryParse(arvat, out at))
            {
                dateTimePicker2.Value = at;// Setting only the time part
            }
           

        }

        private void finalupdateflight_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MMMM yyyy";
            depttime.ShowUpDown = true;
            depttime.CustomFormat = "hh:mm:ss tt";
            depttime.Format= System.Windows.Forms.DateTimePickerFormat.Custom;


            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd MMMM yyyy";
            arvtime.ShowUpDown = true;
            arvtime.CustomFormat="hh:mm:ss tt";
            arvtime.Format=System.Windows.Forms.DateTimePickerFormat.Custom;

            departurelocation.Text = deptat;
            arrivallocation.Text = arvat;
            
        }

        private void back_Click(object sender, EventArgs e)
        {
            page4 p4 = new page4();
            this.Hide();
            p4.Show();
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {

            DateTime newDeptDate = dateTimePicker1.Value;
            DateTime newArvDate = dateTimePicker2.Value;
            TimeSpan newDeptTime = depttime.Value.TimeOfDay;
            TimeSpan newArvTime = arvtime.Value.TimeOfDay;
            string newPrice = ptext.Text;
            
            string updateQuery = "UPDATE flight_info SET  deptdate=@deptdate, depttime=@depttime, arvdate=@arvdate, arvtime=@arvtime, price=@price WHERE flightcode=@fc";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@deptdate", newDeptDate);
                cmd.Parameters.AddWithValue("@depttime", newDeptTime);
                cmd.Parameters.AddWithValue("@arvdate", newArvDate);
                cmd.Parameters.AddWithValue("@arvtime", newArvTime);
                cmd.Parameters.AddWithValue("@price", newPrice);
                cmd.Parameters.AddWithValue("@fc", fc);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Flight information updated successfully!");
                        ptext.Clear();
                        submitbtn.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Flight not found or no changes were made!");
                        submitbtn.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message);
                }
            }
        }
    }
}
