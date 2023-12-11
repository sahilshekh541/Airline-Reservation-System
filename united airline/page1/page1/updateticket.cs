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
    public partial class updateticket : Form
    {
        public updateticket()
        {
            InitializeComponent();
        }

        public void checkMain()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
            string userInput = ticketnotxt.Text;
            bool matchFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string getFlightCodeQuery = "SELECT deptdatetime FROM passenger_info WHERE ticketno = @UserInput";
                using (SqlCommand getFlightCodeCommand = new SqlCommand(getFlightCodeQuery, connection))
                {
                    getFlightCodeCommand.Parameters.AddWithValue("@UserInput", userInput);

                    using (SqlDataReader reader = getFlightCodeCommand.ExecuteReader())
                    {
                        try
                        {
                            
                                if (reader.Read())
                                {
                                    DateTime departureDate = Convert.ToDateTime(reader["deptdatetime"]);
                                    DateTime currentDate = DateTime.Today;
                                    DateTime departuredate = departureDate.Date;
                                    if (departuredate >= currentDate)
                                    {
                                        matchFound = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("THE FLIGHT IS ALREADY DEPARTED. UPDATE OF THE TICKET NOT POSSIBLE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            else
                            {
                                MessageBox.Show("INVALID TICKET NO", "TICKET NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }



                        }
                        catch (Exception ex)
                        {
                           MessageBox.Show( ex.Message);
                        }
                        
                    }
                }
            }

            if (matchFound)
            {
                updateticketresult u1 = new updateticketresult(userInput);
                this.Hide();
                u1.Show();
            }
        }


        private void submitbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ticketnotxt.Text))
            {

                MessageBox.Show("ENTER YOUR TICKET NO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ticketnotxt.Focus();

            }
            else
            {

                checkMain();
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
