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
using static System.Collections.Specialized.BitVector32;

namespace WindowsFormsApp1
{
    public partial class Rollno_details : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Rollno_details()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int id = Convert.ToInt32(grnoGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                cmd = new SqlCommand("select rid,rnm,rclass,rdate from RollnoInfo where rid='" + id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    grnotxt.Text = dr.GetValue(0).ToString();
                    cbnm.Text = dr.GetValue(1).ToString();
                    grnotxt.Text = dr.GetValue(2).ToString();
                    dateTimePicker1.Text = dr.GetValue(3).ToString();
                }
                dr.Close();
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult res = MessageBox.Show("Are You Sure Want To Delete Record", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(grnoGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    cmd = new SqlCommand("delete from RollnoInfo where rid='" + id + "' ", con);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Record Delete Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getdata();
                    }
                    else
                    {
                        MessageBox.Show("Error In Delete Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Rollno_details_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SMS;Integrated Security=True;Encrypt=False");
            con.Open();
            getdata();
            LoadCBData();
        }

        public void getdata()
        {
            cmd = new SqlCommand("select * from RollnoInfo", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            grnoGridView1.DataSource = dt;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }
        public void LoadCBData()
        {
            cmd = new SqlCommand("select classnnm,class from ClassInfo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbnm.DataSource = dt;
            cbnm.DisplayMember = "classnnm";
            cbnm.ValueMember = "class";

            cbclass.DataSource = dt;
            cbclass.DisplayMember = "class";
            cbclass.ValueMember = "classnnm";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (grnotxt.Text == "" || cbnm.Text == "" || cbclass.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("Please Enter Value In The Field", "Blank-Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cmd = new SqlCommand("select rid from RollnoInfo where rid='" + grnotxt.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Enter Id Is Already Exits", "All-Ready Exits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    grnotxt.Clear();
                    grnotxt.Focus();
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    cmd = new SqlCommand("insert into RollnoInfo values('" + grnotxt.Text + "','" + cbnm.Text + "','" + cbclass.Text + "','" + dateTimePicker1.Text + "')", con);
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Insert Record In The Database", "Inser-Recored", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getdata();
                        grnotxt.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        grnotxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Error In Insert Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(grnotxt.Text);
            cmd = new SqlCommand("update RollnoInfo set rnm='" + cbnm.Text + "',rclass='" + cbclass.Text + "',rdate='" + dateTimePicker1.Text + "' where rid='" + id + "' ", con);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Record Update Successfully", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getdata();
            }
            else
            {
                MessageBox.Show("Error In Update Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();   
            Home home = new Home();
            home.Show();
        }
    }
}
