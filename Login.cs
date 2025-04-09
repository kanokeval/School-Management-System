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
    public partial class Login : Form
    {
        SqlConnection con;
        SqlCommand cmd;

        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SMS;Integrated Security=True");
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = txtusername.Text;
            String password = txtpassword.Text;

            cmd = new SqlCommand("select * from AdminLogin where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Home h1 = new Home();
                h1.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Something Wrong!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtusername.ResetText();
                txtpassword.ResetText();
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
