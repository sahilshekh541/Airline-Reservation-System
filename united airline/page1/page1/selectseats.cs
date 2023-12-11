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
    public partial class selectseats : Form
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
      

        public string clsoftrv;
        public int tknumber;
        public int seats;
        public string flightcod;
        public string pasgnm;
        public int adlt;
        public int chld;
        public int inft;
        public selectseats(string clsoftravel, int tknumber, int selectseats , string flightcod,string name,int adlt,int chld,int inft)
        {



            InitializeComponent();

           
            selectedCheckboxes = new List<CheckBox>();

            clsoftrv = clsoftravel;
            this.tknumber = tknumber;
            this.seats = selectseats;
            this.flightcod = flightcod;
            this.pasgnm = name;
            this.chld = chld;
            this.adlt = adlt;
            this.inft = inft;
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



        private void seatisbooked()
        {
            string flightno = flightcod;
            
            string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            string query = "SELECT seatno FROM seatinfo WHERE flightno='" + flightno + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                  string  bookedSeatsString = reader.GetString(0);
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





        private void selectseats_Load(object sender, EventArgs e)
        {
            seatisbooked();
           
            label7.Text = clsoftrv;
            label9.Text = seats.ToString();
            label11.Text = tknumber.ToString();

            if (clsoftrv == l1)
            {
                
                disableeconomy();
                disablebsseats();

            }
            else if (clsoftrv == l2)
            {
               
                disableeconomy();
                disbalecheckboxes();
            }
            else if (clsoftrv == l3)
            {
                
                disbalecheckboxes();
                disablebsseats();
            }


            foreach (var checkbox in allboxes)
            {
                checkbox.CheckedChanged += Checkbox_CheckedChanged;

            }


        }

        private void UpdateSelectedLabelText()
        {

            string selectedSeats ="";


            foreach (CheckBox checkBox in selectedCheckboxes)
            {
                selectedSeats += checkBox.Text +',' ;
            }

            label6.Text = selectedSeats ;
           
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

                if (clsoftrv == l1)
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
                else if (clsoftrv == l2)
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
                else if (clsoftrv == l3)
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
            public void classlbl_Click(object sender, EventArgs e)
            {

            }

            private void paymentbtn_Click(object sender, EventArgs e)
            {

            }

            private void checkBox10_CheckedChanged(object sender, EventArgs e)
            {

            }

            private void clearbtn_Click(object sender, EventArgs e)
            {

            }

        private void confirmseatbtn_Click(object sender, EventArgs e)
        {
            DateTime bkd = DateTime.Now;
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "INSERT into seatinfo(seatno,bookdate,flightno,passengername,adlt,chld,inft,ticketno,seatclass)values('"+label6.Text+"','"+bkd+"','"+flightcod+"','"+pasgnm+"','"+adlt+"','"+chld+"','"+inft+"','"+tknumber+"','"+clsoftrv+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("YOUR SEAT IS BOOK SUCCESSFULLY", "INFROMATION...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                this.Refresh();
                foreach(var vb in allboxes)
                {
                    vb.Enabled = false;
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox65_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void paymentbtn_Click_1(object sender, EventArgs e)
        {

        }

        private void paymentbtn_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            paymentpage p1 = new paymentpage(tknumber,clsoftrv,label6.Text.ToString());
            p1.Show();
        }
    }
}






 

   
    

