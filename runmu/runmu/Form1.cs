using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace runmu
{
    public partial class Form1 : Form
    {
        public static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Form1));

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet set = new DataSet();

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=runmu.db;Version=3;"))
            {
                conn.Open();
                string sql = "select * from teacher";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter adp = new SQLiteDataAdapter(command);


                adp.Fill(set);




                //conn.Close();

            }


            dataGridView1.DataSource = set.Tables[0];
            
           


            logger.Info("xxxxxxxxxx");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
