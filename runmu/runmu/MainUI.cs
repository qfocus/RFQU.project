using runmu.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace runmu
{
    public partial class Form1 : Form
    {
        IUnityContainer container;
        StudentsService studentsService;


        public Form1(IUnityContainer container)
        {
            this.container = container;
            studentsService = container.Resolve<StudentsService>();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initailizer.Init();
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
            TeacherMgmt teacher = new TeacherMgmt(container);

            teacher.ShowDialog();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void CourseMgmt_Click(object sender, EventArgs e)
        {
            CourseMgmt course = new CourseMgmt(container);

            course.ShowDialog();
        }

        private void StudentsMgmt_Click(object sender, EventArgs e)
        {
            StudentsMgmt students = new StudentsMgmt(container);
            students.ShowDialog();
        }

        private void SignUpMgmt_Click(object sender, EventArgs e)
        {
            SignUpMgmt sign = new SignUpMgmt(container);
            sign.ShowDialog();
        }

        private void Import_Click(object sender, EventArgs e)
        {
            string name = OpenCsvFile();

            if (name == null)
            {
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                conn.Open();
                SQLiteTransaction transaction = conn.BeginTransaction();
                try
                {
                    Importer.ImportFullPaymentStudents(studentsService, conn, name);

                    transaction.Commit();

                    DataTable originalStudents = studentsService.GetAll(conn);

                    Dictionary<int, int> students = new Dictionary<int, int>();

                    foreach (DataRow row in originalStudents.Rows)
                    {

                    }


                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    transaction.Rollback();
                    MessageBox.Show("出问题了，快去找大师兄！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
        }

        private string OpenCsvFile()
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return null;
            }
            string name = openFileDialog1.FileName;

            if (!File.Exists(name))
            {
                MessageBox.Show("文件找不到了！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return null;
            }

            if (!".csv".Equals(Path.GetExtension(name), StringComparison.CurrentCultureIgnoreCase))
            {
                MessageBox.Show("CSV！CSV！CSV！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return null;
            }

            return name;
        }

        private void TsmPlatform_Click(object sender, EventArgs e)
        {
            PlatformMgmt platform = new PlatformMgmt(container);
            platform.ShowDialog();
        }

        private void TsmAssistant_Click(object sender, EventArgs e)
        {
            AssistantMgmt assistant = new AssistantMgmt(container);
            assistant.ShowDialog();
        }
    }

}
