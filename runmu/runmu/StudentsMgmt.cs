using runmu.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace runmu
{
    public partial class StudentsMgmt : Form
    {
        private Service service;

        public StudentsMgmt(IUnityContainer container)
        {
            this.service = container.Resolve<StudentsService>();
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("弄啥咧，你没有输入名字！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtQQ.Text) || !int.TryParse(txtQQ.Text, out int qq))
            {
                MessageBox.Show("弄啥咧，请输入人类的QQ！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtPhone.Text) && !int.TryParse(txtPhone.Text, out int phone))
            {
                MessageBox.Show("弄啥咧，请输入人类的电话！", "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }


            Model model = new Model
            {
                Name = txtName.Text,
                Qq = txtQQ.Text,
                Phone = txtPhone.Text,
                WeChat = txtWechat.Text
            };
            model.Phone = txtPhone.Text;

            service.Add(model);
            MessageBox.Show("厉害喽！ 居然成功了！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshData();
        }

        private void StudentsMgmt_Load(object sender, EventArgs e)
        {
            DataTable source = service.GetAll();
            FormCommon.InitDataContainer(dataContainer, source);

            dataContainer.DataSource = source;
        }

        private void RefreshData()
        {
            dataContainer.DataSource = null;
            DataTable source = service.GetAll();
            dataContainer.DataSource = source;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("你确定？", "噢不!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            service.Update((DataTable)dataContainer.DataSource);
            RefreshData();
        }
    }
}
