namespace page1
{
    partial class passengerinformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(passengerinformation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.infant = new System.Windows.Forms.ComboBox();
            this.child = new System.Windows.Forms.ComboBox();
            this.adult = new System.Windows.Forms.ComboBox();
            this.classoftravel = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.submittbn = new System.Windows.Forms.Button();
            this.backbtn = new System.Windows.Forms.Button();
            this.pasgage = new System.Windows.Forms.TextBox();
            this.pasgadd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pasgname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.infant);
            this.panel1.Controls.Add(this.child);
            this.panel1.Controls.Add(this.adult);
            this.panel1.Controls.Add(this.classoftravel);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.submittbn);
            this.panel1.Controls.Add(this.backbtn);
            this.panel1.Controls.Add(this.pasgage);
            this.panel1.Controls.Add(this.pasgadd);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pasgname);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(597, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 730);
            this.panel1.TabIndex = 0;
            // 
            // infant
            // 
            this.infant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infant.FormattingEnabled = true;
            this.infant.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.infant.Location = new System.Drawing.Point(516, 473);
            this.infant.Name = "infant";
            this.infant.Size = new System.Drawing.Size(122, 30);
            this.infant.TabIndex = 36;
            // 
            // child
            // 
            this.child.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.child.FormattingEnabled = true;
            this.child.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.child.Location = new System.Drawing.Point(270, 473);
            this.child.Name = "child";
            this.child.Size = new System.Drawing.Size(122, 30);
            this.child.TabIndex = 35;
            // 
            // adult
            // 
            this.adult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adult.FormattingEnabled = true;
            this.adult.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.adult.Location = new System.Drawing.Point(22, 473);
            this.adult.Name = "adult";
            this.adult.Size = new System.Drawing.Size(122, 30);
            this.adult.TabIndex = 34;
            // 
            // classoftravel
            // 
            this.classoftravel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classoftravel.FormattingEnabled = true;
            this.classoftravel.Items.AddRange(new object[] {
            "Select",
            "first class",
            "business",
            "economy"});
            this.classoftravel.Location = new System.Drawing.Point(19, 577);
            this.classoftravel.Name = "classoftravel";
            this.classoftravel.Size = new System.Drawing.Size(269, 30);
            this.classoftravel.TabIndex = 33;
            this.classoftravel.SelectedIndexChanged += new System.EventHandler(this.classoftravel_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 541);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(203, 30);
            this.label11.TabIndex = 32;
            this.label11.Text = "Class Of Travel";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(522, 426);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 30);
            this.label10.TabIndex = 31;
            this.label10.Text = "Infant";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(275, 426);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 30);
            this.label9.TabIndex = 30;
            this.label9.Text = "child";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 426);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 30);
            this.label8.TabIndex = 29;
            this.label8.Text = "Adult";
            // 
            // submittbn
            // 
            this.submittbn.BackColor = System.Drawing.Color.Black;
            this.submittbn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submittbn.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submittbn.ForeColor = System.Drawing.Color.White;
            this.submittbn.Location = new System.Drawing.Point(408, 648);
            this.submittbn.Name = "submittbn";
            this.submittbn.Size = new System.Drawing.Size(179, 46);
            this.submittbn.TabIndex = 28;
            this.submittbn.Text = "Submit";
            this.submittbn.UseVisualStyleBackColor = false;
            this.submittbn.Click += new System.EventHandler(this.submittbn_Click);
            // 
            // backbtn
            // 
            this.backbtn.BackColor = System.Drawing.Color.Black;
            this.backbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backbtn.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backbtn.ForeColor = System.Drawing.Color.White;
            this.backbtn.Location = new System.Drawing.Point(75, 648);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(179, 46);
            this.backbtn.TabIndex = 27;
            this.backbtn.Text = "Back";
            this.backbtn.UseVisualStyleBackColor = false;
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // pasgage
            // 
            this.pasgage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pasgage.Location = new System.Drawing.Point(274, 245);
            this.pasgage.Multiline = true;
            this.pasgage.Name = "pasgage";
            this.pasgage.Size = new System.Drawing.Size(282, 33);
            this.pasgage.TabIndex = 6;
            // 
            // pasgadd
            // 
            this.pasgadd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pasgadd.Location = new System.Drawing.Point(274, 320);
            this.pasgadd.Multiline = true;
            this.pasgadd.Name = "pasgadd";
            this.pasgadd.Size = new System.Drawing.Size(282, 33);
            this.pasgadd.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 26);
            this.label6.TabIndex = 4;
            this.label6.Text = "Age :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "Address :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "Passenger-1-Name :\r\n";
            // 
            // pasgname
            // 
            this.pasgname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pasgname.Location = new System.Drawing.Point(274, 170);
            this.pasgname.Multiline = true;
            this.pasgname.Name = "pasgname";
            this.pasgname.Size = new System.Drawing.Size(282, 33);
            this.pasgname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(134, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(399, 40);
            this.label3.TabIndex = 0;
            this.label3.Text = "Passenger Information";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(705, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Mistral", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(850, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 29);
            this.label2.TabIndex = 27;
            this.label2.Text = "Explore The World With Us";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Engravers MT", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(809, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 51);
            this.label1.TabIndex = 26;
            this.label1.Text = "FLY SAFE";
            // 
            // passengerinformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::page1.Properties.Resources.unitedplane;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "passengerinformation";
            this.Text = "Ariline Reservation System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.passengerinformation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox pasgage;
        private System.Windows.Forms.TextBox pasgadd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pasgname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submittbn;
        private System.Windows.Forms.Button backbtn;
        private System.Windows.Forms.ComboBox infant;
        private System.Windows.Forms.ComboBox child;
        private System.Windows.Forms.ComboBox adult;
        public System.Windows.Forms.ComboBox classoftravel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}