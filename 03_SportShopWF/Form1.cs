using _04_data_access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_SportShopWF
{
    public partial class Form1 : Form
    {
       
        //SportShopDb db;
        private SqlConnection con = null;
        private SqlDataAdapter da = null;
        private DataSet set = null;
        public Form1()
        {
            //db = new SportShopDb(conn);
            InitializeComponent();
            dataGridView1.Size = new Size(2600, 2600);
            string cs = ConfigurationManager.ConnectionStrings["SportShopDb"].ConnectionString;
            con = new SqlConnection(cs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.GetAll();
            //Fill
            try
            {
                string sql = textBox1.Text;
                da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);

                set = new DataSet();
                da.Fill(set,"MyTable");

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = set.Tables["MyTable"];

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(set, "MyTable");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
