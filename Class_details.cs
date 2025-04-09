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

namespace WindowsFormsApp1
{
    public partial class Class_details : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Class_details()
        {
            InitializeComponent();
        }

        private void Class_details_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SMS;Integrated Security=True;Encrypt=False");
            con.Open();
            getdata();
            LoadDataCB();
        }

        public void getdata()
        {
            cmd = new SqlCommand("select * from StudInformation", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        public void LoadDataCB()
        {
            cmd = new SqlCommand("select studid,studnm from StudInformation", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            idcomboBox1.DataSource = dt;
            idcomboBox1.DisplayMember = "studid";
            idcomboBox1.ValueMember = "studnm";
            nmcomboBox1.DataSource = dt;
            nmcomboBox1.DisplayMember = "studnm";
            nmcomboBox1.ValueMember = "studid";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (idcomboBox1.Text == "" || nmcomboBox1.Text == "")
            {
                MessageBox.Show("Please Enter Value In The Field", "Blank-Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cmd = new SqlCommand("select classid from ClassInfo where classid='" + idcomboBox1.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Enter Id Is Already Exits", "All-Ready Exits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    idcomboBox1.Focus();
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    cmd = new SqlCommand("insert into ClassInfo values('" + idcomboBox1.Text + "','" + nmcomboBox1.Text + "','" + classcomboBox1.Text + "')", con);
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Insert Record In The Database", "Inser-Recored", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getdata();
                        idcomboBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Error In Insert Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                cmd = new SqlCommand("select classid,classnnm,class from ClassInfo where classid='" + id + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idcomboBox1.Text = dr.GetValue(0).ToString();
                    nmcomboBox1.Text = dr.GetValue(1).ToString();
                    classcomboBox1.Text = dr.GetValue(2).ToString();
                }
                dr.Close();
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult res = MessageBox.Show("Are You Sure Want To Delete Record", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    cmd = new SqlCommand("delete from ClassInfo where classid='" + id + "' ", con);
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
            cmd = new SqlCommand("update ClassInfo set classnnm='" + nmcomboBox1.Text + "',class='" + classcomboBox1.Text + "' where classid='" + idcomboBox1.Text + "' ", con);
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
