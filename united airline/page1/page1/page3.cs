using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace page1
{
    public partial class page3 : Form
    {
        databaseconnections dt = new databaseconnections();
        string query;

        public page3()
        {
            InitializeComponent();
        }

        

        private void paasbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void page3_Load(object sender, EventArgs e)
        {

           


        }

        private void passbox_TextChanged(object sender, EventArgs e)
        {
           password_txt.PasswordChar = '*';
            
        }

        private void login_Click(object sender, EventArgs e)
        {
            
            string username = username_txt.Text;
            string password = password_txt.Text;

            try
            {
                query = "select * from admin_info where username='" + username_txt.Text + "' AND paasword='" + password_txt.Text + "'";
                DataSet ds = new DataSet();
                ds = dt.GetData(query);
                if (ds.Tables[0].Rows.Count > 0)
                {

                   
                    username = username_txt.Text;
                    password = password_txt.Text;
                    page4 p4 = new page4();
                    p4.Show();
                    this.Hide();

                }
                else
                {

                    if (username_txt.Text != string.Empty && password_txt.Text != string.Empty)
                    {
                        
                            MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }

                    else
                    {
                        if (username_txt.Text == string.Empty && password_txt.Text == String.Empty)
                        {
                            MessageBox.Show("enter username and password","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                           
                        }
                        
                        else
                        {
                            MessageBox.Show("enter password","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        }


                    }
                    username_txt.Clear();
                    password_txt.Clear();

                    username_txt.Focus();
                }
            }
            catch
            {
               
                MessageBox.Show("Error");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            page2 p2 = new page2();
            p2.Show();
        }

        private void page3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }
    }
}
