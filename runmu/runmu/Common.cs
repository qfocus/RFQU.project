using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace runmu
{
    public class Common
    {
        private static DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter
        };

        public static void BindData(DataGridView dataContainer, DataTable source)
        {
            dataContainer.DataSource = null;

            dataContainer.DataSource = source;

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

        public static void InitDataContainer(DataGridView dataContainer)
        {
            dataContainer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataContainer.AutoGenerateColumns = false;
        }


    }
}
