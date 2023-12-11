using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace page1
{
    public partial class updateflightinfo : Form
    {

        private string deptat ;
        private string deptdate ;
        private string arvat ;
        private string arvdate ;
        private string price;
        private string dtime;
        private string atime;

        public updateflightinfo()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";

        private void updateflightinfo_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT flightcode,deptdate FROM flight_info";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            comboBox2.Items.Add(reader["deptdate"].ToString());
                            comboBox1.Items.Add(reader["flightcode"].ToString());
                            
                        }
                    }
                }
            }

            comboBox2.DisplayMember = "ToShortDateString";


        }

        private void back_Click(object sender, EventArgs e)
        {
            page4 p4 = new page4();
            this.Hide();
            p4.Show();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            string fc = comboBox1.SelectedItem.ToString();
            SqlConnection con = new SqlConnection(connectionString);
            string query1 = "SELECT deptat,deptdate,depttime,arvat,arvdate,arvtime,price FROM flight_info WHERE flightcode=@fc";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@fc", fc);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Assuming you want to retrieve only the first row (if any)
                if (reader.Read())
                {
                    // Retrieve the columns you need
                     deptat = reader["deptat"].ToString();
                     deptdate = reader["deptdate"].ToString();
                     dtime = reader["depttime"].ToString();
                     arvat = reader["arvat"].ToString();
                     arvdate = reader["arvdate"].ToString();
                    atime = reader["arvtime"].ToString();
                    price = reader["price"].ToString();
                }

                finalupdateflight f1 = new finalupdateflight(fc,deptat,deptdate,dtime,arvat,arvdate,atime,price);
                this.Hide();
                f1.Show();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }

           
        }
    }
}
