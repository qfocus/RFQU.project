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
            this.dataContainer = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbPayment = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSignEnd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSignStart = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDaysEnd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDaysStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clbStatus = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clbAssistant = new System.Windows.Forms.CheckedListBox();
            this.clbCourse = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtQQ = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.添加信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teacherMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPlatform = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAssistant = new System.Windows.Forms.ToolStripMenuItem();
            this.courseMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.signUpMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.dateMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblExpireDays = new System.Windows.Forms.Label();
            this.lblPaymentDays = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataContainer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataContainer
            // 
            this.dataContainer.AllowUserToAddRows = false;
            this.dataContainer.AllowUserToDeleteRows = false;
            this.dataContainer.AllowUserToResizeRows = false;
            this.dataContainer.CausesValidation = false;
            this.dataContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataContainer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataContainer.Location = new System.Drawing.Point(12, 178);
            this.dataContainer.Name = "dataContainer";
            this.dataContainer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataContainer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataContainer.Size = new System.Drawing.Size(1129, 481);
            this.dataContainer.TabIndex = 1;
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
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(1049, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "系统设置";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPaymentDays);
            this.groupBox1.Controls.Add(this.lblExpireDays);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.clbPayment);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSignEnd);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSignStart);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDaysEnd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDaysStart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.clbStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.clbAssistant);
            this.groupBox1.Controls.Add(this.clbCourse);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.txtQQ);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(11, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1025, 142);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // clbPayment
            // 
            this.clbPayment.CheckOnClick = true;
            this.clbPayment.FormattingEnabled = true;
            this.clbPayment.Items.AddRange(new object[] {
            "全额",
            "分期"});
            this.clbPayment.Location = new System.Drawing.Point(403, 95);
            this.clbPayment.Name = "clbPayment";
            this.clbPayment.Size = new System.Drawing.Size(64, 34);
            this.clbPayment.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(336, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "付费类型 :";
            // 
            // txtSignEnd
            // 
            this.txtSignEnd.Location = new System.Drawing.Point(702, 24);
            this.txtSignEnd.Name = "txtSignEnd";
            this.txtSignEnd.Size = new System.Drawing.Size(88, 20);
            this.txtSignEnd.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(686, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "--";
            // 
            // txtSignStart
            // 
            this.txtSignStart.Location = new System.Drawing.Point(594, 24);
            this.txtSignStart.Name = "txtSignStart";
            this.txtSignStart.Size = new System.Drawing.Size(88, 20);
            this.txtSignStart.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(503, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 26);
            this.label8.TabIndex = 33;
            this.label8.Text = "报名日期\r\n(yyyy-mm-dd) :";
            // 
            // txtDaysEnd
            // 
            this.txtDaysEnd.Location = new System.Drawing.Point(703, 55);
            this.txtDaysEnd.Name = "txtDaysEnd";
            this.txtDaysEnd.Size = new System.Drawing.Size(88, 20);
            this.txtDaysEnd.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(687, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "--";
            // 
            // txtDaysStart
            // 
            this.txtDaysStart.Location = new System.Drawing.Point(595, 55);
            this.txtDaysStart.Name = "txtDaysStart";
            this.txtDaysStart.Size = new System.Drawing.Size(88, 20);
            this.txtDaysStart.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "指导期剩余(天) :";
            // 
            // clbStatus
            // 
            this.clbStatus.CheckOnClick = true;
            this.clbStatus.FormattingEnabled = true;
            this.clbStatus.Location = new System.Drawing.Point(403, 19);
            this.clbStatus.Name = "clbStatus";
            this.clbStatus.Size = new System.Drawing.Size(64, 64);
            this.clbStatus.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "学习状态 :";
            // 
            // clbAssistant
            // 
            this.clbAssistant.CheckOnClick = true;
            this.clbAssistant.FormattingEnabled = true;
            this.clbAssistant.Location = new System.Drawing.Point(220, 19);
            this.clbAssistant.Name = "clbAssistant";
            this.clbAssistant.Size = new System.Drawing.Size(93, 109);
            this.clbAssistant.TabIndex = 26;
            // 
            // clbCourse
            // 
            this.clbCourse.CheckOnClick = true;
            this.clbCourse.FormattingEnabled = true;
            this.clbCourse.Location = new System.Drawing.Point(48, 20);
            this.clbCourse.Name = "clbCourse";
            this.clbCourse.Size = new System.Drawing.Size(120, 109);
            this.clbCourse.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "学员QQ :";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(943, 113);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 22;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // txtQQ
            // 
            this.txtQQ.Location = new System.Drawing.Point(571, 88);
            this.txtQQ.Name = "txtQQ";
            this.txtQQ.Size = new System.Drawing.Size(107, 20);
            this.txtQQ.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(862, 113);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(781, 113);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.Query_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "助理 :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加信息ToolStripMenuItem,
            this.系统设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 24);
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
            this.studentsMgmt.Size = new System.Drawing.Size(122, 22);
            this.studentsMgmt.Text = "学员管理";
            this.studentsMgmt.Click += new System.EventHandler(this.StudentsMgmt_Click);
            // 
            // tsmPlatform
            // 
            this.tsmPlatform.Name = "tsmPlatform";
            this.tsmPlatform.Size = new System.Drawing.Size(122, 22);
            this.tsmPlatform.Text = "平台管理";
            this.tsmPlatform.Click += new System.EventHandler(this.TsmPlatform_Click);
            // 
            // tsmAssistant
            // 
            this.tsmAssistant.Name = "tsmAssistant";
            this.tsmAssistant.Size = new System.Drawing.Size(122, 22);
            this.tsmAssistant.Text = "助理管理";
            this.tsmAssistant.Click += new System.EventHandler(this.TsmAssistant_Click);
            // 
            // courseMgmt
            // 
            this.courseMgmt.Name = "courseMgmt";
            this.courseMgmt.Size = new System.Drawing.Size(122, 22);
            this.courseMgmt.Text = "课程管理";
            this.courseMgmt.Click += new System.EventHandler(this.CourseMgmt_Click);
            // 
            // signUpMgmt
            // 
            this.signUpMgmt.Name = "signUpMgmt";
            this.signUpMgmt.Size = new System.Drawing.Size(122, 22);
            this.signUpMgmt.Text = "报名管理";
            this.signUpMgmt.Click += new System.EventHandler(this.SignUpMgmt_Click);
            // 
            // paymentMgmt
            // 
            this.paymentMgmt.Name = "paymentMgmt";
            this.paymentMgmt.Size = new System.Drawing.Size(122, 22);
            this.paymentMgmt.Text = "学费管理";
            this.paymentMgmt.Click += new System.EventHandler(this.PaymentMgmt_Click);
            // 
            // dateMgmt
            // 
            this.dateMgmt.Name = "dateMgmt";
            this.dateMgmt.Size = new System.Drawing.Size(122, 22);
            this.dateMgmt.Text = "状态管理";
            this.dateMgmt.Click += new System.EventHandler(this.dateMgmt_Click);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(866, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "指导期提醒(天) :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(868, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "分期付款提醒(天) :";
            // 
            // lblExpireDays
            // 
            this.lblExpireDays.AutoSize = true;
            this.lblExpireDays.Location = new System.Drawing.Point(963, 16);
            this.lblExpireDays.Name = "lblExpireDays";
            this.lblExpireDays.Size = new System.Drawing.Size(13, 13);
            this.lblExpireDays.TabIndex = 41;
            this.lblExpireDays.Text = "0";
            // 
            // lblPaymentDays
            // 
            this.lblPaymentDays.AutoSize = true;
            this.lblPaymentDays.Location = new System.Drawing.Point(975, 45);
            this.lblPaymentDays.Name = "lblPaymentDays";
            this.lblPaymentDays.Size = new System.Drawing.Size(13, 13);
            this.lblPaymentDays.TabIndex = 42;
            this.lblPaymentDays.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 714);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataContainer);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataContainer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.CheckedListBox clbAssistant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtQQ;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDaysEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDaysStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSignEnd;
        private System.Windows.Forms.TextBox txtSignStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox clbPayment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblPaymentDays;
        private System.Windows.Forms.Label lblExpireDays;
    }
}

