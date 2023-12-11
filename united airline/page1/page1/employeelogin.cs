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
    public partial class employeelogin : Form
    {
        public employeelogin()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            page2 p2 = new page2();
            this.Hide();
            p2.Show();
        }

        private void login_Click(object sender, EventArgs e)
        {

            databaseconnections dt = new databaseconnections();

            string query;
            string username = username_txt2.Text;
            string password = password_txt2.Text;

            try
            {
                query = "select * from emp_login where empid='" + username_txt2.Text + "' AND emppass='" + password_txt2.Text + "'";
                DataSet ds = new DataSet();
                ds = dt.GetData(query);
                if (ds.Tables[0].Rows.Count > 0)
                {


                    username = username_txt2.Text;
                    password = password_txt2.Text;
                    page5 p5 = new page5();
                    p5.Show();
                    this.Hide();

                }
                else
                {

                    if (username_txt2.Text != string.Empty && password_txt2.Text != string.Empty)
                    {

                        MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    else
                    {
                        if (username_txt2.Text == string.Empty && password_txt2.Text == String.Empty)
                        {
                            MessageBox.Show("enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }

                        else
                        {
                            MessageBox.Show("enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }


                    }
                }
            

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }


        }

        private void password_txt2_TextChanged(object sender, EventArgs e)
        {
            password_txt2.PasswordChar = '*';
        }
    }
}
