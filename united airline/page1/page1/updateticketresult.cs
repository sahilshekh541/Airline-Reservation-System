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
    public partial class updateticketresult : Form
    {
        private string ticketno;
        private string flightno;
        private DateTime ddatetime;
        
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
        public updateticketresult(string userinput)
        {
            ticketno = userinput;
            InitializeComponent();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            page5 p5 = new page5();
            this.Hide();
            p5.Show();
        }

        private void PopulateComboBoxes()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Fetch departure data
                string departureQuery = "SELECT  deptat FROM flight_info";
                using (SqlCommand departureCommand = new SqlCommand(departureQuery, connection))
                using (SqlDataReader departureReader = departureCommand.ExecuteReader())
                {
                    while (departureReader.Read())
                    {
                        string departure = departureReader["deptat"].ToString();
                        comboBox1.Items.Add(departure);
                    }
                }

                // Fetch arrival data
                string arrivalQuery = "SELECT arvat FROM flight_info";
                using (SqlCommand arrivalCommand = new SqlCommand(arrivalQuery, connection))
                using (SqlDataReader arrivalReader = arrivalCommand.ExecuteReader())
                {
                    while (arrivalReader.Read())
                    {
                        string arrival = arrivalReader["arvat"].ToString();
                        comboBox2.Items.Add(arrival);
                    }
                }

                // Fetch departure dates
                string departureDateQuery = "SELECT  deptdate FROM flight_info";
                using (SqlCommand departureDateCommand = new SqlCommand(departureDateQuery, connection))
                using (SqlDataReader departureDateReader = departureDateCommand.ExecuteReader())
                {
                    while (departureDateReader.Read())
                    {
                        DateTime departureDate = (DateTime)departureDateReader["deptdate"];
                        comboBox3.Items.Add(departureDate.ToShortDateString());
                    }
                }
            }
        }


        private void updateticketresult_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select * from passenger_info where ticketno='" + ticketno + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string passengername = reader["passengername"].ToString();
                    string passengeradd = reader["passengeraddress"].ToString();
                    string passengerage = reader["passengerage"].ToString();


                    pasgname.Text = passengername;
                    pasgage.Text = passengerage;
                    pasgaddress.Text = passengeradd;

                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            PopulateComboBoxes();
        }





        private void submitbtn_Click(object sender, EventArgs e)
        {

            string selectedDeptAt = comboBox1.SelectedItem?.ToString();
            string selectedArvAt = comboBox2.SelectedItem?.ToString();
            string selectedDeptDate = comboBox3.SelectedItem?.ToString();
            string selectclsoftrv = comboBox4.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedDeptAt) || string.IsNullOrEmpty(selectedArvAt) || string.IsNullOrEmpty(selectedDeptDate))
            {
                MessageBox.Show("Please select values for Departure, Arrival, and Departure Date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fetchDeptDateTimeQuery = "SELECT deptdatetime,arvdaterime FROM passenger_info WHERE deptat = @DeptAt AND arvat = @ArvAt";
            DateTime fetchedDeptDateTime;
            DateTime fetcharvdatetime;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand fetchDeptDateTimeCommand = new SqlCommand(fetchDeptDateTimeQuery, connection))
                {
                    fetchDeptDateTimeCommand.Parameters.AddWithValue("@DeptAt", selectedDeptAt);
                    fetchDeptDateTimeCommand.Parameters.AddWithValue("@ArvAt", selectedArvAt);


                    using (SqlDataReader reader = fetchDeptDateTimeCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fetchedDeptDateTime = (DateTime)reader["deptdatetime"];
                            fetcharvdatetime = (DateTime)reader["arvdaterime"];
                        }
                        else
                        {
                            MessageBox.Show("No matching flight found for the selected Departure and Arrival.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    
                }




                // Show confirmation message box
                DialogResult result = MessageBox.Show("Are you sure you want to cancel the ticket? A cancellation fee of $2500 will be deducted.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string updateQuery = "UPDATE passenger_info " +
                                         "SET deptat = @DeptAt, arvat = @ArvAt, deptdatetime = @DeptDate, flightno = @FlightNo, arvdaterime = @ArvDateTim ,classoftravel=@clsoftrv " +
                                         "WHERE ticketno = @TicketNo";

                    // Fetch cancellation fees
                    decimal cancellationFees = 2500.00M;

                    // Here, you can fetch the corresponding flightno and arvdatetim based on selected deptat and arvat
                    string fetchFlightInfoQuery = "SELECT flightcode, arvdate,deptdate " +
                                                   "FROM flight_info " +
                                                   "WHERE deptat = @DeptAt AND arvat = @ArvAt";


                    connection.Close();
                    using (SqlCommand fetchFlightInfoCommand = new SqlCommand(fetchFlightInfoQuery, connection))
                    {
                        fetchFlightInfoCommand.Parameters.AddWithValue("@DeptAt", selectedDeptAt);
                        fetchFlightInfoCommand.Parameters.AddWithValue("@ArvAt", selectedArvAt);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = fetchFlightInfoCommand.ExecuteReader();
                            if (reader.Read())
                            {
                                flightno = reader["flightcode"].ToString();
                                DateTime arvDateTime = Convert.ToDateTime(reader["arvdate"]);
                                ddatetime = Convert.ToDateTime(reader["deptdate"]);

                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@DeptAt", selectedDeptAt);
                                    updateCommand.Parameters.AddWithValue("@ArvAt", selectedArvAt);

                                    updateCommand.Parameters.AddWithValue("@DeptDate", fetchedDeptDateTime);
                                    updateCommand.Parameters.AddWithValue("@FlightNo", flightno);
                                    updateCommand.Parameters.AddWithValue("@ArvDateTim", fetcharvdatetime);
                                    updateCommand.Parameters.AddWithValue("@clsoftrv", selectclsoftrv);
                                    updateCommand.Parameters.AddWithValue("@TicketNo", ticketno);
                                    reader.Close();
                                    
                                    int rowsAffected = updateCommand.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Passenger information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        // Fetch additional information from passenger_info and seat_info
                                        string fetchAdditionalInfoQuery = "SELECT p.passengername, p.passengerage, p.passengeraddress, p.adult, p.child, p.infant, p.classoftravel,p.passengers,p.deptat,p.arvat, s.seatno, s.bookdate " +
                                                                         "FROM passenger_info p " +
                                                                         "JOIN seatinfo s ON p.ticketno = s.ticketno " +
                                                                         "WHERE p.ticketno = @TicketNo";

                                        using (SqlCommand fetchAdditionalInfoCommand = new SqlCommand(fetchAdditionalInfoQuery, connection))
                                        {
                                            fetchAdditionalInfoCommand.Parameters.AddWithValue("@TicketNo", ticketno);
                                            SqlDataReader additionalInfoReader = fetchAdditionalInfoCommand.ExecuteReader();

                                            if (additionalInfoReader.Read())
                                            {
                                                string passengerName = additionalInfoReader["passengername"].ToString();
                                                int passengerAge = Convert.ToInt32(additionalInfoReader["passengerage"]);
                                                string passengerAddress = additionalInfoReader["passengeraddress"].ToString();
                                                int adultCount = Convert.ToInt32(additionalInfoReader["adult"]);
                                                int childCount = Convert.ToInt32(additionalInfoReader["child"]);
                                                int infantCount = Convert.ToInt32(additionalInfoReader["infant"]);
                                                string travelClass = additionalInfoReader["classoftravel"].ToString();
                                                int totseats = Convert.ToInt32(additionalInfoReader["passengers"]);
                                                string dptat = additionalInfoReader["deptat"].ToString();
                                                string arat = additionalInfoReader["arvat"].ToString();
                                                string seatNo = additionalInfoReader["seatno"].ToString();
                                                DateTime bookDate = Convert.ToDateTime(additionalInfoReader["bookdate"]);
                                        

                                                additionalInfoReader.Close();

                                                // Insert data into cancelticket_info table
                                                string insertCancelTicketQuery = "INSERT INTO cancelticket_info (ticketno,pasgname, pasgadd ,pasgage, adult, child, infant, canceldate,travelclass, cancellationfee,totalseats,bookdate, deptat, arvat,seatno,deptdate,flightno) " +
                                                                                "VALUES (@ticketno,@PassengerName,@PassengerAddress , @PassengerAge, @Adult, @Child, @Infant,@canceldate,@TravelClass, @CancellationFees, @totalseats, @BookDate, @DeptAt, @ArvAt, @SeatNo,@deptdate,@flightno)";

                                                using (SqlCommand insertCancelTicketCommand = new SqlCommand(insertCancelTicketQuery, connection))
                                                {
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@ticketno", ticketno);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@PassengerName", passengerName);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@PassengerAddress", passengerAddress);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@PassengerAge", passengerAge); insertCancelTicketCommand.Parameters.AddWithValue("@Adult", adultCount);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@Child", childCount);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@Infant", infantCount);
                                                    DateTime canceldate = DateTime.Now;
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@canceldate", canceldate);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@TravelClass", travelClass);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@CancellationFees", cancellationFees);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@totalseats", totseats);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@BookDate", bookDate);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@DeptAt", dptat);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@ArvAt", arat);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@SeatNo", seatNo);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@deptdate", ddatetime);
                                                    insertCancelTicketCommand.Parameters.AddWithValue("@flightno", flightno);

                                                    int cancelTicketRowsAffected = insertCancelTicketCommand.ExecuteNonQuery();
                                                    if (cancelTicketRowsAffected > 0)
                                                    {
                                                        this.Hide();
                                                        updateticketpaymentpage p1 = new updateticketpaymentpage(ticketno, selectclsoftrv);
                                                        p1.Show();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Failed to store passenger cancellation information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Additional information for the ticket not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No rows updated. Make sure the ticket number is valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("No matching flight found for the selected Departure and Arrival.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            reader.Close();
                          
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while updating the passenger information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                
            }
            

        }

    }
}
