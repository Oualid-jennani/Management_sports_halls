using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SPORT_PG
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Sportif-client;Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable DT = new DataTable();
        string name, passW;
        int PZ, posX, posY;
        public Form1()
        {
            InitializeComponent();
            User();
        }
        void User()
        {
            DT.Clear();
            cmd = new SqlCommand("Select * From ADMIN", cn);
            Da = new SqlDataAdapter(cmd);
            Da.Fill(DT);
            passW = DT.Rows[0][0].ToString();
            name = DT.Rows[0][1].ToString();
        }
        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            label9.Visible = false;
            pictureBox5.Visible = false;
            bunifuTextbox1._TextBox.Multiline = false;
            bunifuTextbox1._TextBox.ForeColor = Color.Yellow;
            bunifuTextbox2._TextBox.ForeColor = Color.Yellow;
            if (bunifuTextbox1.text != "") label1.Visible = false;
            else label1.Visible = true;
            label5.Visible = false;
            label6.Visible = false;
        }

        private void bunifuTextbox2_OnTextChange(object sender, EventArgs e)
        {
            label9.Visible = false;
            pictureBox5.Visible = false;
            bunifuTextbox2._TextBox.Multiline = false;
            bunifuTextbox2._TextBox.ForeColor = Color.Yellow;
            if (bunifuTextbox2.text != "") label2.Visible = false;
            else label2.Visible = true;
            if (bunifuSwitch1.Value == true) bunifuTextbox2._TextBox.PasswordChar = '*';
            else bunifuTextbox2._TextBox.PasswordChar = '\0';
            label6.Visible = false;
            AcceptButton = button1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            bunifuTextbox1.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            bunifuTextbox2.Focus();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
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

        }

        private void bunifuSwitch1_Click(object sender, EventArgs e)
        {
            if(bunifuSwitch1.Value==true) bunifuTextbox2._TextBox.PasswordChar = '*';
            else bunifuTextbox2._TextBox.PasswordChar = '\0';
        }
        static void start()
        {
            Application.Run(new Form2());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            pictureBox4.Visible = false;
            if (bunifuTextbox1.text==name && bunifuTextbox2.text == passW)
            {
                label10.Visible = true;
                pictureBox6.Visible = true;
                timer1.Start();
            }
            else
            {
                if (bunifuTextbox1.text != name && bunifuTextbox1.text != "")
                {
                    label9.Visible = true;
                    pictureBox5.Visible = true;
                    bunifuTextbox1._TextBox.ForeColor = Color.Red;
                    label5.Visible = true;
                    bunifuTextbox2.text = "";
                }

                if (bunifuTextbox2.text != passW && bunifuTextbox1.text == name)
                {
                    label9.Visible = true;
                    pictureBox5.Visible = true;
                    bunifuTextbox2._TextBox.ForeColor = Color.Red;
                    label6.Visible = true;
                }
                if (bunifuTextbox2.text != passW && bunifuTextbox1.text == name || bunifuTextbox1.text != name && bunifuTextbox1.text != "")
                {
                    label9.Visible = true;
                    pictureBox5.Visible = true;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < bunifuProgressBar1.MaximumValue)
            {
                bunifuProgressBar1.Value +=1;
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

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
           /* Random rnd = new Random();
            int one = rnd.Next(0, 255);
            int two = rnd.Next(0, 255);
            int tree = rnd.Next(0, 255);
            int four = rnd.Next(0, 255);

            label3.ForeColor = Color.FromArgb(one, two, tree, four);*/
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label7.Left--;
            if (label7.Left < -260)
                label7.Left = 300;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            PZ = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (PZ == 1)
            {
                this.SetDesktopLocation(MousePosition.X - posX, MousePosition.Y - posY);
            }
        }

    }
}
