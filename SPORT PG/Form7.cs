using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SPORT_PG
{
    public partial class Form7 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Sportif-client;Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable DT = new DataTable();

        int PZ, posX, posY, position;

        public Form7()
        {
            InitializeComponent();
            FilleDatagredview();
            bunifuTextbox1._TextBox.Multiline = false;
            bunifuTextbox2._TextBox.Multiline = false;
            bunifuTextbox3._TextBox.Multiline = false;
            bunifuTextbox4._TextBox.Multiline = false;
            bunifuTextbox5._TextBox.Multiline = false;
            bunifuTextbox6._TextBox.Multiline = false;
        }
        void FilleDatagredview()
        {
            DT.Clear();
            cmd = new SqlCommand("Select * From  client Where typeC = 'TYK'", cn);
            Da = new SqlDataAdapter(cmd);
            Da.Fill(DT);
            DT.Columns.Remove("Image");
            DT.Columns.Remove("DateP");
            DT.Columns.Remove("Prix");
            this.dataGridView1.DataSource = DT;
            bunifuTextbox6.text = "";
        }
        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        static void start()
        {
            Application.Run(new Form2());
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

        private void Form7_MouseDown(object sender, MouseEventArgs e)
        {
            PZ = 1;
            posX = e.X;
            posY = e.Y;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label14.Visible == true) label14.Visible = false;
            else label14.Visible = true;

            Random rnd = new Random();
            int one = rnd.Next(0, 255);
            int two = rnd.Next(0, 255);
            int tree = rnd.Next(0, 255);
            int four = rnd.Next(0, 255);
            label7.ForeColor = Color.FromArgb(two, four, one, tree);
            label10.ForeColor = Color.FromArgb(two, one, four, tree);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSwitch1_Click(object sender, EventArgs e)
        {
            if (bunifuSwitch1.Value == true)
            {
                label11.Visible = true;
                label9.Visible = true;
                bunifuTextbox6.Visible = true;
                dataGridView1.Visible = true;
                panel2.Visible = false;
            }

            else
            {
                label11.Visible = false;
                label9.Visible = false;
                bunifuTextbox6.Visible = false;
                bunifuTextbox6.text = "";
                dataGridView1.Visible = false;
                panel2.Visible = true;
            }
        }

        private void bunifuTextbox6_OnTextChange(object sender, EventArgs e)
        {
            if (bunifuTextbox6.text != "") label11.Visible = false;
            else label11.Visible = true;
            Search();
            image();
            bunifuTextbox1.text = ""; bunifuTextbox2.text = ""; bunifuTextbox3.text = "";
            bunifuTextbox4.text = ""; bunifuTextbox5.text = ""; bunifuCalendar1.Value = DateTime.Now;
            pictureBox9.Image = null;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            bunifuTextbox6.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Insertclint", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@CIN", SqlDbType.NVarChar, 20);
                param[0].Value = bunifuTextbox1.text;
                param[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                param[1].Value = bunifuTextbox2.text;
                param[2] = new SqlParameter("@Age", SqlDbType.Int);
                param[2].Value = bunifuTextbox3.text;
                param[3] = new SqlParameter("@Tel", SqlDbType.NVarChar, 30);
                param[3].Value = bunifuTextbox4.text;
                param[4] = new SqlParameter("@Add", SqlDbType.NVarChar, 70);
                param[4].Value = bunifuTextbox5.text;
                param[5] = new SqlParameter("@DateD", SqlDbType.DateTime);
                param[5].Value = bunifuCalendar1.Value;

                param[7] = new SqlParameter("@typeC", SqlDbType.NVarChar);
                param[7].Value = "TYK";



                if (pictureBox9.Image == null || bunifuTextbox1.text == "" || bunifuTextbox2.text == "" || bunifuTextbox3.text == "" ||
                    bunifuTextbox4.text == "" || bunifuTextbox5.text == "")
                    MessageBox.Show("Information is not enough", "ErrorAdd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    param[6] = new SqlParameter("@image", SqlDbType.Image);
                    MemoryStream ms = new MemoryStream();
                    pictureBox9.Image.Save(ms, pictureBox9.Image.RawFormat);
                    byte[] picture = ms.ToArray();
                    param[6].Value = picture;
                    cmd.Parameters.AddRange(param);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Add Susseccfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FilleDatagredview();
                    bunifuTextbox1.text = ""; bunifuTextbox2.text = ""; bunifuTextbox3.text = "";
                    bunifuTextbox4.text = ""; bunifuTextbox5.text = ""; bunifuCalendar1.Value = DateTime.Now;
                    pictureBox9.Image = null;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Deleteclint", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@CIN", SqlDbType.NVarChar, 20);
                param.Value = bunifuTextbox1.text;
                cmd.Parameters.Add(param);
                if (bunifuTextbox1.text != "")
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    FilleDatagredview();
                    MessageBox.Show("Delete Susseccfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuTextbox1.text = ""; bunifuTextbox2.text = ""; bunifuTextbox3.text = "";
                    bunifuTextbox4.text = ""; bunifuTextbox5.text = ""; bunifuCalendar1.Value = DateTime.Now;
                    pictureBox9.Image = null;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FilleDatagredview();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilleDatagredview();
            bunifuTextbox1.text = ""; bunifuTextbox2.text = ""; bunifuTextbox3.text = "";
            bunifuTextbox4.text = ""; bunifuTextbox5.text = ""; bunifuCalendar1.Value = DateTime.Now;
            pictureBox9.Image = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Edit", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@CIN", SqlDbType.NVarChar, 20);
                param[0].Value = bunifuTextbox1.text;
                param[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                param[1].Value = bunifuTextbox2.text;
                param[2] = new SqlParameter("@Age", SqlDbType.Int);
                param[2].Value = bunifuTextbox3.text;
                param[3] = new SqlParameter("@Tel", SqlDbType.NVarChar, 30);
                param[3].Value = bunifuTextbox4.text;
                param[4] = new SqlParameter("@Add", SqlDbType.NVarChar, 70);
                param[4].Value = bunifuTextbox5.text;
                param[5] = new SqlParameter("@DateD", SqlDbType.DateTime);
                param[5].Value = bunifuCalendar1.Value;


                param[7] = new SqlParameter("@typeC", SqlDbType.NVarChar);
                param[7].Value = "TYK";

                if (pictureBox9.Image == null || bunifuTextbox1.text == "" || bunifuTextbox2.text == "" || bunifuTextbox3.text == "" ||
                    bunifuTextbox4.text == "" || bunifuTextbox5.text == "")
                    MessageBox.Show("Information is not enough", "Error Edit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    param[6] = new SqlParameter("@image", SqlDbType.Image);
                    MemoryStream ms = new MemoryStream();
                    pictureBox9.Image.Save(ms, pictureBox9.Image.RawFormat);
                    byte[] picture = ms.ToArray();
                    param[6].Value = picture;
                    cmd.Parameters.AddRange(param);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    FilleDatagredview();
                    MessageBox.Show("Edit Susseccfully", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuTextbox1.text = ""; bunifuTextbox2.text = ""; bunifuTextbox3.text = "";
                    bunifuTextbox4.text = ""; bunifuTextbox5.text = ""; bunifuCalendar1.Value = DateTime.Now;
                    pictureBox9.Image = null;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FilleDatagredview();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int pos = dataGridView1.CurrentRow.Index;
                bunifuTextbox1.text = dataGridView1.CurrentRow.Cells["CIN"].Value.ToString();
                bunifuTextbox2.text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                bunifuTextbox3.text = dataGridView1.CurrentRow.Cells["Age"].Value.ToString();
                bunifuTextbox4.text = dataGridView1.CurrentRow.Cells["Tel"].Value.ToString();
                bunifuTextbox5.text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
                DateTime myDate = DateTime.Parse(dataGridView1.CurrentRow.Cells["JoinDate"].Value.ToString());
                bunifuCalendar1.Value = myDate;
                image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Form7_MouseUp(object sender, MouseEventArgs e)
        {
            PZ = 0;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FilleDatagredview();
            position = 0;
            PreSuiV();
            label12.Text = position + 1 + "/" + dataGridView1.Rows.Count;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FilleDatagredview();
            if (position == 0) position = dataGridView1.Rows.Count - 1;
            else position--;
            PreSuiV();
            label12.Text = position + 1 + "/" + dataGridView1.Rows.Count;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FilleDatagredview();
            if (position == dataGridView1.Rows.Count - 1) position = 0;
            else position++;
            PreSuiV();
            label12.Text = position + 1 + "/" + dataGridView1.Rows.Count;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FilleDatagredview();
            position = dataGridView1.Rows.Count - 1;
            PreSuiV();
            label12.Text = position + 1 + "/" + dataGridView1.Rows.Count;
        }

        private void bunifuTextbox3_OnTextChange(object sender, EventArgs e)
        {
            char[] nomLetters = bunifuTextbox3.text.ToCharArray();

            foreach (char letter in nomLetters)
            {
                if (letter < 48 || letter > 57)
                {
                    bunifuTextbox3.text = "";
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuCalendar1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox5_OnTextChange(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox4_OnTextChange(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox2_OnTextChange(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images Files |*.JPG; *.PNG; *.GPEG; *.GPE; *.GPF";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox9.Image = Image.FromFile(openFileDialog1.FileName);
            }
            else
            {
                pictureBox9.Image = null;
                label13.Visible = true;
            }
        }

        private void Form7_MouseMove(object sender, MouseEventArgs e)
        {
            if (PZ == 1)
            {
                this.SetDesktopLocation(MousePosition.X - posX, MousePosition.Y - posY);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        void Search()
        {
            try
            {
                DT.Clear();
                Da = new SqlDataAdapter("select * From client Where Name like '%" + bunifuTextbox6.text + "%' and typeC = 'TYK'", cn);
                Da.Fill(DT);
                DT.Columns.Remove("Image");
                DT.Columns.Remove("DateP");
                DT.Columns.Remove("Prix");
                this.dataGridView1.DataSource = DT;
            }
            catch (Exception ex) { }
        }
        void PreSuiV()
        {
            try
            {
                bunifuTextbox1.text = dataGridView1.Rows[position].Cells["CIN"].Value.ToString();
                bunifuTextbox2.text = dataGridView1.Rows[position].Cells["Name"].Value.ToString();
                bunifuTextbox3.text = dataGridView1.Rows[position].Cells["Age"].Value.ToString();
                bunifuTextbox4.text = dataGridView1.Rows[position].Cells["Tel"].Value.ToString();
                bunifuTextbox5.text = dataGridView1.Rows[position].Cells["Address"].Value.ToString();
                DateTime myDate = DateTime.Parse(dataGridView1.Rows[position].Cells["JoinDate"].Value.ToString());
                bunifuCalendar1.Value = myDate;

                image();
            }
            catch (Exception ex) { }
        }
        void image()
        {
            cmd = new SqlCommand("select * From client Where CIN like '%" + bunifuTextbox1.text + "%' and typeC = 'TYK'", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            try
            {
                if (!(dr[6] == DBNull.Value))
                {
                    MemoryStream ms = new MemoryStream((byte[])dr.GetValue(6));
                    pictureBox9.Image = Image.FromStream(ms);
                    dr.Close();
                    cn.Close();
                    label13.Visible = false;
                }
                else
                {
                    pictureBox9.Image = null;
                    label13.Visible = true;
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                dr.Close();
                cn.Close();
            }
        }
    }
}
