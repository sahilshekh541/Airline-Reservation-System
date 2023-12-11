using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace page1
{
    public partial class page1 : Form
    {
        public page1()
        {
            InitializeComponent();
        }

        private void page1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbar.ForeColor = Color.Blue;
            pbar.Value += 1;
            if(pbar.Value < 50)
            {
                label4.Text = "Please Wait.....";
            }
            if(pbar.Value > 50)
            {
                label4.Text = "Launching App......";
            }
            if(pbar.Value >= 100)
            {
                timer1.Stop();
                this.Hide();
                page2 p2 = new page2();
                p2.Show();
                
            }
        }

        internal class airlinereservationsystemDataSet1
        {
        }

        internal class airlinereservationsystemDataSet1TableAdapters
        {
            internal class flight_infoTableAdapter
            {
            }
        }
    }
}
