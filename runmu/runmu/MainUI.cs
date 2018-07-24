using runmu.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using Unity;

namespace runmu
{
    public partial class Form1 : Form
    {
        IUnityContainer container;
        StudentsService studentsService;
        CourseService courseService;
        TeacherService teacherService;
        Timer timer;
        public Form1(IUnityContainer container)
        {
            this.container = container;
            this.studentsService = container.Resolve<StudentsService>();
            this.courseService = container.Resolve<CourseService>();
            this.teacherService = container.Resolve<TeacherService>();

            InitializeComponent();

            this.timer = new Timer();
            this.timer.Tick += Timer_Tick;
            this.timer.Interval = 5000;
            this.timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            long expired = DateTime.Now.AddMonths(1).Ticks;
            Args args = new Args(AttributeName.Expire, "<=", expired);
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
                    Importer importer = new Importer();
                    importer.ImportFullPaymentStudents(studentsService, conn, name);
                    transaction.Commit();
                    Logger.Info("Import students successfully");

                    DataTable originalStudents = studentsService.GetAll(conn);

                    Dictionary<long, int> students = new Dictionary<long, int>();

                    foreach (DataRow row in originalStudents.Rows)
                    {
                        students.Add(Convert.ToInt64(row[2]), Convert.ToInt32(row[1]));
                    }


                }
                catch (Exception ex)
                {
                    FormCommon.HandleException(ex);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
        }

        private void PaymentMgmt_Click(object sender, EventArgs e)
        {
            PaymentMgmt payment = new PaymentMgmt(container);
            payment.ShowDialog();
        }

        private void dateMgmt_Click(object sender, EventArgs e)
        {
            HibernateMgmt payment = new HibernateMgmt(container);
            payment.ShowDialog();
        }
    }

}
