﻿using runmu.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

            Args[] paras = new Args[]
            {   new Args(AttributeName.NAME, txtName.Text.Trim()),
                new Args(AttributeName.ID,txtQQ.Text ),
                new Args(AttributeName.Phone,txtPhone.Text),
                new Args(AttributeName.Wechat,txtWechat.Text),
                new Args(AttributeName.Email,txtEmail.Text)
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

        private void StudentsMgmt_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constants.DBCONN))
            {
                try
                {
                    conn.Open();
                    DataTable source = service.GetAll(conn);
                    FormCommon.InitDataContainer(dataContainer, source);

                    dataContainer.DataSource = source;

                }
                catch (Exception error)
                {
                    FormCommon.HandleException(error);
                    this.Dispose();
                }
            }
        }

        private void RefreshData(SQLiteConnection conn)
        {
            dataContainer.DataSource = null;
            DataTable source = service.GetAll(conn);
            dataContainer.DataSource = source;
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
