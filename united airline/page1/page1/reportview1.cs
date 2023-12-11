using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace page1
{
    public partial class reportview1 : Form
    {

        private string gusetname;
        private string from;
        private string to;
        private string ticketno;
        private string seatno;
        private string bookdate;
        private string flightno;
        private string seatclas;
        private string deptdt;
        private string avdt;

        public reportview1(string gusetname , string ticketno, string seatno, string bookingdate,string  flightno, string seatclass, string from, string to,string departdate,string arvadate)
        {
            InitializeComponent();
            this.gusetname = gusetname;
            this.from = from;
            this.to = to;
            this.ticketno = ticketno;
            this.seatno = seatno;
            this.bookdate = bookingdate;
            this.flightno = flightno;
            this.seatclas = seatclass;
            this.deptdt = departdate;
            this.avdt = arvadate;

        }

        private void reportview1_Load(object sender, EventArgs e)
        {
            ticketnolbl.Text = ticketno;
            seatnolbl.Text = seatno;
            bookingdatelbl.Text = bookdate;
            flightnolbl.Text = flightno;
            gusetnamelbl.Text = gusetname;
            seatclasslbl.Text = seatclas;
            fromlbl.Text = from;
            tolbl.Text = to;
            departuredatelbl.Text = deptdt;
            arrivaldatelbl.Text = avdt;

        }

      

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Create a graphics object to draw on the print document
            Graphics g = e.Graphics;

            // Calculate the scaling factor to fit the panel's content within the print page
            float scale = Math.Min(
                e.MarginBounds.Width / panel1.Width,
                e.MarginBounds.Height / panel1.Height
            );

            // Create a bitmap that matches the panel's size
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);

            // Draw the panel's content onto the bitmap
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));

            // Draw the bitmap on the print document, scaled to fit within the page margins
            g.DrawImage(bmp, e.MarginBounds, new Rectangle(Point.Empty, panel1.Size), GraphicsUnit.Pixel);
        }

       

        private void printbtn_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = pd;

            previewDialog.WindowState = FormWindowState.Maximized;

            // Show the print preview dialog
            previewDialog.ShowDialog();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            page5 p5 = new page5();
            this.Hide();
            p5.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}
