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
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Teacher_details : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Teacher_details()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Teacher_details_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SMS;Integrated Security=True;Encrypt=False");
            con.Open();
            getdata();
        }

        public void getdata()
        {
            cmd = new SqlCommand("select * from TeacherInfo", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            teacherGridView1.DataSource = dt;
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (teacheridtxt.Text == " " || teachernametxt.Text == "" || teachercombo.Text == "")
            {
                MessageBox.Show("Please Enter Value In The Field", "Blank-Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cmd = new SqlCommand("select * from TeacherInfo where teacherid='" + Convert.ToInt16(teacheridtxt.Text) + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Enter Id Is Already Exits", "All-Ready Exits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    teacheridtxt.Clear();
                    teacheridtxt.Focus();
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    cmd = new SqlCommand("insert into TeacherInfo values('" + Convert.ToInt16(teacheridtxt.Text) + "','" + teachernametxt.Text + "','" + (radioButton1.Checked == true ? "Male" : "Female") + "','" + teachercombo.Text + "')", con);
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Insert Record In The Database", "Inser-Recored", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getdata();
                        teacheridtxt.Text = "";
                        teachernametxt.Text = "";
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        teachercombo.Text = "";
                        teacheridtxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Error In Insert Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void teacherGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int id = Convert.ToInt32(teacherGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                cmd = new SqlCommand("select teacherid,teachernm,subject,gender from TeacherInfo where teacherid='" + id + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    teacheridtxt.Text = dr.GetValue(0).ToString();
                    teachernametxt.Text = dr.GetValue(1).ToString();
                    teachercombo.Text = dr.GetValue(2).ToString();
                    if (dr.GetValue(3).ToString() == "Male")
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                }
                dr.Close();
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult res = MessageBox.Show("Are You Sure Want To Delete Record", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(teacherGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    cmd = new SqlCommand("delete from TeacherInfo where teacherid='" + id + "' ", con);
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(teacheridtxt.Text);
            cmd = new SqlCommand("update TeacherInfo set teachernm='" + teachernametxt.Text + "',subject='" + teachercombo.Text + "',gender='" + (radioButton1.Checked == true ? "Male" : "Female") + "' where teacherid='" + id + "' ", con);
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                MessageBox.Show("Record Update Successfully", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getdata();
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

