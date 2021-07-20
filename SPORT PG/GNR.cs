using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SPORT_PG
{
    public partial class GNR : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Sportif-client;Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable DT = new DataTable();
        DataTable DM = new DataTable();
        DateTime myDate;
        int PZ, posX, posY;
        int Jeurs,Tjour;
        bool prix = true;
        public GNR()
        {
            InitializeComponent();
            bunifuTextbox6._TextBox.Multiline = false;
            bunifuTextbox1._TextBox.Multiline = false;
            bunifuTextbox2._TextBox.Multiline = false;
            PRIX();
        }
        private void GNR_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        void Search()
        {
            try
            {
                DT.Clear();

                if (radioButton1.Checked == true)
                    Da = new SqlDataAdapter("select * From client Where Name like '%" + bunifuTextbox6.text + "%' and typeC = 'KRT'", cn);



                if (radioButton2.Checked == true)
                    Da = new SqlDataAdapter("select * From client Where Name like '%" + bunifuTextbox6.text + "%' and typeC = 'KIK'", cn);


                if (radioButton3.Checked == true)
                    Da = new SqlDataAdapter("select * From client Where Name like '%" + bunifuTextbox6.text + "%' and typeC = 'MUS'", cn);


                if (radioButton4.Checked == true)
                    Da = new SqlDataAdapter("select * From client Where Name like '%" + bunifuTextbox6.text + "%' and typeC = 'KONGF'", cn);


                if (radioButton5.Checked == true)
                    Da = new SqlDataAdapter("select * From client Where Name like '%" + bunifuTextbox6.text + "%' and typeC = 'TYK'", cn);


                if (radioButton6.Checked == true)
                    Da = new SqlDataAdapter("select * From client Where Name like '%" + bunifuTextbox6.text + "%' and typeC = 'JUDO'", cn);


                Da.Fill(DT);
                DT.Columns.Remove("Image");
                DT.Columns.Remove("DateP");
                DT.Columns.Remove("Prix");
                this.dataGridView1.DataSource = DT;
            }
            catch (Exception ex) { }

        }
        void image()
        {
            if (radioButton1.Checked == true)
                cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString()+ "%' and typeC = 'KRT'", cn);

            if (radioButton2.Checked == true)
                cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString() + "%' and typeC = 'KIK'", cn);

            if (radioButton3.Checked == true)
                cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString() + "%' and typeC = 'MUS'", cn);

            if (radioButton4.Checked == true)
                cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString() + "%' and typeC = 'KONGF'", cn);

            if (radioButton5.Checked == true)
                cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString() + "%' and typeC = 'TYK'", cn);

            if (radioButton6.Checked == true)
                cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString() + "%' and typeC = 'JUDO'", cn);


            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (!(dr[6] == DBNull.Value))
            {
                MemoryStream ms = new MemoryStream((byte[])dr.GetValue(6));
                pictureBox9.Image = Image.FromStream(ms);
                dr.Close();
                cn.Close();
            }
            else
            {
                pictureBox9.Image = null;
                dr.Close();
                cn.Close();
            }
        }

        private void bunifuTextbox6_OnTextChange(object sender, EventArgs e)
        {
            if (bunifuTextbox6.text != "") label11.Visible = false;
            else label11.Visible = true;
            Search();
            sup();
        }
        void sup()
        {
            label5.Text = ""; label8.Text = ""; bunifuCalendar1.Value = DateTime.Now;
            radioButton8.Checked = false;
            radioButton8.Checked = false;
            pictureBox9.Image = null;
        }
        private void label11_Click(object sender, EventArgs e)
        {
            bunifuTextbox6.Focus();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuImageButton1.Visible = false;
                label5.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                label8.Text = dataGridView1.CurrentRow.Cells["CIN"].Value.ToString();


                if (radioButton1.Checked == true)
                    cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString() + "%' and typeC = 'KRT'", cn);

                if (radioButton2.Checked == true)
                    cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString() + "%' and typeC = 'KIK'", cn);

                if (radioButton3.Checked == true)
                    cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString() + "%' and typeC = 'MUS'", cn);

                if (radioButton4.Checked == true)
                    cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString() + "%' and typeC = 'KONGF'", cn);

                if (radioButton5.Checked == true)
                    cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString() + "%' and typeC = 'TYK'", cn);

                if (radioButton6.Checked == true)
                    cmd = new SqlCommand("select * From client Where CIN like '%" + dataGridView1.CurrentRow.Cells["CIN"].Value.ToString() + "%' and typeC = 'JUDO'", cn);


                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (!(dr[7] == DBNull.Value))
                {
                    myDate = DateTime.Parse(dr[7].ToString());
                    bunifuCalendar1.Value = myDate;
                }
                else
                {
                    myDate = DateTime.Now;
                    bunifuCalendar1.Value = DateTime.Now;
                }
                if (!(dr[8] == DBNull.Value))
                {
                    string test = dr[8].ToString();
                    if (test == "true")
                    {
                        radioButton8.Checked = true; radioButton9.Checked = false; prix = true;

                    }
                    else if (test == "false") { radioButton8.Checked = false; radioButton9.Checked = true; prix = false; }
                }
                else
                {
                    radioButton8.Checked = false; radioButton9.Checked = true;
                    prix = false;
                }
                dr.Close();
                cn.Close();
                image();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
            finally
            {
                cn.Close();
            }
            System.TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - myDate.Ticks);
            Tjour = int.Parse(ts.Days.ToString());
            if (Tjour >= Jeurs)
            {
                ReturnPRIX();
            }
        }
        void PRIX()
        {
            try
            {
                DM.Clear();
                cmd = new SqlCommand("Select * From MONEY", cn);
                Da = new SqlDataAdapter(cmd);
                Da.Fill(DM);
                label9.Text = DM.Rows[5][1].ToString() + " $";
                label14.Text = DM.Rows[2][1].ToString() + " $";
                label12.Text = DM.Rows[3][1].ToString() + " $";
                label20.Text = DM.Rows[0][1].ToString() + " $";
                label16.Text = DM.Rows[1][1].ToString() + " $";
                label18.Text = DM.Rows[4][1].ToString() + " $";
                Jeurs = int.Parse(DM.Rows[0][6].ToString());
                bunifuTextbox2.text = Jeurs.ToString();
            }catch(Exception ex) { }
            finally
            {
                cn.Close();
            }
            
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bunifuImageButton1.Visible = false;
            DT.Clear();
            cmd = new SqlCommand("Select * From  client Where typeC = 'KRT'", cn);
            Da = new SqlDataAdapter(cmd);
            Da.Fill(DT);
            DT.Columns.Remove("Image");
            DT.Columns.Remove("DateP");
            DT.Columns.Remove("Prix");
            this.dataGridView1.DataSource = DT;
            bunifuTextbox6.text = "";
            sup();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bunifuImageButton1.Visible = false;
            DT.Clear();
            cmd = new SqlCommand("Select * From  client Where typeC = 'KIK'", cn);
            Da = new SqlDataAdapter(cmd);
            Da.Fill(DT);
            DT.Columns.Remove("Image");
            DT.Columns.Remove("DateP");
            DT.Columns.Remove("Prix");
            this.dataGridView1.DataSource = DT;
            bunifuTextbox6.text = "";
            sup();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            bunifuImageButton1.Visible = false;
            DT.Clear();
            cmd = new SqlCommand("Select * From  client Where typeC = 'MUS'", cn);
            Da = new SqlDataAdapter(cmd);
            Da.Fill(DT);
            DT.Columns.Remove("Image");
            DT.Columns.Remove("DateP");
            DT.Columns.Remove("Prix");
            this.dataGridView1.DataSource = DT;
            bunifuTextbox6.text = "";
            sup();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            bunifuImageButton1.Visible = false;
            DT.Clear();
            cmd = new SqlCommand("Select * From  client Where typeC = 'KONGF'", cn);
            Da = new SqlDataAdapter(cmd);
            Da.Fill(DT);
            DT.Columns.Remove("Image");
            DT.Columns.Remove("DateP");
            DT.Columns.Remove("Prix");
            this.dataGridView1.DataSource = DT;
            bunifuTextbox6.text = "";
            sup();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            bunifuImageButton1.Visible = false;
            DT.Clear();
            cmd = new SqlCommand("Select * From  client Where typeC = 'TYK'", cn);
            Da = new SqlDataAdapter(cmd);
            Da.Fill(DT);
            DT.Columns.Remove("Image");
            DT.Columns.Remove("DateP");
            DT.Columns.Remove("Prix");
            this.dataGridView1.DataSource = DT;
            bunifuTextbox6.text = "";
            sup();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            bunifuImageButton1.Visible = false;
            DT.Clear();
            cmd = new SqlCommand("Select * From  client Where typeC = 'JUDO'", cn);
            Da = new SqlDataAdapter(cmd);
            Da.Fill(DT);
            DT.Columns.Remove("Image");
            DT.Columns.Remove("DateP");
            DT.Columns.Remove("Prix");
            this.dataGridView1.DataSource = DT;
            bunifuTextbox6.text = "";
            sup();
        }

        private void bunifuCalendar1_onValueChanged(object sender, EventArgs e)
        {
          
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton8_Click(object sender, EventArgs e)
        {     
            if (prix == false)
                bunifuImageButton1.Visible = true;
            else bunifuImageButton1.Visible = false;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string PRX = "true";
                bunifuCalendar1.Value = DateTime.Now;
                if (radioButton1.Checked == true)
                    cmd = new SqlCommand("Update client Set DateP ='" + bunifuCalendar1.Value + "', Prix = " + PRX + " where CIN = '" + label8.Text + "' and typeC = 'KRT'", cn);


                if (radioButton2.Checked == true)
                    cmd = new SqlCommand("Update client Set DateP ='" + bunifuCalendar1.Value + "', Prix = " + PRX + " where CIN = '" + label8.Text + "' and typeC = 'KIK'", cn);

                if (radioButton3.Checked == true)
                    cmd = new SqlCommand("Update client Set DateP ='" + bunifuCalendar1.Value + "', Prix = " + PRX + " where CIN = '" + label8.Text + "' and typeC = 'MUS'", cn);

                if (radioButton4.Checked == true)
                    cmd = new SqlCommand("Update client Set DateP ='" + bunifuCalendar1.Value + "', Prix = " + PRX + " where CIN = '" + label8.Text + "' and typeC = 'KONGF'", cn);

                if (radioButton5.Checked == true)
                    cmd = new SqlCommand("Update client Set DateP ='" + bunifuCalendar1.Value + "', Prix = " + PRX + " where CIN = '" + label8.Text + "' and typeC = 'TYK'", cn);

                if (radioButton6.Checked == true)
                    cmd = new SqlCommand("Update client Set DateP ='" + bunifuCalendar1.Value + "', Prix = " + PRX + " where CIN = '" + label8.Text + "' and typeC = 'JUDO'", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                bunifuImageButton1.Visible = false;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void GNR_MouseDown(object sender, MouseEventArgs e)
        {
            PZ = 1;
            posX = e.X;
            posY = e.Y;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuSwitch1_Click(object sender, EventArgs e)
        {
            if (bunifuSwitch1.Value == true)
            {
                visible();
            }
            else  NOvisible(); 
        }


        void NOvisible()
        {
            panel1.Visible = true;
            bunifuSwitch2.Value = true;
            label25.Visible = true;
            groupBox1.Visible = false; groupBox2.Visible = false; dataGridView1.Visible = false;
            label11.Visible = false; bunifuTextbox6.Visible = false; 
        }
        void visible()
        {
            panel1.Visible = false;
            bunifuSwitch2.Value = false;
            label25.Visible = false;
            groupBox1.Visible = true; groupBox2.Visible = true; dataGridView1.Visible = true;
            label11.Visible = true; bunifuTextbox6.Visible = true; 
        }

        private void bunifuSwitch2_Click(object sender, EventArgs e)
        {
            if (bunifuSwitch2.Value==true)
            {
                bunifuSwitch1.Value = false;
                NOvisible();
            }
            else
            {
                bunifuSwitch1.Value = true;
                visible();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bunifuTextbox1.text == "") MessageBox.Show("There is no value");
            else
            {
                try
                {
                    if (comboBox1.Text == "Karaté")
                        cmd = new SqlCommand("Update MONEY Set Prix =" + bunifuTextbox1._TextBox.Text + " where typeC = 'KRT'", cn);

                    if (comboBox1.Text == "Kick boxing")
                        cmd = new SqlCommand("Update MONEY Set Prix =" + bunifuTextbox1._TextBox.Text + " where typeC = 'KIK'", cn);

                    if (comboBox1.Text == "Musculation")
                        cmd = new SqlCommand("Update MONEY Set Prix =" + bunifuTextbox1._TextBox.Text + " where typeC = 'MUS'", cn);

                    if (comboBox1.Text == "Kong Fu")
                        cmd = new SqlCommand("Update MONEY Set Prix =" + bunifuTextbox1._TextBox.Text + " where typeC = 'KONGF'", cn);

                    if (comboBox1.Text == "Tykoando")
                        cmd = new SqlCommand("Update MONEY Set Prix =" + bunifuTextbox1._TextBox.Text + " where typeC = 'TYK'", cn);

                    if (comboBox1.Text == "Judo")
                        cmd = new SqlCommand("Update MONEY Set Prix =" + bunifuTextbox1._TextBox.Text + " where typeC = 'JUDO'", cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally
                {
                    cn.Close();
                }
                PRIX();
                comboBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bunifuTextbox2._TextBox.Text == "") MessageBox.Show("There is no value");
            else
            {
                try
                {
                    cmd = new SqlCommand("Update MONEY Set JR ='" + bunifuTextbox2._TextBox.Text + "'", cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally
                {
                    cn.Close();
                }
                PRIX();
            }
        }

        private void GNR_MouseUp(object sender, MouseEventArgs e)
        {
            PZ = 0;
        }

        private void bunifuTextbox2_OnTextChange(object sender, EventArgs e)
        {
            char[] nomLetters = bunifuTextbox2.text.ToCharArray();

            foreach (char letter in nomLetters)
            {
                if (letter < 48 || letter > 57)
                {
                    bunifuTextbox1.text = "";
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label25.Text = DateTime.Now.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }
        static void start()
        {
            Application.Run(new Form2());
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
                Thread THR = new Thread(start);
                THR.SetApartmentState(ApartmentState.STA);
                THR.Start();

                this.Close();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            timer4.Start();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            char[] nomLetters = bunifuTextbox1.text.ToCharArray();

            foreach (char letter in nomLetters)
            {
                if (letter < 48 || letter > 57)
                {
                    bunifuTextbox1.text = "";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label26.Left--;
            if (label26.Left < -800)
                label26.Left = 880;
        }

        private void GNR_MouseMove(object sender, MouseEventArgs e)
        {
            if (PZ == 1)
            {
                this.SetDesktopLocation(MousePosition.X - posX, MousePosition.Y - posY);
            }
        }
        void ReturnPRIX()
        {
            try
            {
                string PRXF = "false";

                if (radioButton1.Checked == true)
                    cmd = new SqlCommand("Update client Set Prix = " + PRXF + " where CIN = '" + label8.Text + "' and typeC = 'KRT'", cn);

                if (radioButton2.Checked == true)
                    cmd = new SqlCommand("Update client Set Prix = " + PRXF + " where CIN = '" + label8.Text + "' and typeC = 'KIK'", cn);

                if (radioButton3.Checked == true)
                    cmd = new SqlCommand("Update client Set Prix = " + PRXF + " where CIN = '" + label8.Text + "' and typeC = 'MUS'", cn);

                if (radioButton4.Checked == true)
                    cmd = new SqlCommand("Update client Set Prix = " + PRXF + " where CIN = '" + label8.Text + "' and typeC = 'KONGF'", cn);

                if (radioButton5.Checked == true)
                    cmd = new SqlCommand("Update client Set Prix = " + PRXF + " where CIN = '" + label8.Text + "' and typeC = 'TYK'", cn);

                if (radioButton6.Checked == true)
                    cmd = new SqlCommand("Update client Set Prix = " + PRXF + " where CIN = '" + label8.Text + "' and typeC = 'JUDO'", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            radioButton9.Checked = true;
            radioButton8.Checked = false;
        }
       
    }
}
