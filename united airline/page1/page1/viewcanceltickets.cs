﻿using System;
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
    public partial class viewcanceltickets : Form
    {

        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
        private DateTime deptdate;


        public viewcanceltickets()
        {
            InitializeComponent();
        }

        private void viewcanceltickets_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox2.Focus();

            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT deptdate, flightno from cancelticket_info";


            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    deptdate = reader.GetDateTime(0);
                    comboBox2.Items.Add(deptdate);
                    string flightcode = reader["flightno"].ToString();
                    comboBox1.Items.Add(flightcode);
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fetchdata()
        {
            if (comboBox2.SelectedIndex >= 0 )
            {
                comboBox1.SelectedIndex = 0;
                try
                {

                    SqlConnection connection = new SqlConnection(connectionString);
                    string query = "SELECT * FROM cancelticket_info WHERE deptdate = @deptdate";
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
                fetcdatawithflightcode();
            }
        }

        private void fetcdatawithflightcode()
        {
            if (comboBox1.SelectedIndex < 1)
            {
                fetchdata();
            }
            else if (comboBox1.SelectedIndex >= 1)
            {
                try
                {

                    SqlConnection connection = new SqlConnection(connectionString);
                    string query = "SELECT * FROM cancelticket_info WHERE flightno = @flightcode";
                    SqlCommand command = new SqlCommand(query, connection);
                    if (comboBox1.SelectedItem is string selectedfightcode)
                    {
                        command.Parameters.AddWithValue("@flightcode", selectedfightcode);
                    }
                    else
                    {
                        // Handle the case where selectedDate is not a valid DateTime
                        return;
                    }


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
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0)
            {
                comboBox1.SelectedIndex = 0;
                fetchdata();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex >= 0)
            {
                comboBox2.SelectedIndex = 0;
                fetcdatawithflightcode();
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
