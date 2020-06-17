using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
  
namespace Project
{
    public partial class Form1 : Form
    {
        string imgLoc = "";
        SqlCommand command;
        SqlConnection CON = new SqlConnection(@"Data Source=AIDYNULY\SQLEXPRESS;Initial Catalog=Corolla;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Medicine0". При необходимости она может быть перемещена или удалена.
            this.medicine0TableAdapter.Fill(this.corollaDataSet1.Medicine0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Payment0". При необходимости она может быть перемещена или удалена.
            this.payment0TableAdapter.Fill(this.corollaDataSet1.Payment0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Customer0". При необходимости она может быть перемещена или удалена.
            this.customer0TableAdapter.Fill(this.corollaDataSet1.Customer0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Visiting0". При необходимости она может быть перемещена или удалена.
            this.visiting0TableAdapter.Fill(this.corollaDataSet1.Visiting0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.City0". При необходимости она может быть перемещена или удалена.
            this.city0TableAdapter.Fill(this.corollaDataSet1.City0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Country0". При необходимости она может быть перемещена или удалена.
            this.country0TableAdapter.Fill(this.corollaDataSet1.Country0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Employee0". При необходимости она может быть перемещена или удалена.
            this.employee0TableAdapter.Fill(this.corollaDataSet1.Employee0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Availibility0". При необходимости она может быть перемещена или удалена.
            this.availibility0TableAdapter.Fill(this.corollaDataSet1.Availibility0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Pharmacy0". При необходимости она может быть перемещена или удалена.
            this.pharmacy0TableAdapter.Fill(this.corollaDataSet1.Pharmacy0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Pharmacy0". При необходимости она может быть перемещена или удалена.
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView6.Sort(dataGridView6.Columns[3], ListSortDirection.Ascending);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView6.Sort(dataGridView6.Columns[0], ListSortDirection.Ascending);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pharmasy openForm = new Pharmasy();
            openForm.Show();
            Visible = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        DataSet ds = new DataSet();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Medicine0 where drugtype like'" + radioButton1.Text + "%'", CON);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView10.DataSource = data;
        }

        private void dataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            SqlDataAdapter sda = new SqlDataAdapter("select * from Medicine0 where drugtype like'" + radioButton2.Text + "%'", CON);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView10.DataSource = data;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Medicine0 where drugtype like'" + radioButton3.Text + "%'", CON);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView10.DataSource = data;
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select city_id,pharmacy_id,name,pharmaddress,photo from Pharmacy0 where pharmacy_id=" + textBox2.Text + "";
                if (CON.State != ConnectionState.Open)
                    CON.Open();

                command = new SqlCommand(sql, CON);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    textBox2.Text = reader[1].ToString();
                    textBox3.Text = reader[2].ToString();
                    textBox4.Text = reader[3].ToString();
                    byte[] img = (byte[])(reader[4]);
                    if (img == null)
                        pictureBox1 = null;
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    pictureBox1.Image = null;
                    MessageBox.Show("This id doesn't exist");
                }
                CON.Close();
            }
            catch (Exception ex)
            {
                CON.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string sql = "INSERT INTO Pharmacy0 (city_id,pharmacy_id,name,pharmaddress,photo)VALUES(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" +  textBox4.Text + "',@img)";
                if (CON.State != ConnectionState.Open)
                    CON.Open();
                command = new SqlCommand(sql, CON);
                command.Parameters.Add(new SqlParameter("@img", img));
                int x = command.ExecuteNonQuery();
                CON.Close();
                MessageBox.Show(x.ToString() + " record(s) saved. ");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                pictureBox1.Image = null;

            }
            catch (Exception ex)
            {
                CON.Close();
                MessageBox.Show(ex.Message);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
         
        private void button8_Click(object sender, EventArgs e)
        {
            try {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                dlg.Title = "Select Pharmacy0 Picture";
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgLoc;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
