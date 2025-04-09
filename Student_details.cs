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
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Student_details : Form
    {
        SqlConnection con;
        SqlCommand cmd;

        public Student_details()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (studentidtxt.Text == "" || studentnametxt.Text == "" || dateTimePicker1.Text == "" || mobilenotxt.Text == "" || txtmail.Text == "")
            {
                MessageBox.Show("Please Enter Value In The Field", "Blank-Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                cmd = new SqlCommand("select studid from StudInformation where studid='" + Convert.ToInt16(studentidtxt.Text) + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Enter Id Is Already Exits", "All-Ready Exits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    studentidtxt.Clear();
                    studentidtxt.Focus();
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    cmd = new SqlCommand("insert into StudInformation values('" + Convert.ToInt16(studentidtxt.Text) + "','" + studentnametxt.Text + "','" + dateTimePicker1.Text + "','" + (radioButton1.Checked == true ? "Male" : "Female") + "','" + mobilenotxt.Text + "','" + txtmail.Text + "')", con);
                    int res = cmd.ExecuteNonQuery();


                    if (res > 0)
                    {
                        MessageBox.Show("Insert Record in the database", "Insert-Recored", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getData();
                        studentidtxt.Text = "";
                        studentnametxt.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        mobilenotxt.Text = "";
                        txtmail.Text = "";
                        studentidtxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Error In Insert Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Student_details_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SMS;Integrated Security=True;Encrypt=False");
            con.Open();
            getData();
        }

        public void getData()
        {
            cmd = new SqlCommand("select * from StudInformation", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mobilenotxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                cmd = new SqlCommand("select studid,studnm,dob,gender,phone,email from StudInformation where studid='" + id + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    studentidtxt.Text = dr.GetValue(0).ToString(); ;
                    studentnametxt.Text = dr.GetValue(1).ToString(); ;
                    dateTimePicker1.Text = dr.GetValue(2).ToString(); ;
                    if (dr.GetValue(3).ToString() == "Male")
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                    mobilenotxt.Text = dr.GetValue(4).ToString();
                    txtmail.Text = dr.GetValue(5).ToString();
                }
                dr.Close();
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult res = MessageBox.Show("Are You Sure Want To Delete Record", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (res == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    cmd = new SqlCommand("delete from StudInformation where studid='" + id + "' ", con);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Record Delete Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getData();
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
            int id = Convert.ToInt32(studentidtxt.Text); 
            cmd = new SqlCommand("update StudInformation set studnm='"+studentnametxt.Text+"', dob='"+dateTimePicker1.Text+"', gender='"+(radioButton1.Checked == true ? "male" : "female")+"', phone='"+mobilenotxt.Text+"', email='"+txtmail.Text+"' where studid='"+studentidtxt.Text+"' ",con);
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                MessageBox.Show("Record Update Successfully", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getData();
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
