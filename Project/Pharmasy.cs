using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Pharmasy : Form
    {
        public Pharmasy()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Form1 openForm = new Form1();
            openForm.Show();
            Visible = false;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Employee openForm = new Employee();
            openForm.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
        
    }
}
