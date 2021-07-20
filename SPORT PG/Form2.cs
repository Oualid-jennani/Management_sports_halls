using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPORT_PG
{
    public partial class Form2 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Sportif-client;Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter Da;

        int PZ, posX, posY;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            PZ = 1;
            posX = e.X;
            posY = e.Y;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            /*
            Random rnd = new Random();
            int one = rnd.Next(0, 255);
            int two = rnd.Next(0, 255);
            int tree = rnd.Next(0, 255);
            int four = rnd.Next(0, 255);
            label1.ForeColor = Color.FromArgb(two, four, tree, one);
            label2.ForeColor = Color.FromArgb(one, four, tree, two);
            label3.ForeColor = Color.FromArgb(tree, one, four, two);
            label4.ForeColor = Color.FromArgb(one, tree, two, four);
            label5.ForeColor = Color.FromArgb(four, two, tree, one);
            label6.ForeColor = Color.FromArgb(four, two, tree, one);
            label7.ForeColor = Color.FromArgb(one, two, tree, four);*/
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            timer4.Start();
        }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

        }      
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            label8.Left--;
            if (label8.Left < -600)
                label8.Left = 680;
        }
        static void start()
        {
            Application.Run(new Form1());
        }
        static void start4()
        {
            Application.Run(new KongFu());
        }
        static void start6()
        {
            Application.Run(new Form4());
        }
        static void start5()
        {
            Application.Run(new Form3());
        }
        static void start7()
        {
            Application.Run(new Form5());
        }
        static void start8()
        {
            Application.Run(new Form6());
        }
        static void start9()
        {
            Application.Run(new Form7());
        }
        static void start10()
        {
            Application.Run(new GNR());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < bunifuProgressBar1.MaximumValue)
            {
                bunifuProgressBar1.Value += 1;
            }
            else
            {
                timer1.Stop();
                Thread THR = new Thread(start);
                THR.SetApartmentState(ApartmentState.STA);
                THR.Start();

                this.Close();
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < bunifuProgressBar1.MaximumValue)
            {
                bunifuProgressBar1.Value += 1;
            }
            else
            {
                timer4.Stop();
                Thread THR = new Thread(start4);
                THR.SetApartmentState(ApartmentState.STA);
                THR.Start();

                this.Close();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < bunifuProgressBar1.MaximumValue)
            {
                bunifuProgressBar1.Value += 1;
            }
            else
            {
                timer5.Stop();
                Thread THR = new Thread(start5);
                THR.SetApartmentState(ApartmentState.STA);
                THR.Start();

                this.Close();
            }
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            timer5.Start();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            timer6.Start();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < bunifuProgressBar1.MaximumValue)
            {
                bunifuProgressBar1.Value += 1;
            }
            else
            {
                timer6.Stop();
                Thread THR = new Thread(start6);
                THR.SetApartmentState(ApartmentState.STA);
                THR.Start();

                this.Close();
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < bunifuProgressBar1.MaximumValue)
            {
                bunifuProgressBar1.Value += 1;
            }
            else
            {
                timer7.Stop();
                Thread THR = new Thread(start7);
                THR.SetApartmentState(ApartmentState.STA);
                THR.Start();

                this.Close();
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            timer7.Start();
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < bunifuProgressBar1.MaximumValue)
            {
                bunifuProgressBar1.Value += 1;
            }
            else
            {
                timer8.Stop();
                Thread THR = new Thread(start8);
                THR.SetApartmentState(ApartmentState.STA);
                THR.Start();

                this.Close();
            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            timer8.Start();
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < bunifuProgressBar1.MaximumValue)
            {
                bunifuProgressBar1.Value += 1;
            }
            else
            {
                timer9.Stop();
                Thread THR = new Thread(start9);
                THR.SetApartmentState(ApartmentState.STA);
                THR.Start();

                this.Close();
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            timer9.Start();
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToLongTimeString();
            if (pictureBox5.Visible == true) pictureBox5.Visible = false;
            else pictureBox5.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            PassW pas = new PassW();
            pas.Show();
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < bunifuProgressBar1.MaximumValue)
            {
                bunifuProgressBar1.Value += 1;
            }
            else
            {
                timer11.Stop();
                Thread THR = new Thread(start10);
                THR.SetApartmentState(ApartmentState.STA);
                THR.Start();

                this.Close();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            timer11.Start();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            label14.Visible = true;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            label14.Visible = false;
        }

        private void Form2_MouseHover(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            if (label10.Visible == true) label10.Visible = false;
            else label10.Visible = true;
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            PZ = 0;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (PZ == 1)
            {
                this.SetDesktopLocation(MousePosition.X - posX, MousePosition.Y - posY);
            }
        }
    }
}
