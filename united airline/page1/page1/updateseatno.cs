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
    public partial class updateseatno : Form
    {



        private List<CheckBox> allboxes;
        private List<CheckBox> checkboxes;
        private List<CheckBox> businessbox;
        private List<CheckBox> economybox;
        private int checkboxesSelected = 0;
        private List<CheckBox> selectedCheckboxes;
        List<string> bookedSeats = new List<string>();
        private string l1 = "first class";
        private string l2 = "business";
        private string l3 = "economy";
        private int seats;
        private int flightno;
        private string seatClass;

        public updateseatno()
        {

            selectedCheckboxes = new List<CheckBox>();
            


            InitializeComponent();

            allboxes = new List<CheckBox>
            {
                checkBox1,checkBox2,checkBox3,checkBox4,checkBox5,checkBox6,checkBox7,checkBox8,
                checkBox9,checkBox10,checkBox11,checkBox12,checkBox13,checkBox14,checkBox15,checkBox16,checkBox17,checkBox18,checkBox19,checkBox20,checkBox21,checkBox22,checkBox23,checkBox24,checkBox25,checkBox26,checkBox27,checkBox28,checkBox29,checkBox30,checkBox31,checkBox32,checkBox33,checkBox34,checkBox35,checkBox36,checkBox37,checkBox38,checkBox39,checkBox40,checkBox41,checkBox42,checkBox43,checkBox44,checkBox45,checkBox46,checkBox47,checkBox48,checkBox49,checkBox50,checkBox51,checkBox52,checkBox53,checkBox54,checkBox55,checkBox56,
                checkBox163, checkBox164, checkBox161, checkBox162, checkBox159, checkBox160, checkBox157, checkBox158, checkBox155, checkBox156, checkBox153, checkBox154, checkBox151, checkBox152, checkBox149, checkBox150, checkBox147, checkBox148, checkBox145, checkBox146, checkBox143, checkBox144, checkBox141, checkBox142, checkBox139, checkBox140, checkBox137, checkBox138, checkBox135, checkBox136, checkBox133, checkBox134, checkBox131, checkBox132, checkBox129, checkBox130, checkBox127, checkBox128, checkBox125, checkBox126, checkBox123, checkBox124, checkBox121, checkBox122, checkBox119, checkBox120, checkBox117, checkBox118, checkBox115, checkBox116, checkBox113, checkBox114, checkBox111, checkBox112, checkBox109, checkBox110, checkBox107, checkBox108, checkBox105, checkBox106, checkBox103, checkBox104, checkBox101, checkBox102, checkBox99, checkBox100, checkBox97, checkBox98, checkBox95, checkBox96, checkBox93, checkBox94, checkBox91, checkBox92, checkBox89, checkBox90, checkBox87, checkBox88, checkBox85, checkBox86, checkBox83, checkBox84, checkBox81, checkBox82, checkBox79, checkBox80, checkBox77, checkBox78, checkBox75, checkBox76, checkBox73, checkBox74, checkBox65, checkBox66, checkBox67, checkBox68, checkBox69, checkBox70, checkBox71, checkBox72, checkBox61, checkBox62, checkBox63, checkBox64, checkBox57, checkBox58, checkBox59, checkBox60,




            };
            checkboxes = new List<CheckBox>
            {
                checkBox1,checkBox2,checkBox3,checkBox4,checkBox5,checkBox6,checkBox7,checkBox8
            };

            businessbox = new List<CheckBox>
            {
               checkBox9,checkBox10,checkBox11,checkBox12,checkBox13,checkBox14,checkBox15,checkBox16,checkBox17,checkBox18,checkBox19,checkBox20,checkBox21,checkBox22,checkBox23,checkBox24,checkBox25,checkBox26,checkBox27,checkBox28,checkBox29,checkBox30,checkBox31,checkBox32,checkBox33,checkBox34,checkBox35,checkBox36,checkBox37,checkBox38,checkBox39,checkBox40,checkBox41,checkBox42,checkBox43,checkBox44,checkBox45,checkBox46,checkBox47,checkBox48,checkBox49,checkBox50,checkBox51,checkBox52,checkBox53,checkBox54,checkBox55,checkBox56
            };
            economybox = new List<CheckBox>
            {
                checkBox163, checkBox164, checkBox161, checkBox162, checkBox159, checkBox160, checkBox157, checkBox158, checkBox155, checkBox156, checkBox153, checkBox154, checkBox151, checkBox152, checkBox149, checkBox150, checkBox147, checkBox148, checkBox145, checkBox146, checkBox143, checkBox144, checkBox141, checkBox142, checkBox139, checkBox140, checkBox137, checkBox138, checkBox135, checkBox136, checkBox133, checkBox134, checkBox131, checkBox132, checkBox129, checkBox130, checkBox127, checkBox128, checkBox125, checkBox126, checkBox123, checkBox124, checkBox121, checkBox122, checkBox119, checkBox120, checkBox117, checkBox118, checkBox115, checkBox116, checkBox113, checkBox114, checkBox111, checkBox112, checkBox109, checkBox110, checkBox107, checkBox108, checkBox105, checkBox106, checkBox103, checkBox104, checkBox101, checkBox102, checkBox99, checkBox100, checkBox97, checkBox98, checkBox95, checkBox96, checkBox93, checkBox94, checkBox91, checkBox92, checkBox89, checkBox90, checkBox87, checkBox88, checkBox85, checkBox86, checkBox83, checkBox84, checkBox81, checkBox82, checkBox79, checkBox80, checkBox77, checkBox78, checkBox75, checkBox76, checkBox73, checkBox74, checkBox65, checkBox66, checkBox67, checkBox68, checkBox69, checkBox70, checkBox71, checkBox72, checkBox61, checkBox62, checkBox63, checkBox64, checkBox57, checkBox58, checkBox59, checkBox60,
            };
        }

        private void disbalecheckboxes()
        {
            checkboxes = new List<CheckBox>
            {
                checkBox1,checkBox2,checkBox3,checkBox4,checkBox5,checkBox6,checkBox7,checkBox8
            };
            foreach (var chk in checkboxes)
            {
                chk.Enabled = false;
            }
        }
        private void disablebsseats()
        {
            businessbox = new List<CheckBox>
            {
               checkBox9,checkBox10,checkBox11,checkBox12,checkBox13,checkBox14,checkBox15,checkBox16,checkBox17,checkBox18,checkBox19,checkBox20,checkBox21,checkBox22,checkBox23,checkBox24,checkBox25,checkBox26,checkBox27,checkBox28,checkBox29,checkBox30,checkBox31,checkBox32,checkBox33,checkBox34,checkBox35,checkBox36,checkBox37,checkBox38,checkBox39,checkBox40,checkBox41,checkBox42,checkBox43,checkBox44,checkBox45,checkBox46,checkBox47,checkBox48,checkBox49,checkBox50,checkBox51,checkBox52,checkBox53,checkBox54,checkBox55,checkBox56
            };
            foreach (var cb in businessbox)
            {
                cb.Enabled = false;
            }
        }
        private void disableeconomy()
        {
            economybox = new List<CheckBox>
            {
                checkBox163, checkBox164, checkBox161, checkBox162, checkBox159, checkBox160, checkBox157, checkBox158, checkBox155, checkBox156, checkBox153, checkBox154, checkBox151, checkBox152, checkBox149, checkBox150, checkBox147, checkBox148, checkBox145, checkBox146, checkBox143, checkBox144, checkBox141, checkBox142, checkBox139, checkBox140, checkBox137, checkBox138, checkBox135, checkBox136, checkBox133, checkBox134, checkBox131, checkBox132, checkBox129, checkBox130, checkBox127, checkBox128, checkBox125, checkBox126, checkBox123, checkBox124, checkBox121, checkBox122, checkBox119, checkBox120, checkBox117, checkBox118, checkBox115, checkBox116, checkBox113, checkBox114, checkBox111, checkBox112, checkBox109, checkBox110, checkBox107, checkBox108, checkBox105, checkBox106, checkBox103, checkBox104, checkBox101, checkBox102, checkBox99, checkBox100, checkBox97, checkBox98, checkBox95, checkBox96, checkBox93, checkBox94, checkBox91, checkBox92, checkBox89, checkBox90, checkBox87, checkBox88, checkBox85, checkBox86, checkBox83, checkBox84, checkBox81, checkBox82, checkBox79, checkBox80, checkBox77, checkBox78, checkBox75, checkBox76, checkBox73, checkBox74, checkBox65, checkBox66, checkBox67, checkBox68, checkBox69, checkBox70, checkBox71, checkBox72, checkBox61, checkBox62, checkBox63, checkBox64, checkBox57, checkBox58, checkBox59, checkBox60,
            };
            foreach (var ck in economybox)
            {
                ck.Enabled = false;
            }

        }

        public void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                if (!selectedCheckboxes.Contains(checkBox))
                {
                    selectedCheckboxes.Add(checkBox);
                    UpdateSelectedLabelText();
                }
                checkboxesSelected++;
                if (checkboxesSelected == seats)
                {
                    // Disable all checkboxes when 3 are selected
                    foreach (var cb in allboxes)
                    {
                        if (!cb.Checked)
                            cb.Enabled = false;
                    }
                }
            }

            else
            {

                if (textBox2.Text.ToString() == l1)
                {
                    if (selectedCheckboxes.Contains(checkBox))
                    {
                        selectedCheckboxes.Remove(checkBox);
                        UpdateSelectedLabelText();
                    }
                    checkboxesSelected--;
                    foreach (var cb in checkboxes)
                    {
                        cb.Enabled = true;
                    }

                }
                else if (textBox2.Text.ToString() == l2)
                {
                    if (selectedCheckboxes.Contains(checkBox))
                    {
                        selectedCheckboxes.Remove(checkBox);
                        UpdateSelectedLabelText();
                    }
                    checkboxesSelected--;
                    foreach (var cb in businessbox)
                    {
                        cb.Enabled = true;
                    }
                }
                else if (textBox2.Text.ToString() == l3)
                {
                    if (selectedCheckboxes.Contains(checkBox))
                    {
                        selectedCheckboxes.Remove(checkBox);
                        UpdateSelectedLabelText();
                    }
                    checkboxesSelected--;
                    foreach (var cb in economybox)
                    {
                        cb.Enabled = true;
                    }
                }
            }

        }

        private void UpdateSelectedLabelText()
        {

            string selectedSeats = "";


            foreach (CheckBox checkBox in selectedCheckboxes)
            {
                selectedSeats += checkBox.Text + ',';
            }

            label6.Text = selectedSeats;

        }
        private void seatisbooked()
        {

            string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            string query = "SELECT seatno FROM seatinfo where flightno='"+flightno+"' ";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string bookedSeatsString = reader.GetString(0);
                    List<string> bookedSeats = bookedSeatsString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    foreach (var vb in allboxes)
                    {
                        if (bookedSeats.Contains(vb.Text))
                        {

                            vb.Visible = false;
                        }
                    }
                }
                reader.Close();
                con.Close();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        


        private void updateseatno_Load(object sender, EventArgs e)
        {
            

            
            
        }


     

        private void checkBoxRetrieveData_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxRetrieveData.Checked)
            {
                if(!string.IsNullOrEmpty(textBoxTicketNo.Text))
                {
                    RetrieveSeatInfo(textBoxTicketNo.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a ticket number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkBoxRetrieveData.Checked = false;
                    textBoxTicketNo.Focus();
                }
            }
           
            
            
        
        }

      
            private void RetrieveSeatInfo(string ticketNumber)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT flightno,classoftravel,adult,child,infant FROM passenger_info WHERE ticketno = @TicketNumber";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TicketNumber", ticketNumber);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    flightno = Convert.ToInt32(reader["flightno"].ToString());
                    seatClass = reader["classoftravel"].ToString();
                    int adult = Convert.ToInt32(reader["adult"].ToString());
                    int child = Convert.ToInt32(reader["child"].ToString());
                    int infant = Convert.ToInt32(reader["infant"].ToString());
                    seats = adult + child + infant;
                    textBox2.Text = seatClass;
                    seatisbooked();
                    label7.Text = seats.ToString();


                    if (seatClass == l1)
                    {
                        
                        disableeconomy();
                        disablebsseats();

                    }
                    else if (seatClass == l2)
                    {

                        disableeconomy();
                        disbalecheckboxes();
                    }
                    else if (seatClass == l3)
                    {

                        disbalecheckboxes();
                        disablebsseats();
                    }


                    foreach (var checkbox in allboxes)
                    {
                        checkbox.CheckedChanged += Checkbox_CheckedChanged;

                    }



                }
                else
                {
                    MessageBox.Show("No data found for the specified ticket number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBoxRetrieveData.Checked = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void conformbtn_Click(object sender, EventArgs e)
        {

            string selectedSeats = label6.Text;

            if (!string.IsNullOrEmpty(selectedSeats))
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);

                string query = "UPDATE seatinfo SET seatno = @SeatNumbers ,seatclass=@seatclass WHERE ticketno = @TicketNumber";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SeatNumbers", selectedSeats);
                cmd.Parameters.AddWithValue("@seatclass", seatClass);
                cmd.Parameters.AddWithValue("@TicketNumber", textBoxTicketNo.Text);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Your seat information has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foreach(var chkb in allboxes)
                        {
                            chkb.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select at least one seat.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void checkBox111_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void printticketbtn_Click(object sender, EventArgs e)
        {
           
            printicketopt p1 = new printicketopt();
            this.Hide();
            p1.Show();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            page5 p5 = new page5();
            this.Hide();
            p5.Show();
        }
    }
}
