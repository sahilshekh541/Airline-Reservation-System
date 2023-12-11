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
    public partial class addemployee : Form
    {
        String genders;
        String maritalstatus;
        
        public addemployee()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            genders = "other";
        }

        private void back_Click(object sender, EventArgs e)
        {
            page4 p4 = new page4();
            this.Hide();
            p4.Show();
        }

        //form validation
        private bool IsFilled(string s)
        {
            if (s != "")
            { return true; }
            else
            { return false; }
        }


        //regex for emial validation 
        System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

       

        

        private void male_CheckedChanged(object sender, EventArgs e)
        {
            genders = "male";
        }

        private void female_CheckedChanged(object sender, EventArgs e)
        {
            genders = "female";
        }

        private void married_CheckedChanged(object sender, EventArgs e)
        {
            maritalstatus = "married";
        }

        private void unmarried_CheckedChanged(object sender, EventArgs e)
        {
            maritalstatus = "unmarried";
        }

        private void addemployee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            String email = emailid.Text;

           
                if (IsFilled(empname.Text))
                {
                if (IsFilled(empfathername.Text))
                {
                    if (IsFilled(empdob.Text))
                    {
                        if (male.Checked || female.Checked || other.Checked)
                        {
                            if (married.Checked || unmarried.Checked)
                            {
                                if (IsFilled(nationality.Text))
                                {
                                    if (IsFilled(qualification.Text))
                                    {
                                        if (IsFilled(address.Text))
                                        {
                                            if (IsFilled(phoneno.Text))
                                            {
                                                if (phoneno.TextLength != 10)
                                                {
                                                    MessageBox.Show("Ennter valid Number", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else
                                                {
                                                    if (IsFilled(emailid.Text))
                                                    {



                                                        emailvalidation();



                                                    }

                                                    else
                                                    {
                                                        MessageBox.Show("enter emai address", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                                    }
                                                }


                                            }
                                            else
                                            {

                                                MessageBox.Show("enter phone no", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("enter Address", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("ener qualificaion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("enter nationality", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                }
                            }
                            else
                            {
                                MessageBox.Show("choser marital status", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Choose Valid gender", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        }
                          else
                          {
                        MessageBox.Show("Enter D.O.B", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    }
                      else
                      {
                         MessageBox.Show("Enter father name ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                      }
                }
                else
                {
                    MessageBox.Show("please fill full detail of employee", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            
            void emailvalidation()
            {
                if (expr.IsMatch(email))
                {
                    databaseconnections dbs = new databaseconnections();

                    String query = "insert into Emp_info (fullname,fathername,DOB,gender,maritalstatus,nationality,qualification,address,phoneno,emailid) values ('" + this.empname.Text + "','" + this.empfathername.Text + "','" + this.empdob.Text + "', '" + this.genders + "' , '" + this.maritalstatus + "','" + this.nationality.Text + "','" + this.qualification.Text + "','" + this.address.Text + "','" + this.phoneno.Text + "','" + this.emailid.Text + "')";


                    string result = empname.Text.Split()[0];
                    int randompass()
                    {
                        int _min = 1000;
                        int _max = 9999;
                        Random _rdm = new Random();
                        return _rdm.Next(_min, _max);

                    }

                    int emppass = randompass();

                    string query1 = "insert into emp_login (empid,emppass)values ('" + result + "','" + emppass + "')";



                    dbs.setdata(query);


                    dbs.setdata(query1);

                    MessageBox.Show("New Employee Add" + '\n' + "emp id :" + result + '\n' + "paasword is : " + emppass);

                }
                else
                {
                    MessageBox.Show("email is invalid", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
    
}
