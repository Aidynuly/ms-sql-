using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;

namespace Project
{
    public partial class Employee : Form
    {
        SqlConnection CON = new SqlConnection(@"Data Source=AIDYNULY\SQLEXPRESS;Initial Catalog=Corolla;Integrated Security=True");
        
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Position0". При необходимости она может быть перемещена или удалена.
            this.position0TableAdapter.Fill(this.corollaDataSet1.Position0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Visiting0". При необходимости она может быть перемещена или удалена.
            this.visiting0TableAdapter.Fill(this.corollaDataSet1.Visiting0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "corollaDataSet1.Employee0". При необходимости она может быть перемещена или удалена.
            this.employee0TableAdapter.Fill(this.corollaDataSet1.Employee0);

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pharmasy openForm = new Pharmasy();
            openForm.Show();
            Visible = false;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
            if(comboBox1.Text == "First Name")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Employee0 where firstname like'" + textBox1.Text + "%'", CON);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            }
            else if (comboBox1.Text == "Last Name")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Employee0 where lastname like'" + textBox1.Text + "%'",CON);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Position0 where position like '" + textBox2.Text + "%'", CON);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView3.DataSource = data;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("75800");
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
