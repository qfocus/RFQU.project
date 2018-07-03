
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

                    lblPrice.Text = coursePrices[1].ToString();


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
                    DataTable table = studentService.Query(conn, new Dictionary<string, object>()
                    { { AttributeName.ID, txtQQ.Text.Trim() }
                    });

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("该学员不存在！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        lblName.Text = "";
                        return;
                    }
                    lblName.Text = table.Rows[0]["name"].ToString();

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
            string qq = txtQQ.Text.Trim();

            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                conn.Open();
                Dictionary<string, object> queryArgs = new Dictionary<string, object>
                {
                    { AttributeName.CourseID, cmbCourse.SelectedValue },
                    { AttributeName.StudentID, qq }
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

                queryArgs.Remove(AttributeName.CourseID);

                signed = signService.Query(conn, queryArgs);

                bool hasSigned = false;

                DateTime start = signDate;
                int length = 1;
                if (signed.Rows.Count > 0)
                {
                    foreach (DataRow row in signed.Rows)
                    {
                        DateTime temp = DateTime.Parse(row[1].ToString());
                        if (start > temp)
                        {
                            start = temp;
                        }
                    }
                    length = Math.Min(signed.Rows.Count + 1, 4);
                    hasSigned = true;
                }

                DateTime end = start.AddYears(length).AddDays(1);
                Dictionary<string, object> insertParams = new Dictionary<string, object>
                {
                    { AttributeName.CourseID, cmbCourse.SelectedValue },
                    { AttributeName.StudentID, qq },
                    { AttributeName.AssistantID, cmbAssistant.SelectedValue },
                    { AttributeName.PlatformID, cmbPlatform.SelectedValue },
                    { AttributeName.SignDate, signDateString },
                    { AttributeName.LearnStatus, 1 },
                    { AttributeName.PayType, cmbPayment.SelectedItem },
                    { AttributeName.EndDate, end.ToString(Constants.SHORT_DATE_FORMAT)},
                    { AttributeName.EndDateTicks,end.Ticks}
                };

                SQLiteTransaction transaction = conn.BeginTransaction();

                try
                {
                    signService.Add(conn, insertParams);
                    //更新指导期
                    if (hasSigned)
                    {
                        List<string> conditions = new List<string>
                        {
                            AttributeName.StudentID
                        };

                        List<string> attributes = new List<string>
                        {
                            AttributeName.EndDate,
                            AttributeName.EndDateTicks
                        };

                        Dictionary<string, object> updateParams = new Dictionary<string, object>
                        {
                            { AttributeName.EndDate, end.ToString(Constants.SHORT_DATE_FORMAT) },
                            { AttributeName.StudentID, qq },
                            { AttributeName.EndDateTicks,end.Ticks}
                        };

                        signService.Update(conn, attributes, conditions, updateParams);
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
                Dictionary<string, object> args = new Dictionary<string, object>
                        {
                            { AttributeName.CourseID, cmbCourse.SelectedValue },
                            { AttributeName.StudentID, qq },
                            { AttributeName.PayType,Constants.FULL },
                            { AttributeName.Status, Constants.PAID },
                            { AttributeName.Values, price},
                            { AttributeName.PayDate,signDate.ToString(Constants.SHORT_DATE_FORMAT)},
                            { AttributeName.EndDate, signDate.Ticks}
                        };
                paymentService.Add(conn, args);
                return;
            }

            double rest = price - downPayment;
            double eachPrice = rest / period;

            Dictionary<string, object> paymentParas = new Dictionary<string, object>();

            for (int i = 0; i <= period; i++)
            {
                paymentParas.Add(AttributeName.CourseID, cmbCourse.SelectedValue);
                paymentParas.Add(AttributeName.StudentID, qq);
                if (i == 0)
                {
                    paymentParas.Add(AttributeName.PayType, Constants.DOWN_PAYMENT);
                    paymentParas.Add(AttributeName.Values, downPayment);
                    paymentParas.Add(AttributeName.Status, Constants.PAID);
                    paymentParas.Add(AttributeName.PayDate, signDate.ToString(Constants.SHORT_DATE_FORMAT));
                    paymentParas.Add(AttributeName.EndDate, signDate.Ticks);
                    paymentService.Add(conn, paymentParas);
                    paymentParas.Clear();
                    continue;
                }

                if (i == 1)
                {
                    paymentParas.Add(AttributeName.Status, Constants.PAID);
                    paymentParas.Add(AttributeName.PayDate, signDate.ToString(Constants.SHORT_DATE_FORMAT));
                    paymentParas.Add(AttributeName.EndDate, signDate.Ticks);
                }
                else
                {
                    DateTime periodDate = signDate.AddMonths(i - 1);
                    paymentParas.Add(AttributeName.Status, Constants.UNPAID);
                    paymentParas.Add(AttributeName.PayDate, periodDate.ToString(Constants.SHORT_DATE_FORMAT));
                    paymentParas.Add(AttributeName.EndDate, periodDate.Ticks);
                }

                paymentParas.Add(AttributeName.Values, eachPrice);
                paymentParas.Add(AttributeName.PayType, string.Format(Constants.NO_, i));

                paymentService.Add(conn, paymentParas);
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
