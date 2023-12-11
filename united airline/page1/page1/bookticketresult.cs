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
    public partial class bookticketresult : Form 
    {

        private int selectedrowindex = -1;
        private int selectedcellindex = -1;
        
        private DateTime selectedDepartDate;

        public bookticketresult(DateTime departDate)
        {
            InitializeComponent();
            this.selectedDepartDate = departDate;
        }


        private void bookticketresult_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT flightcode, deptat, deptdate, depttime, arvat, arvdate, arvtime, price FROM flight_info WHERE deptdate = @deptdate";

            DataTable dataTable = new DataTable();
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@deptdate", selectedDepartDate); // Use the selected departure date
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();

            dataGridView1.DataSource = dataTable;
        }


        private void backbtn_Click(object sender, EventArgs e)
        {
            Booktickets bck = new Booktickets();
            this.Hide();
            bck.Show();
        }

        private void bookbtn_Click(object sender, EventArgs e)
        {
            if (selectedrowindex >= 0 && selectedrowindex < dataGridView1.Rows.Count)
            {
                string flightcode = dataGridView1.Rows[selectedrowindex].Cells["flightcode"].Value.ToString();
                string deptat = dataGridView1.Rows[selectedrowindex].Cells["deptat"].Value.ToString();
                DateTime deptDate = Convert.ToDateTime(dataGridView1.Rows[selectedrowindex].Cells["deptdate"].Value);
                TimeSpan deptTime = TimeSpan.Parse(dataGridView1.Rows[selectedrowindex].Cells["depttime"].Value.ToString());
                DateTime deptDateTime = deptDate.Date + deptTime;
                string arvat = dataGridView1.Rows[selectedrowindex].Cells["arvat"].Value.ToString();
                DateTime arvDate = Convert.ToDateTime(dataGridView1.Rows[selectedrowindex].Cells["arvdate"].Value);
                TimeSpan arvTime = TimeSpan.Parse(dataGridView1.Rows[selectedrowindex].Cells["arvtime"].Value.ToString());
                DateTime arvDateTime = arvDate.Date + arvTime;


                DateTime comptodaydate = DateTime.Today;
                if(deptDateTime < comptodaydate)
                {
                    MessageBox.Show("This flight is already Depart \n this flight is not booked", "NOT AVAILABLE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                  
                    passengerinformation p1 = new passengerinformation(flightcode, deptat, deptDateTime, arvat, arvDateTime);
                    this.Hide();
                    p1.Show();

                }



            }
        }
       
        
        public void dataGridView1_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                selectedrowindex = e.RowIndex;
            }
            else
            {
                // Clicked on an invalid cell, reset the selected row index.
                selectedrowindex = -1;
            }
        }
    }
}
