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
    public partial class page2 : Form
    {
        public page2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            page3 p3 = new page3();
            p3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            employeelogin emp = new employeelogin();
            this.Hide();
            emp.Show();
        }
    }
}
