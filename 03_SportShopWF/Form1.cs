using _04_data_access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_SportShopWF
{
    public partial class Form1 : Form
    {
        string conn = @"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                            Initial Catalog=SportShop;
                            Integrated Security=True;
                            Connect Timeout=2;";
        public Form1()
        {
            SportShopDb db = new SportShopDb(conn);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Ite
        }
    }
}
