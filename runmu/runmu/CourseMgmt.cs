using runmu.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            DataTable teachers = teacherService.GetAll();
            cmbTeacher.DataSource = teachers;
            cmbTeacher.ValueMember = "ID";
            cmbTeacher.DisplayMember = "姓名";
            teacherNames = new Dictionary<string, int>();

            foreach (DataRow row in teachers.Rows)
            {
                teacherNames.Add(row["姓名"].ToString(), Convert.ToInt32(row["ID"]));
            }

            DataTable courses = courseService.GetAll();

            FormCommon.InitDataContainer(dataContainer, courses);

            dataContainer.DataSource = courses;
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

            Model model = new Model
            {
                Name = txtCourse.Text.Trim(),
                TeacherId = Convert.ToInt32(cmbTeacher.SelectedValue),
                Price = price
            };

            courseService.Add(model);
            MessageBox.Show("厉害喽！ 居然成功了！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshData();

        }

        private void RefreshData()
        {
            DataTable table = courseService.GetAll();

            dataContainer.DataSource = table;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable source = (DataTable)dataContainer.DataSource;
            courseService.Update(source);
            RefreshData();
        }
    }
}
