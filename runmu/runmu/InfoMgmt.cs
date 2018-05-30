using runmu.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace runmu
{
    public partial class InfoMgmt : Form
    {
        private IService service;
        public InfoMgmt(IService container)
        {
            this.service = container;
            InitializeComponent();
        }

        private void TeacherUI_Load(object sender, EventArgs e)
        {
            DataTable table = service.GetAll();

            Common.BindData(dataContainer, table);
        }

        private void Save_Click(object sender, EventArgs e)
        {

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
                int id = Convert.ToInt32(row.Cells["id"].Value);
                ids.Add(id);
            }
            DialogResult dialogResult = MessageBox.Show("你确定要删除这些数据吗？", "噢不!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.OK)
            {
                return;
            }




        }
    }
}
