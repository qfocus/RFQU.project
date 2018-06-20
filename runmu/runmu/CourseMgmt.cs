using runmu.Business;
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
    public partial class CourseMgmt : Form
    {
        private Service teacherService;
        private Service courseService;
        private Dictionary<String, int> teacherNames;

        public CourseMgmt(IUnityContainer container)
        {
            teacherService = container.Resolve<TeacherService>();
            courseService = container.Resolve<CourseService>();
            InitializeComponent();
        }


        private void CourseMgmt_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();

                    DataTable teachers = teacherService.GetAll(conn);
                    cmbTeacher.DataSource = teachers;
                    cmbTeacher.ValueMember = "ID";
                    cmbTeacher.DisplayMember = "姓名";
                    teacherNames = new Dictionary<string, int>();

                    foreach (DataRow row in teachers.Rows)
                    {
                        teacherNames.Add(row["姓名"].ToString(), Convert.ToInt32(row["ID"]));
                    }

                    DataTable courses = courseService.GetAll(conn);

                    FormCommon.InitDataContainer(dataContainer, courses);

                    dataContainer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dataContainer.AutoGenerateColumns = false;

                    dataContainer.DataSource = courses;
                }
                catch (Exception error)
                {
                    FormCommon.HandleError(error);
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourse.Text))
            {
                MessageBox.Show("弄啥咧，你没有输入课程！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("课程免费嘛？！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (!double.TryParse(txtPrice.Text, out double price))
            {
                MessageBox.Show("不要乱搞课程价格！！ ", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (MessageBox.Show("你确定？", "噢不！", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            Dictionary<string, object> paras = new Dictionary<string, object>
            {
                { PropertyName.NAME, txtCourse.Text.Trim() },
                { PropertyName.Price, price },
                { PropertyName.TeacherID, cmbTeacher.SelectedValue }
            };


            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();
                    courseService.Add(conn, paras);

                    MessageBox.Show("厉害喽！ 居然成功了！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData(conn);
                }
                catch (Exception error)
                {
                    FormCommon.HandleError(error);
                }
            }

        }

        private void RefreshData(SQLiteConnection conn)
        {
            DataTable table = courseService.GetAll(conn);

            dataContainer.DataSource = table;

        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();
                    DataTable source = (DataTable)dataContainer.DataSource;
                    courseService.Update(conn, source);
                    RefreshData(conn);

                    MessageBox.Show("厉害喽！ 居然成功了！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception error)
                {
                    FormCommon.HandleError(error);
                }
            }
        }
    }
}
