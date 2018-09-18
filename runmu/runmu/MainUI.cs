using runmu.Business;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
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
        IService studentsService;
        IService courseService;
        IService teacherService;
        IService signUpService;
        IService paymentService;
        IService assistantService;
        IService statusService;
        Timer timer;

        private int interval = 1000 * 60 * 60;

        private Dictionary<string, int> courses;
        private Dictionary<string, int> assistants;
        private Dictionary<string, int> status;
        long expireDays;
        long paymentDays;

        public Form1(IUnityContainer container)
        {
            this.container = container;
            studentsService = container.Resolve<StudentsService>();
            courseService = container.Resolve<CourseService>();
            teacherService = container.Resolve<TeacherService>();
            signUpService = container.Resolve<SignUpService>();
            paymentService = container.Resolve<PaymentService>();
            assistantService = container.Resolve<AssistantService>();
            statusService = container.Resolve<LearnStatusService>();

            InitializeComponent();
            if (int.TryParse(ConfigurationManager.AppSettings["expireAlertDays"], out int a))
            {
                expireDays = a;
            }
            else
            {
                expireDays = 30;
            }
            if (int.TryParse(ConfigurationManager.AppSettings["paymentAlertDays"], out int b))
            {
                paymentDays = b;
            }
            else
            {
                paymentDays = 30;
            }
            lblExpireDays.Text = expireDays.ToString();
            lblPaymentDays.Text = paymentDays.ToString();

            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 5000;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            long expired = Common.GetTimeStamp(DateTime.Now.AddDays(expireDays));
            Args[] signArgs = new Args[] {
                new Args(AttributeName.Expire, "<=", expired) ,
                new Args(AttributeName.Status,1)};
            Args[] paymentArgs = new Args[] {
                new Args(AttributeName.Expire, "<=", Common.GetTimeStamp(DateTime.Now.AddDays(paymentDays))),
                new Args(AttributeName.Status, Constants.UNPAID)};

            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    DataTable signed = signUpService.Query(conn, signArgs);

                    if (signed.Rows.Count > 0)
                    {
                        if (signed.Rows[0][2] != null && !string.IsNullOrEmpty(signed.Rows[0][2].ToString()))
                        {
                            notifyIcon1.ShowBalloonTip(interval, "好消息！好消息！", signed.Rows[0][2].ToString() + "同学指导期快到啦！", ToolTipIcon.Warning);
                        }
                        else
                        {
                            notifyIcon1.ShowBalloonTip(interval, "好消息！好消息！", signed.Rows[0][3].ToString() + "同学指导期快到啦！", ToolTipIcon.Warning);
                        }
                    }

                    DataTable payments = paymentService.Query(conn, paymentArgs);

                    if (payments.Rows.Count > 0)
                    {
                        notifyIcon1.ShowBalloonTip(interval, "有人该充值了！", "嘿嘿嘿嘿", ToolTipIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    FormCommon.HandleException(ex);
                }
            }
        }

        private void Query_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
                {
                    conn.Open();
                    List<Args> queryArgs = new List<Args>();

                    if (clbCourse.CheckedItems.Count > 0)
                    {
                        List<int> ids = new List<int>();
                        for (int i = 0; i < clbCourse.CheckedItems.Count; i++)
                        {
                            ids.Add(courses[clbCourse.CheckedItems[i].ToString()]);
                        }
                        Args courseArgs = new Args(AttributeName.CourseID, "IN", ids);
                        queryArgs.Add(courseArgs);
                    }
                    if (clbAssistant.CheckedItems.Count > 0)
                    {
                        List<int> ids = new List<int>();
                        for (int i = 0; i < clbAssistant.CheckedItems.Count; i++)
                        {
                            ids.Add(assistants[clbAssistant.CheckedItems[i].ToString()]);
                        }
                        Args assistantArgs = new Args(AttributeName.AssistantID, "IN", ids);
                        queryArgs.Add(assistantArgs);
                    }
                    if (clbStatus.CheckedItems.Count > 0)
                    {
                        List<int> ids = new List<int>();
                        for (int i = 0; i < clbStatus.CheckedItems.Count; i++)
                        {
                            ids.Add(status[clbStatus.CheckedItems[i].ToString()]);
                        }
                        Args statusArgs = new Args(AttributeName.StatusID, "IN", ids);
                        queryArgs.Add(statusArgs);
                    }
                    if (clbPayment.CheckedItems.Count > 0)
                    {
                        List<string> ids = new List<string>();
                        for (int i = 0; i < clbPayment.CheckedItems.Count; i++)
                        {
                            ids.Add(clbPayment.CheckedItems[i].ToString());
                        }
                        Args payArgs = new Args(AttributeName.PayType, "IN", ids);
                        queryArgs.Add(payArgs);
                    }
                    if (!string.IsNullOrWhiteSpace(txtQQ.Text))
                    {
                        queryArgs.Add(new Args(AttributeName.StudentID, txtQQ.Text));
                    }
                    if (!string.IsNullOrWhiteSpace(txtSignStart.Text))
                    {
                        if (!DateTime.TryParse(txtSignStart.Text, out DateTime start))
                        {
                            MessageBox.Show("玩啥呢！ 日期不要乱搞！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return;
                        }
                        long stamp = Common.GetTimeStamp(start);
                        Args args = new Args(AttributeName.SignTimestamp, ">", stamp);
                        queryArgs.Add(args);
                    }
                    if (!string.IsNullOrWhiteSpace(txtSignEnd.Text))
                    {
                        if (!DateTime.TryParse(txtSignEnd.Text, out DateTime end))
                        {
                            MessageBox.Show("玩啥呢！ 日期不要乱搞！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return;
                        }
                        long stamp = Common.GetTimeStamp(end);
                        Args args = new Args(AttributeName.SignTimestamp, "<", stamp);
                        queryArgs.Add(args);
                    }
                    if (!string.IsNullOrWhiteSpace(txtDaysStart.Text))
                    {
                        if (!int.TryParse(txtDaysStart.Text, out int start))
                        {
                            MessageBox.Show("玩啥呢！ 天数不要乱搞！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return;
                        }

                        DateTime target = DateTime.Now.AddDays(start);
                        long timestamp = Common.GetTimeStamp(target);

                        Args args = new Args(AttributeName.Expire, ">", timestamp);
                        queryArgs.Add(args);
                    }
                    if (!string.IsNullOrWhiteSpace(txtDaysEnd.Text))
                    {
                        if (!int.TryParse(txtDaysEnd.Text, out int end))
                        {
                            MessageBox.Show("玩啥呢！ 天数不要乱搞！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return;
                        }

                        DateTime target = DateTime.Now.AddDays(end);
                        long timestamp = Common.GetTimeStamp(target);

                        Args args = new Args(AttributeName.Expire, "<", timestamp);
                        queryArgs.Add(args);
                    }

                    DataTable result = signUpService.MutiplyQuery(conn, queryArgs.ToArray());
                    dataContainer.DataSource = result;

                }
            }
            catch (Exception ex)
            {
                FormCommon.HandleException(ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initailizer.Init();
            InitConditions();
        }

        private void InitConditions()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                conn.Open();
                InitCourses(conn);
                InitAssistant(conn);
                InitStatus(conn);
            }
        }

        private void InitCourses(SQLiteConnection conn)
        {
            courses = new Dictionary<string, int>();

            DataTable table = courseService.GetAll(conn);

            foreach (DataRow item in table.Rows)
            {
                courses.Add(item[1].ToString(), int.Parse(item[0].ToString()));
                clbCourse.Items.Add(item[1]);
            }

        }

        private void InitAssistant(SQLiteConnection conn)
        {
            assistants = new Dictionary<string, int>();

            DataTable table = assistantService.GetAll(conn);

            foreach (DataRow item in table.Rows)
            {
                assistants.Add(item[1].ToString(), int.Parse(item[0].ToString()));
                clbAssistant.Items.Add(item[1]);
            }
        }
        private void InitStatus(SQLiteConnection conn)
        {
            status = new Dictionary<string, int>();

            DataTable table = statusService.GetAll(conn);

            foreach (DataRow item in table.Rows)
            {
                status.Add(item[1].ToString(), int.Parse(item[0].ToString()));
                clbStatus.Items.Add(item[1]);
            }
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

        private void Clear_Click(object sender, EventArgs e)
        {
            txtDaysStart.Text = string.Empty;
            txtDaysEnd.Text = string.Empty;
            txtDaysEnd.Text = string.Empty;
            txtDaysStart.Text = string.Empty;
            txtQQ.Text = string.Empty;
            for (int i = 0; i < clbCourse.Items.Count; i++)
            {
                clbCourse.SetItemChecked(i, false);
            }
            for (int i = 0; i < clbAssistant.Items.Count; i++)
            {
                clbAssistant.SetItemChecked(i, false);
            }
            for (int i = 0; i < clbStatus.Items.Count; i++)
            {
                clbStatus.SetItemChecked(i, false);
            }
            for (int i = 0; i < clbPayment.Items.Count; i++)
            {
                clbPayment.SetItemChecked(i, false);
            }
            dataContainer.DataSource = null;
        }
    }

}
