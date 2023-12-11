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
    public partial class Booktickets : Form
    {
        public Booktickets()
        {
            InitializeComponent();
        }

        private void Booktickets_Load(object sender, EventArgs e)
        {
            fromselection.SelectedIndex = 0;
            toselection.SelectedIndex = 0;
            departdate.SelectedIndex = 0;
           

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
            
            SqlConnection connection = new SqlConnection(connectionString);

            
            


            
            
            try
            {
                String query = "SELECT deptat,arvat,deptdate from flight_info ";
                SqlCommand command = new SqlCommand(query,connection);
                connection.Open();
                SqlDataReader reader =command.ExecuteReader();

                while (reader.Read())
                {
                    fromselection.Items.Add(reader["deptat"].ToString());
                    toselection.Items.Add(reader["arvat"].ToString());

                    DateTime deptDate = Convert.ToDateTime(reader["deptdate"]);
                    // Format the date and add to the combobox
                    string formattedDate = deptDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    departdate.Items.Add(formattedDate);

                }
                reader.Close();
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                fromselection.SelectedIndex = 0;
                toselection.SelectedIndex = 0;
                departdate.SelectedIndex = 0;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fromselection.SelectedIndex = 0;
            toselection.SelectedIndex = 0;

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            page5 p5 = new page5();
            this.Hide();
            p5.Show();

        }

        public void Submitbtn_Click(object sender, EventArgs e)
        {
            if(fromselection.SelectedIndex <= 0 )
            {
                MessageBox.Show("Select From selection", "NOT SELECT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (toselection.SelectedIndex <= 0)
                {
                    MessageBox.Show("Select To selection", "NOT SELECT", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (departdate.SelectedIndex <= 0)
                    {
                        MessageBox.Show("Select departdate selection", "NOT SELECT", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else {
                        string selectedDateString = departdate.SelectedItem.ToString();
                        DateTime selectedDepartDate = DateTime.ParseExact(selectedDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        bookticketresult b1 = new bookticketresult(selectedDepartDate);
                        this.Hide();
                        b1.Show();

                    }
                    
                  
                }
                

            }
        }

        public void classoftravel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void departdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
