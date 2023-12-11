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
    public partial class printicketopt : Form
    {
        public printicketopt()
        {
            InitializeComponent();
        }

        public void checkMain()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True"; ; ;
            string userInput = ticketnotxt.Text; 
            bool matchFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM seatinfo WHERE ticketno = @UserInput";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserInput", userInput);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        matchFound = true;
                    }
                }
            }

            if (matchFound)
            {
                printoptticketresult p1 = new printoptticketresult(userInput);
                this.Hide();
                p1.Show();
            }
            else
            {
                MessageBox.Show("THIS TICKET NO IS NOT FOUND", "ENTER VALID TICKET NO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void backbtn_Click(object sender, EventArgs e)
        {
            page5 p5 = new page5();
            this.Hide();
            p5.Show();
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ticketnotxt.Text))
            {
               
                MessageBox.Show("ENTER YOUR TICKET NO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ticketnotxt.Focus();

            }
            else
            {
                checkMain();
            }
        }
    }
}
