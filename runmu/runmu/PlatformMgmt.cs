using runmu.Business;
using System;
using System.Collections.Generic;
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
    public partial class PlatformMgmt : Form
    {
        private IService service;
        public PlatformMgmt(IUnityContainer container)
        {
            service = container.Resolve<PlatformService>();
            InitializeComponent();

        }

        private void PlatformMgmt_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();
                    DataTable source = service.GetAll(conn);
                    FormCommon.InitDataContainer(dataContainer, source);
                    this.dataContainer.DataSource = source;
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

        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("弄啥咧，你没有输入名字！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (MessageBox.Show("你确定？", "噢不！", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            Dictionary<string, object> paras = new Dictionary<string, object>
            {
                { AttributeName.NAME, txtName.Text.Trim() }
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

        private void Update_Click(object sender, EventArgs e)
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
                    MessageBox.Show("厉害喽！ 居然成功了！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    FormCommon.HandleException(error);
                }
            }
        }
    }
}
