using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace runmu
{
    public class FormCommon
    {
        public static DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter
        };

        public static void InitDataContainer(DataGridView dataContainer, DataTable source)
        {

            dataContainer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataContainer.AutoGenerateColumns = false;

            for (int i = 0; i < source.Columns.Count; i++)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
                {
                    Name = source.Columns[i].ColumnName,
                    HeaderText = source.Columns[i].ColumnName,
                    DataPropertyName = source.Columns[i].ColumnName,
                    DefaultCellStyle = defaultStyle
                };
                dataContainer.Columns.Add(column);
            }

            foreach (DataGridViewColumn column in dataContainer.Columns)
            {
                if (column.Name.Contains("ID"))
                {
                    column.Visible = false;
                }
            }
        }

        public static void HandleException(Exception ex)
        {
            Logger.Error(ex);
            MessageBox.Show("出问题了，快去找大师兄！\r" + ex.Message, "噢不！", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        public static void BindComboxDataSource(Dictionary<int, string> source, ComboBox comboBox)
        {
            BindComboxDataSource(source, comboBox, false);
        }

        public static void BindComboxDataSource(Dictionary<int, string> source, ComboBox comboBox, bool withEmpty)
        {
            Dictionary<int, string> newValues = null;
            if (withEmpty)
            {
                newValues = new Dictionary<int, string>
                {
                    { -1, "" }
                };
                foreach (var item in source)
                {
                    newValues.Add(item.Key, item.Value);
                }
            }
            else
            {
                newValues = source;
            }

            comboBox.DataSource = new BindingSource(newValues, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            comboBox.SelectedIndex = 0;
        }

    }
}
