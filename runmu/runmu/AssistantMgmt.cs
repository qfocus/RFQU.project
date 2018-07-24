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
    public partial class AssistantMgmt : Form
    {
        private IService service;

        public AssistantMgmt(IUnityContainer container)
        {
            service = container.Resolve<AssistantService>();
            InitializeComponent();
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
                    Logger.Error(error);
                    MessageBox.Show("出问题了，快去找大师兄！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {

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

            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();
                    service.Add(conn, new Args(AttributeName.NAME, txtName.Text.Trim()));
                    RefreshData(conn);

                    MessageBox.Show("厉害喽！ 居然成功了！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    FormCommon.HandleException(error);
                }
            }
        }

        private void AssistantMgmt_Load(object sender, EventArgs e)
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
                catch (Exception error)
                {
                    FormCommon.HandleException(error);
                }
            }
        }

        private void RefreshData(SQLiteConnection conn)
        {
            DataTable table = service.GetAll(conn);

            dataContainer.DataSource = table;

        }
    }
}
