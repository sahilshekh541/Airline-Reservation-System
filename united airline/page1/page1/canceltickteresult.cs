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
    public partial class canceltickteresult : Form
    {
        private string ticketno;
        private int flightno;
        private string pasgadd;
        private string pasgage;
        private int adult;
        private int child;
        private int infant;
        private int cancellationfee = 2500;
        private int totalseats;
        string deptdate;

        public canceltickteresult(string userInput)
        {
            this.ticketno = userInput;
            InitializeComponent();
        }

        private void canceltickteresult_Load(object sender, EventArgs e)
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
                        pasgadd = reader1["passengeraddress"].ToString();
                        pasgage = reader1["passengerage"].ToString();
                        adult = Convert.ToInt32(reader1["adult"].ToString());
                        child = Convert.ToInt32(reader1["child"].ToString());
                        infant = Convert.ToInt32(reader1["infant"].ToString());
                        string departureAt = reader1["deptat"].ToString();
                        DateTime deptDate = Convert.ToDateTime(reader1["deptdatetime"]);
                        string formattedDepartureDateTime = deptDate.ToString("yyyy-MM-dd HH:mm:ss");
                        deptdate = deptDate.ToString("yyyy-MM-dd");
                        string arrivalAt = reader1["arvat"].ToString();
                        DateTime arrivalDate = Convert.ToDateTime(reader1["arvdaterime"]);
                        string formattedArrivalDateTime = arrivalDate.ToString("yyyy-MM-dd HH:mm:ss");
                        

                        totalseats = adult + child + infant
;                        fromlbl.Text = departureAt;
                        tolbl.Text = arrivalAt;
                        departuredatelbl.Text = formattedDepartureDateTime;
                        arrivaldatelbl.Text = formattedArrivalDateTime;

                        reader1.Close();
                    }

                }


            }
            catch (Exception ex)
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

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True"; ;
            SqlConnection con = new SqlConnection(connection);
            DateTime canceldate = DateTime.Now;
            string query = "INSERT into cancelticket_info(ticketno,pasgname,pasgadd,pasgage,adult,child,infant,canceldate,travelclass,cancellationfee,totalseats,bookdate,deptat,arvat,seatno,deptdate,flightno)VALUES('"+ticketno+"','"+gusetnamelbl.Text+"','"+pasgadd+"','"+pasgage+"','"+adult+"','"+child+"','"+infant+"','"+canceldate+"','"+seatclasslbl.Text+"','"+cancellationfee+"','"+totalseats+"','"+bookingdatelbl.Text+"','"+fromlbl.Text+"','"+tolbl.Text+"','"+seatnolbl.Text+"','"+deptdate+"','"+flightnolbl.Text+"')";
            string query1 = "DELETE  from passenger_info where ticketno='"+ticketno+"'";
            string query2 = "DELETE  from seatinfo where ticketno='" + ticketno + "' ";

            SqlCommand cmd = new SqlCommand(query,con);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("your ticket is cancel", "information", MessageBoxButtons.OK,MessageBoxIcon.Error);
                con.Close();
                page5 p5 = new page5();
                this.Hide();
                p5.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
