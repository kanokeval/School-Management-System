﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher_details Teacher = new Teacher_details();
            Teacher.Show();
            this.Hide();
        }

        private void student_Click(object sender, EventArgs e)
        {
            Student_details student = new Student_details();
            student.Show();
            this.Hide();
        }

        private void Class_Click(object sender, EventArgs e)
        {
            Class_details c1 = new Class_details();
            c1.Show();
            this.Hide();
        }

        private void Grno_Click(object sender, EventArgs e)
        {
            Rollno_details gr = new Rollno_details();
            gr.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
