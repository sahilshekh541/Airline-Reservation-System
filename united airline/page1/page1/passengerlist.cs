using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace page1
{
    public partial class passengerlist : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";

        private DateTime deptdate;
        private string selectedFlightCode;

        public passengerlist()
        {
            InitializeComponent();
        }

        private void passengerlist_Load(object sender, EventArgs e)
        {

            
      
            comboBox2.SelectedIndex = 0;
            comboBox2.Focus();
            
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT deptdate FROM flight_info";
                    SqlCommand command = new SqlCommand(query, connection);
                    //command.Parameters.AddWithValue("@flightcode", selectedFlightCode);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            deptdate = reader.GetDateTime(0);
                            comboBox2.Items.Add(deptdate);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            
        }
        


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedDateStr = comboBox2.SelectedItem.ToString();
                if (DateTime.TryParse(selectedDateStr, out DateTime selectedDate))
                {
                    PopulateComboBox1(selectedDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }

        private void PopulateComboBox1(DateTime selectedDate)
        {
            string query = "SELECT flightcode FROM flight_info WHERE deptdate = @deptdate;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@deptdate", selectedDate);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    string flightCode = reader.GetString(0);
                    comboBox1.Items.Add(flightCode);
                }

                reader.Close();
            }
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
     
        private void passengerinfoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        protected void fetchdata()
        {
            try
            {


                if (comboBox1.SelectedText != null)
                {
                    
                    try
                    {
                        SqlConnection connection = new SqlConnection(connectionString);
                        string query = "SELECT * FROM passenger_info WHERE CONVERT(DATE, deptdatetime) = @deptdate AND flightno = '" + comboBox1.SelectedItem + "'";

                        SqlCommand command = new SqlCommand(query, connection);

                        if (comboBox2.SelectedItem is DateTime selectedDate)
                        {
                            command.Parameters.AddWithValue("@deptdate", selectedDate);
                        }
                        else
                        {
                            // Handle the case where selectedDate is not a valid DateTime
                            return;
                        }

                        /* if (int.TryParse(selectedFlightCode, out int flightNo))
                         {
                             command.Parameters.AddWithValue("@flightno", flightNo);
                         }
                         else
                         {
                             // Handle the case where selectedFlightCode is not a valid integer
                             return;
                         }
                         */
                        DataTable dataTable = new DataTable();
                        connection.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    this.Refresh();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                selectedFlightCode = comboBox1.SelectedItem.ToString();

            }
            fetchdata();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchtext = textBox1.Text.Trim();
                if (!string.IsNullOrEmpty(searchtext))
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    string query = "SELECT * FROM passenger_info WHERE CONVERT(DATE, deptdatetime) = @deptdate AND flightno = '" + comboBox1.SelectedItem + "' AND passengername like @searchtext";

                    SqlCommand command = new SqlCommand(query, connection);
                    if (comboBox2.SelectedItem is DateTime selectedDate)
                    {
                        command.Parameters.AddWithValue("@deptdate", selectedDate);
                    }
                    command.Parameters.AddWithValue("@searchText", "%" + searchtext + "%");
                    DataTable dataTable = new DataTable();
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    fetchdata();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            page5 p5 = new page5();
            this.Hide();
            p5.Show();
        }
    }
}

