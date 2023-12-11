using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace page1
{
    public partial class updateticketpaymentpage : Form
    {
        private string ticketno;
        private int totalAmount;
        private string clsoftrv;
        DateTime deptDate;

        public updateticketpaymentpage(string ticketno,string selectclsoftrv)
        {
            this.ticketno = ticketno;
            this.clsoftrv = selectclsoftrv;
            InitializeComponent();
        }

        private void updateticketpaymentpage_Load(object sender, EventArgs e)
        {
            ticketnolbl.Text = ticketno.ToString();
            classoftravelbl.Text = clsoftrv.ToString();
            selectseatbtn.Enabled = false;
            selectseatbtn.Visible = false;
            cardrad.Checked = true;

            cardrad.CheckedChanged += RadioButton_CheckedChanged;
            intbankingrad.CheckedChanged += RadioButton_CheckedChanged;
            upirad.CheckedChanged += RadioButton_CheckedChanged;



            string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True"; ;
            SqlConnection con = new SqlConnection(connection);
            con.Open();

            // Execute the first query to retrieve passenger information
            string query = "select passengername, adult, child, infant, flightno from passenger_info WHERE ticketno='" + ticketno + "'";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    // Retrieve passenger information
                    string pasgname = reader["passengername"].ToString();
                    int adult = Convert.ToInt32(reader["adult"]);
                    int child = Convert.ToInt32(reader["child"]);
                    int infant = Convert.ToInt32(reader["infant"]);
                    int flightno = Convert.ToInt32(reader["flightno"]);


                    pasgnamelbl.Text = pasgname;
                    adultlbl.Text = adult.ToString();
                    childlbl.Text = child.ToString();
                    infantlbl.Text = infant.ToString();
                    flightnolbl.Text = flightno.ToString();

                    int total = adult + child + infant;
                    reader.Close(); // Close the first reader

                    // Execute the second query to retrieve flight information using flightno obtained from the first query
                    string query1 = "select deptat, deptdate, depttime, arvat, arvdate, arvtime, price from flight_info where flightcode='" + flightno + "'";
                    SqlCommand command1 = new SqlCommand(query1, con);
                    SqlDataReader reader1 = command1.ExecuteReader();

                    if (reader1.Read())
                    {
                        // Retrieve flight information
                        string departureAt = reader1["deptat"].ToString();
                        deptDate = Convert.ToDateTime(reader1["deptdate"]);
                        TimeSpan deptTime = TimeSpan.Parse(reader1["depttime"].ToString());
                        string arrivalAt = reader1["arvat"].ToString();
                        DateTime arrivalDate = Convert.ToDateTime(reader1["arvdate"]);
                        TimeSpan arrivalTime = TimeSpan.Parse(reader1["arvtime"].ToString());
                        int price = Convert.ToInt32(reader1["price"]);

                        string formattedDepartureDateTime = $"{deptDate:d} {deptTime:h\\:mm\\:ss}";
                        string formattedArrivalDateTime = $"{arrivalDate:d} {arrivalTime:h\\:mm\\:ss}";
                        departureatlbl.Text = departureAt;
                        deptdatelbl.Text = formattedDepartureDateTime;
                        arrivalatlbl.Text = arrivalAt;
                        arrivaldatelbl.Text = formattedArrivalDateTime;

                        if (clsoftrv == "economy")
                        {
                            totalAmount = price * total;
                        }
                        else if (clsoftrv == "business")
                        {
                            totalAmount = price * total * 2;
                        }
                        else if (clsoftrv == "first class")
                        {
                            totalAmount = price * total * 3;
                        }
                        payablealbl.Text = totalAmount.ToString()+"+" +2500+"(cancellation fee)";

                        reader1.Close(); // Close the second reader
                    }
                    else
                    {
                        MessageBox.Show("Flight information not found.");
                    }

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Passenger information not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            // Change the label text based on the selected radio button
            if (radioButton == cardrad)
            {
                chngpaylbl.Text = "Enter Card Number :";
            }
            else if (radioButton == intbankingrad)
            {
                chngpaylbl.Text = "Enter Bank Account Number :";
            }
            else if (radioButton == upirad)
            {
                chngpaylbl.Text = "Enter UPI NUMBER :";
            }
        }
        private void cardNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            // Assuming the textbox where the user enters the card number is named "cardNumberTextBox"
            string input = textBox1.Text.Trim();
            bool isValidCardNumber = ValidateCardNumber(input);

            // Enable the "Print Ticket" button if the input is a valid card number
            selectseatbtn.Enabled = isValidCardNumber;
        }

        private bool ValidateCardNumber(string input)
        {
            // Implement your card number validation logic here
            // For example, you can use a regular expression to validate the card number format
            // Replace the pattern with your actual card number validation pattern
            string pattern = @"^\d{10}$"; // Example pattern for 16-digit card numbers

            bool isValid = Regex.IsMatch(input, pattern);
            return isValid;
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Length < 10 || textBox1.Text.Length > 10)
            {
                MessageBox.Show("write proper payment details\n(eneter 10 numbers)", "ERROR TO PAYMENT ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBox1.Text.Length == 10)
            {
                string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True"; ;
                DateTime paymentdate = DateTime.Now;
                SqlConnection con = new SqlConnection(connection);
                string query = "INSERT into payment_info (deptdate,accountnumber,passengername,paymenttype,paymentdate,flightno,ticketno,paidamount)VALUES('"+deptDate.ToString("dd-MM-yyyy") + "','" + textBox1.Text + "','" + pasgnamelbl.Text + "','" + paymenttype.ToString() + "','" + paymentdate + "','" + flightnolbl.Text + "','" + ticketnolbl.Text + "','" + payablealbl.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PAYMENT SUCCESSFULL", "PAYMENT DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectseatbtn.Enabled = true;
                    selectseatbtn.Visible = true;
                    submitbtn.Enabled = false;
                    submitbtn.Visible = false;
                    con.Close();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
                selectseatbtn.Enabled = true;
                selectseatbtn.Visible = true;
                submitbtn.Enabled = false;
                submitbtn.Visible = false;
            }
            
        }

        private void selectseatbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            updateseatno u1 = new updateseatno();
            u1.Show();
        }
        private string paymenttype;
        private void cardrad_CheckedChanged(object sender, EventArgs e)
        {
            paymenttype = "card";
        }

        private void intbankingrad_CheckedChanged(object sender, EventArgs e)
        {
            paymenttype = "internet banking";
        }

        private void upirad_CheckedChanged(object sender, EventArgs e)
        {
            paymenttype = "UPI";
        }
    }
}
