using runmu.Business;
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
            DataTable table = service.GetAll();

            FormCommon.InitDataContainer(dataContainer, table);

            dataContainer.DataSource = table;

        }

        private void Save_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("你确定？", "噢不!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            service.Update((DataTable)dataContainer.DataSource);
            RefreshData();
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

            Model model = new Model
            {
                Name = txtName.Text,
                Qq = txtQQ.Text,
                Alias = txtAlias.Text,
                Email = txtEmail.Text
            };

            service.Add(model);
            MessageBox.Show("厉害喽！ 居然成功了！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshData();
        }
        private void RefreshData()
        {
            dataContainer.DataSource = null;
            DataTable source = service.GetAll();
            dataContainer.DataSource = source;
        }
    }
}
