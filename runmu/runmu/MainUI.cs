using runmu.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace runmu
{
    public partial class Form1 : Form
    {
        public static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Form1));

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable table = new TeacherService().GetTeachers();

            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = table.Columns.Count;

            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (i == 0)
                {
                    dataGridView1.Columns[i].Visible = false;
                }

                dataGridView1.Columns[i].Name = table.Columns[i].ColumnName;
                dataGridView1.Columns[i].HeaderText = table.Columns[i].ColumnName;
                dataGridView1.Columns[i].DataPropertyName = table.Columns[i].ColumnName;
                //dataGridView1.Columns[i].Visible = false;
            }


            dataGridView1.DataSource = table;



            logger.Info("xxxxxxxxxx");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitTeachers();
            InitCourses();
        }

        private void InitTeachers()
        {
            DataTable table = new TeacherService().GetTeachers();
            table.Rows.InsertAt(table.NewRow(), 0);
            cbxTeacher.DataSource = table;
            cbxTeacher.DisplayMember = "name";
            cbxTeacher.ValueMember = "id";
        }
        private void InitCourses()
        {
            DataTable table = new CourseService().GetCourses();
            clbCourse.Items.Add(new Class1() { Name = "a", Id = "b" });         

        }

    }
}
