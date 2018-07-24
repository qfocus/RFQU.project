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
    public partial class HibernateMgmt : Form
    {
        private IService signService;

        public HibernateMgmt(IUnityContainer container)
        {
            this.signService = container.Resolve<SignUpService>();
            InitializeComponent();
        }

        private void Query_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQQ.Text))
            {
                MessageBox.Show("名字呢！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            lblCurrent.Text = string.Empty;
            btnUpdate.Enabled = false;
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();


                    DataTable signed = signService.Query(conn, new Args(AttributeName.StudentID, txtQQ.Text.Trim()));
                    if (signed.Rows.Count == 0)
                    {
                        MessageBox.Show("没找到啊！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }
                    lblCurrent.Text = signed.Rows[0][2].ToString();
                    btnUpdate.Enabled = true;
                }
                catch (Exception ex)
                {
                    FormCommon.HandleException(ex);
                }
            }

        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定？", "噢不！", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            DateTime end = dateTimePicker1.Value;
            string endString = end.ToString(Constants.SHORT_DATE_FORMAT);
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                conn.Open();
                try
                {
                    List<Args> attributes = new List<Args>
                        {
                            new Args(AttributeName.ExpireDate,endString),
                            new Args(AttributeName.Expire,end.Ticks)
                        };

                    signService.Update(conn, attributes, new Args(AttributeName.StudentID, txtQQ.Text.Trim()));
                    MessageBox.Show("厉害喽！ 居然成功了！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblCurrent.Text = end.ToString(Constants.SHORT_DATE_FORMAT);
                }
                catch (Exception ex) { FormCommon.HandleException(ex); }
            }
        }
    }
}
