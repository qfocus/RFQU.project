
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
        private IService platformService;
        private IService learnStatusService;
        private IService signService;
        private IService paymentService;
        private Dictionary<int, double> coursePrices;

        public SignUpMgmt(IUnityContainer container)
        {
            this.studentService = container.Resolve<StudentsService>();
            this.courseService = container.Resolve<CourseService>();
            this.assistantService = container.Resolve<AssistantService>();
            this.platformService = container.Resolve<PlatformService>();
            this.learnStatusService = container.Resolve<LearnStatusService>();
            this.signService = container.Resolve<SignUpService>();
            this.paymentService = container.Resolve<PaymentService>();
            InitializeComponent();
        }

        private void SignUpMgmt_Load(object sender, EventArgs e)
        {
            InitData();
            cmbPayment.SelectedIndex = 0;
        }

        private void InitData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();
                    DataTable courses = courseService.GetAll(conn);
                    Dictionary<int, string> courseNames = new Dictionary<int, string>();
                    coursePrices = new Dictionary<int, double>();

                    foreach (DataRow row in courses.Rows)
                    {
                        int id = Convert.ToInt32(row[0]);
                        string name = row[1].ToString();
                        double price = Convert.ToDouble(row[3]);
                        courseNames.Add(id, name);
                        coursePrices.Add(id, price);
                    }

                    FormCommon.BindComboxDataSource(courseNames, cmbCourse);

                    Dictionary<int, string> assistant = assistantService.GetNames(conn);
                    FormCommon.BindComboxDataSource(assistant, cmbAssistant);

                    Dictionary<int, string> platforms = platformService.GetNames(conn);
                    FormCommon.BindComboxDataSource(platforms, cmbPlatform);

                    Dictionary<int, string> status = learnStatusService.GetNames(conn);
                    FormCommon.BindComboxDataSource(status, cmbStatus);

                    DataTable source = signService.GetAll(conn);
                    FormCommon.InitDataContainer(dataContainer, source);
                    dataContainer.DataSource = source;

                    //lblPrice.Text = coursePrices[1].ToString();


                }
                catch (Exception error)
                {
                    FormCommon.HandleException(error);
                    this.Dispose();
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
                    DataTable table = studentService.Query(conn, new Args(AttributeName.ID, txtQQ.Text.Trim()));

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("该学员不存在！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        lblName.Text = "";
                        return;
                    }
                    lblName.Text = table.Rows[0]["姓名"].ToString();

                }
                catch (Exception error)
                {
                    FormCommon.HandleException(error);
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblName.Text))
            {
                MessageBox.Show("先有学员才有报名！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            int period = 0;
            double downPayment = 0;
            if (cmbPayment.SelectedIndex != 0)
            {
                if (!int.TryParse(txtPeriod.Text, out period) || period < 1)
                {
                    MessageBox.Show("你想分几期？！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                if (!double.TryParse(txtDownPayment.Text, out downPayment) || downPayment < 0)
                {
                    MessageBox.Show("你想不花钱？！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
            }

            DateTime signDate = dtpSignup.Value;
            string signDateString = signDate.ToString(Constants.SHORT_DATE_FORMAT);
            long signDateTimestamp = Common.GetTimeStamp(signDate);
            string qq = txtQQ.Text.Trim();

            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                conn.Open();
                Args[] queryArgs = new Args[]
                {
                    new Args(AttributeName.CourseID, cmbCourse.SelectedValue),
                    new Args(AttributeName.StudentID, qq)
                };

                DataTable signed = signService.Query(conn, queryArgs);
                if (signed.Rows.Count > 0)
                {
                    MessageBox.Show("他已经报过这门课程了！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                if (MessageBox.Show("你确定？", "噢不！", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }

                signed = signService.Query(conn, queryArgs[1]);

                bool hasSigned = false;

                DateTime start = signDate;
                int length = 1;
                if (signed.Rows.Count > 0)
                {
                    foreach (DataRow row in signed.Rows)
                    {
                        DateTime temp = DateTime.Parse(row[4].ToString());
                        if (start > temp)
                        {
                            start = temp;
                        }
                    }
                    length = Math.Min(signed.Rows.Count + 1, 4);
                    hasSigned = true;
                }

                DateTime end = start.AddYears(length).AddDays(1);
                long expire = Common.GetTimeStamp(end);
                Args[] insertParams = new Args[]
                {
                    new Args( AttributeName.CourseID, cmbCourse.SelectedValue ),
                    new Args( AttributeName.StudentID, qq ),
                    new Args( AttributeName.AssistantID, cmbAssistant.SelectedValue ),
                    new Args( AttributeName.PlatformID, cmbPlatform.SelectedValue ),
                    new Args( AttributeName.SignDate, signDateString ),
                    new Args( AttributeName.SignTimestamp,signDateTimestamp),
                    new Args( AttributeName.StatusID, 1 ),
                    new Args( AttributeName.PayType, cmbPayment.SelectedItem ),
                    new Args( AttributeName.ExpireDate, end.ToString(Constants.SHORT_DATE_FORMAT)),
                    new Args( AttributeName.Expire,expire)
                };

                SQLiteTransaction transaction = conn.BeginTransaction();

                try
                {
                    signService.Add(conn, insertParams);
                    //更新指导期
                    if (hasSigned)
                    {
                        List<Args> attributes = new List<Args>
                        {
                            new Args( AttributeName.ExpireDate,end.ToString(Constants.SHORT_DATE_FORMAT)),
                            new Args( AttributeName.Expire,expire)
                        };

                        signService.Update(conn, attributes, new Args(AttributeName.StudentID, qq));
                    }

                    AddPayment(conn, qq, period, downPayment);

                    transaction.Commit();

                    RefreshData(conn);
                    MessageBox.Show("厉害喽！ 居然成功了！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    transaction.Rollback();
                    FormCommon.HandleException(error);
                }
            }
        }

        private void AddPayment(SQLiteConnection conn, string qq, int period, double downPayment)
        {
            DateTime signDate = dtpSignup.Value;
            double price = coursePrices[Convert.ToInt32(cmbCourse.SelectedValue)];
            // full pay
            if (cmbPayment.SelectedIndex == 0)
            {
                Args[] args = new Args[]{
                  new Args(AttributeName.CourseID, cmbCourse.SelectedValue ),
                  new Args(AttributeName.StudentID, qq ),
                  new Args(AttributeName.PayType,Constants.FULL ),
                  new Args(AttributeName.Status, Constants.PAID ),
                  new Args(AttributeName.Values, price),
                  new Args(AttributeName.PayDate,signDate.ToString(Constants.SHORT_DATE_FORMAT)),
                  new Args(AttributeName.Expire,Common.GetTimeStamp(signDate))};
                paymentService.Add(conn, args);
                return;
            }

            double rest = price - downPayment;
            double eachPrice = rest / period;

            List<Args> paymentParas = new List<Args>();

            for (int i = 0; i <= period; i++)
            {
                paymentParas.Add(new Args(AttributeName.CourseID, cmbCourse.SelectedValue));
                paymentParas.Add(new Args(AttributeName.StudentID, qq));
                if (i == 0)
                {
                    paymentParas.Add(new Args(AttributeName.PayType, Constants.DOWN_PAYMENT));
                    paymentParas.Add(new Args(AttributeName.Values, downPayment));
                    paymentParas.Add(new Args(AttributeName.Status, Constants.PAID));
                    paymentParas.Add(new Args(AttributeName.PayDate, signDate.ToString(Constants.SHORT_DATE_FORMAT)));
                    paymentParas.Add(new Args(AttributeName.Expire, Common.GetTimeStamp(signDate)));
                    paymentService.Add(conn, paymentParas.ToArray());
                    paymentParas.Clear();
                    continue;
                }

                if (i == 1)
                {
                    paymentParas.Add(new Args(AttributeName.Status, Constants.PAID));
                    paymentParas.Add(new Args(AttributeName.PayDate, signDate.ToString(Constants.SHORT_DATE_FORMAT)));
                    paymentParas.Add(new Args(AttributeName.Expire, Common.GetTimeStamp(signDate)));
                }
                else
                {
                    DateTime periodDate = signDate.AddMonths(i - 1);
                    paymentParas.Add(new Args(AttributeName.Status, Constants.UNPAID));
                    paymentParas.Add(new Args(AttributeName.PayDate, periodDate.ToString(Constants.SHORT_DATE_FORMAT)));
                    paymentParas.Add(new Args(AttributeName.Expire, Common.GetTimeStamp(periodDate)));
                }

                paymentParas.Add(new Args(AttributeName.Values, eachPrice));
                paymentParas.Add(new Args(AttributeName.PayType, string.Format(Constants.NO_, i)));

                paymentService.Add(conn, paymentParas.ToArray());
                paymentParas.Clear();
            }

        }



        private void Payment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayment.SelectedIndex == 0)
            {
                gpPayment.Visible = false;
                return;
            }
            gpPayment.Visible = true;
        }

        private void RefreshData(SQLiteConnection conn)
        {
            DataTable table = signService.GetAll(conn);

            dataContainer.DataSource = table;

        }

        private void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourse.SelectedValue is int)
            {
                int id = Convert.ToInt32(cmbCourse.SelectedValue);

                lblPrice.Text = coursePrices[id].ToString();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

        }
    }
}
