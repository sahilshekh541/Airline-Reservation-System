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
    public partial class page5 : Form
    {
        public page5()
        {
            InitializeComponent();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                page2 p2 = new page2();
                this.Hide();
                p2.Show();
            }
            else
            {
                this.Refresh();
            }
        }

        private void flightOccupancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Booktickets bkt = new Booktickets();
            this.Hide();
            bkt.Show();
        }

        private void addFlightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printicketopt p1 = new printicketopt();
            this.Hide();
            p1.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateticket u1 = new updateticket();
            this.Hide();
            u1.Show();
        }

        private void updateFlightInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateseatno u1 = new updateseatno();
            this.Hide();
            u1.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cancelticket c1 = new cancelticket();
            this.Hide();
            c1.Show();
        }

        private void passengerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            passengerlist p1 = new passengerlist();
            this.Hide();
            p1.Show();
        }

        private void viewFlightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewflightlist v1=new viewflightlist();
            this.Hide();
            v1.Show();
        }

        private void canceledTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewcanceltickets c1 = new viewcanceltickets();
            this.Hide();
            c1.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            viewpayments p1 = new viewpayments();
            this.Hide();
            p1.Show();
        }
    }
}
