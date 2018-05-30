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
        public static void BindData(DataGridView dataContainer, DataTable source)
        {
            DataGridViewCellStyle defaultStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            dataContainer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataContainer.AutoGenerateColumns = false;
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
            dataContainer.Columns["id"].Visible = false;
        }


    }

}
