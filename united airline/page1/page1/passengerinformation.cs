using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace page1
{
    public partial class passengerinformation : Form
    {

        public string name { get; private set; }
        public string age { get; private set; }
        public string add { get; private set; }
        public int adlt { get; private set; }
        public int chld { get; private set; }
        public int inft { get; private set; }
        public string clsoftravel{ get; private set; }
        public int ticketno { get; private set; }
        public int totalseats { get; private set; }

        
        private string flightcod;
        private string deptat;
        private DateTime deptdatetime;
        private string arvat;
        private DateTime arvdatetime;

        // this data pass to the selectseat page
        public string travelclass;
        public int tknumber;
        public int selectseats;
        private string formatteddeptDateTime;
        private string formattedArvDateTime;
        private DateTime selectedDepartDate;

        public passengerinformation (string flightcd,string deptat,DateTime deptDateTime, string arvat,DateTime arvDateTime)
        {
            InitializeComponent();
            
            flightcod = flightcd;
            this.deptat = deptat;
            this.deptdatetime = deptDateTime;
            this.arvat = arvat;
            this.arvdatetime = arvDateTime;

            formatteddeptDateTime = deptdatetime.ToString("yyyy-MM-dd HH:mm:ss");
            formattedArvDateTime = arvdatetime.ToString("yyyy-MM-dd HH:mm:ss");


        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            page5 b1 = new page5();
            this.Hide();
            b1.Show();
        }

        private void submittbn_Click(object sender, EventArgs e)
        {

            int randticketno()
            {
                int _min = 1000;
                int _max = 9999;
                Random _rdm = new Random();
                return _rdm.Next(_min, _max);

            }

            int tckt = randticketno();

            name = pasgname.Text;
            age = pasgage.Text;
            add = pasgadd.Text;
            adlt = int.Parse(adult.SelectedItem.ToString());
            chld = int.Parse(child.SelectedItem.ToString());
            inft = int.Parse(infant.SelectedItem.ToString());
            clsoftravel = classoftravel.Text;
            ticketno = tckt;
            totalseats = adlt + chld + inft;
            DateTime bkdate = DateTime.Now;

            
            tknumber = ticketno;
            selectseats = totalseats;

            if (string.IsNullOrEmpty(pasgname.Text) || string.IsNullOrEmpty(pasgage.Text) || string.IsNullOrEmpty(pasgadd.Text) || adult.SelectedIndex == -1 || child.SelectedIndex == -1 || infant.SelectedIndex == -1 || classoftravel.SelectedIndex == -1)
            {
                MessageBox.Show("FILL ALL REQUIRMENT'S ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            
            else
            {

                

                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#project\\united airline\\page1\\page1\\airlinereservationsystem.mdf;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO passenger_info (ticketno,passengername,passengeraddress,passengerage,adult,child,infant,classoftravel,passengers,flightno,bookdate,deptat,deptdatetime,arvat,arvdaterime)values('" + ticketno + "','" + name + "','" + add + "','" + age + "','" + adlt + "','" + chld + "','" + inft + "','" + clsoftravel + "','" + totalseats + "','" + flightcod + "','" + bkdate + "','"+deptat+"','"+formatteddeptDateTime+"','"+arvat+"','"+formattedArvDateTime+"')";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {

                            command.ExecuteNonQuery();

                            selectseats s1 = new selectseats(clsoftravel, tknumber, selectseats, flightcod,name,adlt,chld,inft);
                            this.Hide();
                            s1.Show();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            

           
        }

        private void passengerinformation_Load(object sender, EventArgs e)
        {
            classoftravel.SelectedIndex = 0;
            adult.SelectedIndex = 0;
            child.SelectedIndex = 0;
            infant.SelectedIndex = 0;

        }

        private void classoftravel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
