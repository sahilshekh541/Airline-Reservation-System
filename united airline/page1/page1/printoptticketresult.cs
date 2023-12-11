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
    public partial class printoptticketresult : Form
    {
        private string ticketno;
        private int flightno;

        public printoptticketresult(string userInput)
        {
            InitializeComponent();
            this.ticketno = userInput;
        }

        

        private void printoptticketresult_Load(object sender, EventArgs e)
        {

            string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True"; ;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select * from seatinfo WHERE ticketno='" + ticketno + "'";

            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    // Retrieve passenger information
                    string seatno = reader["seatno"].ToString();
                    string bookingdate = reader["bookdate"].ToString();
                    flightno = Convert.ToInt32(reader["flightno"]);
                    string guestname = reader["passengername"].ToString();
                    int tknumber = Convert.ToInt32(reader["ticketno"]);
                    string seatclass = reader["seatclass"].ToString();

                    ticketnolbl.Text = tknumber.ToString();
                    seatnolbl.Text = seatno;
                    bookingdatelbl.Text = bookingdate;
                    flightnolbl.Text = flightno.ToString();
                    gusetnamelbl.Text = guestname;
                    seatclasslbl.Text = seatclass;

                    reader.Close();


                    string query1 = "select * from passenger_info where ticketno='" + tknumber + "'";
                    SqlCommand command1 = new SqlCommand(query1, con);
                    SqlDataReader reader1 = command1.ExecuteReader();

                    if (reader1.Read())
                    {
                        string departureAt = reader1["deptat"].ToString();
                        DateTime deptDate = Convert.ToDateTime(reader1["deptdatetime"]);
                        string formattedDepartureDateTime = deptDate.ToString("yyyy-MM-dd HH:mm:ss");

                        string arrivalAt = reader1["arvat"].ToString();
                        DateTime arrivalDate = Convert.ToDateTime(reader1["arvdaterime"]);
                        string formattedArrivalDateTime = arrivalDate.ToString("yyyy-MM-dd HH:mm:ss");



                        fromlbl.Text = departureAt;
                        tolbl.Text = arrivalAt;
                        departuredatelbl.Text = formattedDepartureDateTime;
                        arrivaldatelbl.Text = formattedArrivalDateTime;


                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            reportview1 rp = new reportview1(gusetnamelbl.Text, ticketnolbl.Text, seatnolbl.Text, bookingdatelbl.Text, flightnolbl.Text, seatclasslbl.Text, fromlbl.Text, tolbl.Text, departuredatelbl.Text, arrivaldatelbl.Text);
            this.Hide();
            rp.Show();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            page5 p5 = new page5();
            this.Hide();
            p5.Show();
        }
    }
}
