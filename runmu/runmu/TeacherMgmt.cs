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
    public partial class TeacherMgmt : Form
    {
        private IService service;
        public TeacherMgmt(IUnityContainer container)
        {
            this.service = container.Resolve<TeacherService>();
            InitializeComponent();
        }

        private void TeacherUI_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();

                    DataTable table = service.GetAll(conn);
                    FormCommon.InitDataContainer(dataContainer, table);

                    dataContainer.DataSource = table;
                }
                catch (Exception error)
                {
                    FormCommon.HandleException(error);
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("你确定？", "噢不!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();

                    service.Update(conn, (DataTable)dataContainer.DataSource);
                    RefreshData(conn);
                }
                catch (Exception error)
                {
                    FormCommon.HandleException(error);
                }
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = dataContainer.SelectedRows;

            if (selected.Count == 0)
            {
                MessageBox.Show("弄啥咧，你没有选中任何列！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            List<int> ids = new List<int>();

            foreach (DataGridViewRow row in selected)
            {
                int id = Convert.ToInt32(row.Cells["ID"].Value);
                ids.Add(id);
            }
            DialogResult dialogResult = MessageBox.Show("你确定要删除这些数据吗？", "噢不!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("弄啥咧，你没有输入名字！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }


            if (!Regex.IsMatch(txtQQ.Text, @"^\d{0,11}$"))
            {
                MessageBox.Show("请输入人类的QQ！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (MessageBox.Show("你确定？", "噢不！", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            Args[] paras = new Args[]
            {
                new Args( AttributeName.NAME, txtName.Text.Trim()),
                new Args( AttributeName.QQ,txtQQ.Text ),
                new Args(AttributeName.Alias,txtAlias.Text),
                new Args(AttributeName.Email,txtEmail.Text),

            };


            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();

                    service.Add(conn, paras);
                    RefreshData(conn);
                    MessageBox.Show("厉害喽！ 居然成功了！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    FormCommon.HandleException(error);
                }
            }


        }
        private void RefreshData(SQLiteConnection conn)
        {
            dataContainer.DataSource = null;
            DataTable source = service.GetAll(conn);
            dataContainer.DataSource = source;
        }
    }
}
