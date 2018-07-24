namespace runmu
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxTeacher = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbCourse = new System.Windows.Forms.CheckedListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.添加信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teacherMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPlatform = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAssistant = new System.Windows.Forms.ToolStripMenuItem();
            this.courseMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.signUpMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dateMgmt = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(602, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(12, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(940, 474);
            this.dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "课程 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "学员 :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(222, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "学费花费(¥) :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(418, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(64, 20);
            this.textBox2.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(485, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "--";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(504, 23);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(62, 20);
            this.textBox3.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "指导期剩余 (天):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "教师 :";
            // 
            // cbxTeacher
            // 
            this.cbxTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTeacher.FormattingEnabled = true;
            this.cbxTeacher.Location = new System.Drawing.Point(222, 23);
            this.cbxTeacher.Name = "cbxTeacher";
            this.cbxTeacher.Size = new System.Drawing.Size(88, 21);
            this.cbxTeacher.TabIndex = 16;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(503, 55);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(62, 20);
            this.textBox4.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(484, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "--";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(417, 55);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(64, 20);
            this.textBox5.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(602, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(877, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "系统设置";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(521, 113);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "导出";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(849, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "报警值 :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbCourse);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbxTeacher);
            this.groupBox1.Location = new System.Drawing.Point(11, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 142);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // clbCourse
            // 
            this.clbCourse.FormattingEnabled = true;
            this.clbCourse.Location = new System.Drawing.Point(48, 20);
            this.clbCourse.Name = "clbCourse";
            this.clbCourse.Size = new System.Drawing.Size(120, 94);
            this.clbCourse.TabIndex = 25;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(222, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(88, 21);
            this.comboBox1.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(179, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "缴费 :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(912, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "30 (天) ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加信息ToolStripMenuItem,
            this.系统设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(964, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 添加信息ToolStripMenuItem
            // 
            this.添加信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teacherMgmt,
            this.studentsMgmt,
            this.tsmPlatform,
            this.tsmAssistant,
            this.courseMgmt,
            this.signUpMgmt,
            this.paymentMgmt,
            this.dateMgmt});
            this.添加信息ToolStripMenuItem.Name = "添加信息ToolStripMenuItem";
            this.添加信息ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.添加信息ToolStripMenuItem.Text = "信息管理";
            // 
            // teacherMgmt
            // 
            this.teacherMgmt.AutoSize = false;
            this.teacherMgmt.Name = "teacherMgmt";
            this.teacherMgmt.Size = new System.Drawing.Size(180, 22);
            this.teacherMgmt.Text = "教师管理";
            this.teacherMgmt.Click += new System.EventHandler(this.TeacherMgmt_Click);
            // 
            // studentsMgmt
            // 
            this.studentsMgmt.Name = "studentsMgmt";
            this.studentsMgmt.Size = new System.Drawing.Size(180, 22);
            this.studentsMgmt.Text = "学员管理";
            this.studentsMgmt.Click += new System.EventHandler(this.StudentsMgmt_Click);
            // 
            // tsmPlatform
            // 
            this.tsmPlatform.Name = "tsmPlatform";
            this.tsmPlatform.Size = new System.Drawing.Size(180, 22);
            this.tsmPlatform.Text = "平台管理";
            this.tsmPlatform.Click += new System.EventHandler(this.TsmPlatform_Click);
            // 
            // tsmAssistant
            // 
            this.tsmAssistant.Name = "tsmAssistant";
            this.tsmAssistant.Size = new System.Drawing.Size(180, 22);
            this.tsmAssistant.Text = "助理管理";
            this.tsmAssistant.Click += new System.EventHandler(this.TsmAssistant_Click);
            // 
            // courseMgmt
            // 
            this.courseMgmt.Name = "courseMgmt";
            this.courseMgmt.Size = new System.Drawing.Size(180, 22);
            this.courseMgmt.Text = "课程管理";
            this.courseMgmt.Click += new System.EventHandler(this.CourseMgmt_Click);
            // 
            // signUpMgmt
            // 
            this.signUpMgmt.Name = "signUpMgmt";
            this.signUpMgmt.Size = new System.Drawing.Size(180, 22);
            this.signUpMgmt.Text = "报名管理";
            this.signUpMgmt.Click += new System.EventHandler(this.SignUpMgmt_Click);
            // 
            // paymentMgmt
            // 
            this.paymentMgmt.Name = "paymentMgmt";
            this.paymentMgmt.Size = new System.Drawing.Size(180, 22);
            this.paymentMgmt.Text = "学费管理";
            this.paymentMgmt.Click += new System.EventHandler(this.PaymentMgmt_Click);
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmStudent});
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // tsmStudent
            // 
            this.tsmStudent.Name = "tsmStudent";
            this.tsmStudent.Size = new System.Drawing.Size(122, 22);
            this.tsmStudent.Text = "导入数据";
            this.tsmStudent.Click += new System.EventHandler(this.Import_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFile";
            // 
            // dateMgmt
            // 
            this.dateMgmt.Name = "dateMgmt";
            this.dateMgmt.Size = new System.Drawing.Size(180, 22);
            this.dateMgmt.Text = "指导期管理";
            this.dateMgmt.Click += new System.EventHandler(this.dateMgmt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 664);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "小仙女专用 v1.0  by 噢不";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxTeacher;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teacherMgmt;
        private System.Windows.Forms.ToolStripMenuItem courseMgmt;
        private System.Windows.Forms.ToolStripMenuItem studentsMgmt;
        private System.Windows.Forms.ToolStripMenuItem signUpMgmt;
        private System.Windows.Forms.CheckedListBox clbCourse;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmStudent;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem tsmAssistant;
        private System.Windows.Forms.ToolStripMenuItem tsmPlatform;
        private System.Windows.Forms.ToolStripMenuItem paymentMgmt;
        private System.Windows.Forms.ToolStripMenuItem dateMgmt;
    }
}

