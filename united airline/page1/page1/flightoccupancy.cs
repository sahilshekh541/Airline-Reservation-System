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
    public partial class flightoccupancy : Form
    {
        public flightoccupancy()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            combobox1.SelectedIndex = 0;
            comboBox2.Text="";
            occupiedbusiness.Text = "00";
            occupiedeconomy.Text = "00";
            occupiedfirstclass.Text = "00";

        }

        private void back_Click(object sender, EventArgs e)
        {
            page4 p4 = new page4();
            this.Hide();
            p4.Show();
        }

       

        private void flightoccupancy_Load(object sender, EventArgs e)
        {

            combobox1.SelectedIndex = 0;
            

            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT flightcode From flight_info";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    combobox1.Items.Add(reader["flightcode"].ToString());
                 

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Event handler when the user selects a flight number
        private void combobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectedFlightCode = combobox1.SelectedItem.ToString();
            string query = "SELECT deptdate FROM flight_info WHERE flightcode = @fc";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fc", selectedFlightCode);

            comboBox2.Items.Clear();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime deptdate = Convert.ToDateTime(reader["deptdate"]);
                    comboBox2.Items.Add(deptdate.ToShortDateString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void checkbtn_Click(object sender, EventArgs e)
        {
            string fc = combobox1.SelectedItem.ToString();
            SqlConnection con = new SqlConnection(connectionString);
           
          
            string queryBusiness = "SELECT COUNT(*) AS passengers FROM passenger_info WHERE classoftravel = 'business' AND flightno = @flightcode";
            string queryEconomy = "SELECT COUNT(*) AS passengers FROM passenger_info WHERE classoftravel = 'economy' AND flightno = @flightcode";
            string queryFirst = "SELECT COUNT(*) AS passengers FROM passenger_info WHERE classoftravel = 'first class' AND flightno = @flightcode";

            SqlCommand cmdBusiness = new SqlCommand(queryBusiness, con);
            SqlCommand cmdEconomy = new SqlCommand(queryEconomy, con);
            SqlCommand cmdFirst = new SqlCommand(queryFirst, con);

            cmdBusiness.Parameters.AddWithValue("@flightcode", fc);
            cmdEconomy.Parameters.AddWithValue("@flightcode", fc);
            cmdFirst.Parameters.AddWithValue("@flightcode", fc);

            try
            {
                con.Open();
                int bookedSeatsBusiness = (int)cmdBusiness.ExecuteScalar();
                int bookedSeatsEconomy = (int)cmdEconomy.ExecuteScalar();
                int bookedSeatsFirst = (int)cmdFirst.ExecuteScalar();

                // Display booked seats for each class in respective labels
                occupiedbusiness.Text = bookedSeatsBusiness.ToString();
                occupiedeconomy.Text = bookedSeatsEconomy.ToString();
                occupiedfirstclass.Text = bookedSeatsFirst.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
