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
using System.Globalization;

namespace page1
{
    public partial class viewpayments : Form
    {
        
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
        public viewpayments()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ticketnotxt.Focus();
          
            comboBox1.Enabled = false;
            ticketnotxt.Enabled = true;
            button1.Visible = false;
            button2.Visible = true;


        }

        
        


        private void viewpayments_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            
            comboBox1.Focus();
            button2.Visible = false;
            ticketnotxt.Visible = true;
            ticketnotxt.Enabled = false;

            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT deptdate from payment_info";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string deptdate = reader.GetString(0);
                    comboBox1.Items.Add(deptdate);
                }
                reader.Close();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void datevisefetchdata()
        {
           
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM payment_info WHERE deptdate=@deptdate";
                    SqlCommand command = new SqlCommand(query, con);
                    if (comboBox1.SelectedItem is string selectedDate)
                    {
                        command.Parameters.AddWithValue("@deptdate", selectedDate);
                    }
                    try
                    {
                        DataTable dataTable = new DataTable();
                        con.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Focus();
            comboBox1.Enabled = true;
            
            ticketnotxt.Enabled = false;
            button1.Visible = true;
            button2.Visible = false;
        }

        private void fetchdatawithticketno()
        {
            try
            {
                string searchtext = ticketnotxt.Text.Trim();
                if (!string.IsNullOrEmpty(searchtext))
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    string query = "SELECT * FROM payment_info WHERE ticketno like @searchtext";

                    SqlCommand command = new SqlCommand(query, connection);
                   
                    command.Parameters.AddWithValue("@searchText", "%" + searchtext + "%");
                    DataTable dataTable = new DataTable();
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("THIS TICKET NO IS NOT FOUND DOUBLE CHECK TICKET NO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void ticketnotxt_TextChanged(object sender, EventArgs e)
        {
            if(ticketnotxt.Text.Length > 1)
            {
                fetchdatawithticketno();
            }
            else
            {
                datevisefetchdata();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            page5 p5 = new page5();
            this.Hide();
            p5.Show();
        }

       

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.SelectedIndex >= 1)
                {
                    datevisefetchdata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
