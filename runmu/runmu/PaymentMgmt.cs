using runmu.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace runmu
{
    public partial class PaymentMgmt : Form
    {
        private IService service;
        private IService courseService;

        public PaymentMgmt(IUnityContainer container)
        {
            this.service = container.Resolve<PaymentService>();
            this.courseService = container.Resolve<CourseService>();
            InitializeComponent();
        }

        private void PaymentMgmt_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();
                    DataTable source = service.GetAll(conn);
                    FormCommon.InitDataContainer(dataContainer, source);
                    DataGridViewButtonColumn column = new DataGridViewButtonColumn();
                    column.HeaderText = "更新";
                    column.Text = "更新";
                    column.Visible = true;
                    column.UseColumnTextForButtonValue = true;
                    this.dataContainer.Columns.Add(column);


                    this.dataContainer.DataSource = source;


                    Dictionary<int, string> courses = courseService.GetNames(conn);
                    FormCommon.BindComboxDataSource(courses, cmbCourses, true);
                    ChangeStatus();
                }
                catch (Exception ex)
                {
                    FormCommon.HandleException(ex);
                }
            }
        }


        private void RefreshData(SQLiteConnection conn)
        {
            DataTable table = service.GetAll(conn);

            dataContainer.DataSource = table;
            ChangeStatus();
        }

        private void Query_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();
                    Dictionary<string, object> paras = new Dictionary<string, object>();
                    Args args = null;
                    if (!string.IsNullOrWhiteSpace(txtQQ.Text))
                    {
                        args = new Args(AttributeName.StudentID, txtQQ.Text.Trim());
                    }
                    if (cmbCourses.SelectedIndex != 0)
                    {
                        args = new Args(AttributeName.CourseID, cmbCourses.SelectedValue);
                    }

                    DataTable result = service.Query(conn, args);

                    dataContainer.DataSource = result;
                    ChangeStatus();

                }
                catch (Exception ex)
                {
                    FormCommon.HandleException(ex);
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {

        }

        private void ChangeStatus()
        {
            foreach (DataGridViewRow row in dataContainer.Rows)
            {
                if (Constants.PAID.Equals(row.Cells[6].Value))
                {
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#8E8E8E");
                }

            }
        }

        private void Container_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex <= 0)
            {
                return;
            }

            if (Constants.PAID.Equals(senderGrid.Rows[e.RowIndex].Cells[6].Value))
            {
                return;
            }
            if (MessageBox.Show("你确定？", "噢不！", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            List<Args> attributes = new List<Args>
            {
               new Args(AttributeName.Status,Constants.PAID)
            };

            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();
                    service.Update(conn, attributes, new Args(AttributeName.ID, senderGrid.Rows[e.RowIndex].Cells[0].Value));
                    RefreshData(conn);
                    MessageBox.Show("厉害喽！ 居然成功了！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    FormCommon.HandleException(ex);
                }
            }
        }

        private void dataContainer_Sorted(object sender, EventArgs e)
        {
            ChangeStatus();
        }
    }
}
