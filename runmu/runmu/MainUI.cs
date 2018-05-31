﻿using runmu.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace runmu
{
    public partial class Form1 : Form
    {
        IUnityContainer container;
        public static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Form1));

        public Form1(IUnityContainer container)
        {
            this.container = container;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitTeachers()
        {

        }
        private void InitCourses()
        {




            //notifyIcon1.ShowBalloonTip(1000, "噢不提醒你", "有人快到期啦", ToolTipIcon.Warning);
        }


        private void TeacherMgmt_Click(object sender, EventArgs e)
        {
            InfoMgmt teacher = new InfoMgmt(container.Resolve<TeacherService>())
            {
                Text = "教师管理",
                Name = "teacher"
            };
            teacher.ShowDialog();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void CourseMgmt_Click(object sender, EventArgs e)
        {
            InfoMgmt course = new InfoMgmt(container.Resolve<CourseService>())
            {
                Text = "课程管理",
                Name = "course"
            };
            course.ShowDialog();
        }
    }
}
