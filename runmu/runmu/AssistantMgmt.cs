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

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

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
                catch (Exception ex)
                {
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
