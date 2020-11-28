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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\surya\OneDrive\Documents\Master.mdf;Integrated Security = True; Connect Timeout = 30");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disp_data();

        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string LOGTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Sam_tStoreItemsDis values('" + textBox1.Text + "','" + textBox2.Text + "','"+ LOGTIME +"' )";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            clear();
            MessageBox.Show("Record inserted Successfully");

        }

        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        public void disp_data()

        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select  item,discount from Sam_tStoreItemsDis";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Sam_tStoreItemsDis where item = '" + textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            clear();
            MessageBox.Show("Record deleted Successfully");

        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Sam_tStoreItemsDis set discount ='"+textBox2.Text+"' where item = '"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            clear();
            MessageBox.Show("Record updated Successfully");
        }

     
    }
}
