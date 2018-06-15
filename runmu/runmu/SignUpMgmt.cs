
using runmu.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unity;

namespace runmu
{
    public partial class SignUpMgmt : Form
    {
        private IService studentService;
        private IService courseService;
        private IService assistantService;


        public SignUpMgmt(IUnityContainer container)
        {
            studentService = container.Resolve<StudentsService>();
            courseService = container.Resolve<CourseService>();
            assistantService = container.Resolve<AssistantService>();
            InitializeComponent();
        }

        private void SignUpMgmt_Load(object sender, EventArgs e)
        {
            InitData();
        }



        private void InitData()
        {

            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();

                    DataTable courses = courseService.GetAll(conn);
                    cmbCourse.DataSource = courses;
                    cmbCourse.DisplayMember = "课程";
                    cmbCourse.ValueMember = "ID";
                    cmbPayment.SelectedIndex = 0;
                    DataTable assistant = assistantService.GetAll(conn);
                    cmbAssistant.DataSource = assistant;
                    cmbAssistant.DisplayMember = "name";
                    cmbAssistant.ValueMember = "id";
                }
                catch (Exception error)
                {
                    Logger.Error(error);
                    MessageBox.Show("出问题了，快去找大师兄！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
            }
        }

        private void QQ_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQQ.Text))
            {
                MessageBox.Show("QQ在哪里？？", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }


            if (!Regex.IsMatch(txtQQ.Text, @"^\d{0,11}$"))
            {
                MessageBox.Show("请输入人类的QQ！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }



            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();
                    DataTable table = studentService.Query(conn, txtQQ.Text);

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("该学员不存在！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }
                    lblName.Text = table.Rows[0]["name"].ToString();

                }
                catch (Exception exception)
                {
                    Logger.Error(exception);
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {

        }
    }
}
