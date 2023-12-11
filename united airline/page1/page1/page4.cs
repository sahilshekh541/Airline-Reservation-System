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
    public partial class page4 : Form
    {
        public page4()
        {
            InitializeComponent();
        }

        private void panel1_EnabledChanged(object sender, EventArgs e)
        {

        }
       

        private void page4_Load(object sender, EventArgs e)
        {

        }

        private void page4_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void addFlightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addfights a1 = new addfights();
            this.Hide();
            a1.Show();

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addemployee emp1 = new addemployee();
            this.Hide();
            emp1.Show();
        }

        private void updateFlightInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            updateflightinfo p = new updateflightinfo();
            this.Hide();
            p.Show();
        }

        private void flightOccupancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            flightoccupancy f1 = new flightoccupancy();
            this.Hide();
            f1.Show();

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
