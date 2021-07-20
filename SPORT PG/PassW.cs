using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SPORT_PG
{
    public partial class PassW : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Sportif-client;Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable DT = new DataTable();
        string passW;
        int PZ, posX, posY;
        public PassW()
        {
            InitializeComponent();
            textBox1.PasswordChar = '*';
            User();
        }
        void User()
        {
            DT.Clear();
            cmd = new SqlCommand("Select * From ADMIN", cn);
            Da = new SqlDataAdapter(cmd);
            Da.Fill(DT);
            passW = DT.Rows[0][0].ToString();
        }

        private void PassW_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Left--;
            if (label4.Left == -200) label4.Left = 300;
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked == true)
            {
                label7.Visible = true;
                textBox4.Visible = true;
                textBox4.Text = "";
            }
            else
            {
                label7.Visible = false;
                textBox4.Visible = false;
            }
            if (bunifuCheckbox1.Checked == false && textBox3.Text == "")
            {
                button1.Visible = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            textBox4.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textBox3.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == " ") textBox1.Text = "";
            if (textBox1.Text != "") label1.Visible = false;
            else
            {
                label1.Visible = true;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == " ") textBox2.Text = "";
            if (textBox1.Text == "") textBox2.Text = "";
            if (textBox2.Text != "") label2.Visible = false;
            else
            {
                label2.Visible = true;
                textBox3.Text = "";
                label10.Visible = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == " ") textBox3.Text = "";
            if (textBox3.Text != "") button1.Visible = true;
            else button1.Visible = false;
            if (textBox2.Text == "") textBox3.Text = "";
            if (textBox3.Text != "") label3.Visible = false;
            else label3.Visible = true;
            label10.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox4.Text = "";
            if (textBox4.Text != "")
            {
                label7.Visible = false;
            }
            else label7.Visible = true;
            if (textBox4.Text == " ") textBox4.Text = "";
            if (textBox4.Text != "" || textBox4.Text == "" && textBox3.Text != "")
            {
                button1.Visible = true;
            }
            else button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool changePS = false;
            bool changeNeme = false;
            try
            {
                if (textBox1.Text == passW)
                {
                    label9.Visible = false;
                    if (textBox2.Text != "")
                    {
                        if (textBox2.Text == textBox3.Text)
                        {
                            label10.Visible = false;
                            changePS = true;
                        }
                        else
                        {
                            label10.Visible = true;
                        }
                    }
                    else
                    {
                        label10.Visible = false;
                    }
                    if (bunifuCheckbox1.Visible==true && label10.Visible == false)
                    {
                        if (textBox4.Text != "")
                        {
                            changeNeme = true;
                        }
                    }
                }
                else
                {
                    label9.Visible = true;
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                if (changePS == true && changeNeme == false)
                {
                    DialogResult REZ = MessageBox.Show("Do you really want to change your password", "Change password", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (REZ == DialogResult.OK)
                    {
                        ChangeP();
                    }
                    
                }
                else if (changePS == false && changeNeme == true)
                {
                    DialogResult REZ = MessageBox.Show("You really want to change your username", "Change User Name", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (REZ == DialogResult.OK)
                    {
                        ChangeN();
                        MessageBox.Show("Change Susseccfully");
                    }
                }
                else if (changePS == true && changeNeme == true)
                {
                    DialogResult REZ = MessageBox.Show("You really want to change your username and password", "Change password and User Name", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (REZ == DialogResult.OK)
                    {
                        ChangeP();
                        ChangeN();
                        MessageBox.Show("Change Susseccfully");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                cn.Close();
            }
            User();
           
        }

        private void bunifuSwitch1_Click(object sender, EventArgs e)
        {
            if (bunifuSwitch1.Value == false)
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
            else
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void PassW_MouseDown(object sender, MouseEventArgs e)
        {
            PZ = 1;
            posX = e.X;
            posY = e.Y;
        }

        private void PassW_MouseUp(object sender, MouseEventArgs e)
        {
            PZ = 0;
        }

        private void PassW_MouseMove(object sender, MouseEventArgs e)
        {
            if (PZ == 1)
            {
                this.SetDesktopLocation(MousePosition.X - posX, MousePosition.Y - posY);
            }
        }

        void ChangeN()
        {
            cmd = new SqlCommand("Update ADMIN Set Name ='" + textBox4.Text + "'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        void ChangeP()
        {
            cmd = new SqlCommand("Update ADMIN Set PassW ='" + textBox3.Text + "'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
