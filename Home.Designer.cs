namespace WindowsFormsApp1
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.Rollno = new System.Windows.Forms.Button();
            this.Class = new System.Windows.Forms.Button();
            this.teacher = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.student = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.Rollno);
            this.panel2.Controls.Add(this.Class);
            this.panel2.Controls.Add(this.teacher);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.student);
            this.panel2.Location = new System.Drawing.Point(484, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 487);
            this.panel2.TabIndex = 1;
            // 
            // Rollno
            // 
            this.Rollno.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rollno.Location = new System.Drawing.Point(139, 345);
            this.Rollno.Name = "Rollno";
            this.Rollno.Size = new System.Drawing.Size(227, 36);
            this.Rollno.TabIndex = 4;
            this.Rollno.Text = "Roll No Details";
            this.Rollno.UseVisualStyleBackColor = true;
            this.Rollno.Click += new System.EventHandler(this.Grno_Click);
            // 
            // Class
            // 
            this.Class.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Class.Location = new System.Drawing.Point(139, 282);
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(227, 40);
            this.Class.TabIndex = 3;
            this.Class.Text = "Class Details";
            this.Class.UseVisualStyleBackColor = true;
            this.Class.Click += new System.EventHandler(this.Class_Click);
            // 
            // teacher
            // 
            this.teacher.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teacher.Location = new System.Drawing.Point(139, 214);
            this.teacher.Name = "teacher";
            this.teacher.Size = new System.Drawing.Size(227, 40);
            this.teacher.TabIndex = 2;
            this.teacher.Text = "Teacher Details";
            this.teacher.UseVisualStyleBackColor = true;
            this.teacher.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Sitka Text", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin Menu";
            // 
            // student
            // 
            this.student.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.student.Location = new System.Drawing.Point(139, 145);
            this.student.Name = "student";
            this.student.Size = new System.Drawing.Size(227, 39);
            this.student.TabIndex = 0;
            this.student.Text = "Student Details";
            this.student.UseVisualStyleBackColor = true;
            this.student.Click += new System.EventHandler(this.student_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.pexels_droosmo_2982449;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 487);
            this.panel1.TabIndex = 0;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 492);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Home";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button student;
        private System.Windows.Forms.Button teacher;
        private System.Windows.Forms.Button Class;
        private System.Windows.Forms.Button Rollno;
    }
}