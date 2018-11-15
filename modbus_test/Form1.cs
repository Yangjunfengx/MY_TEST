using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Data.SqlClient;

namespace modbus_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//连接modbus数据源

        {
            Byte[] test = new byte[16] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15 };
           // dataGridView1.Columns.Add();
          //  MODBUS_manage ts = new MODBUS_manage(test);

        }
        //private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        //{
        //    e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“my_DBDataSet.modbus”中。您可以根据需要移动或删除它。
            this.modbusTableAdapter.Fill(this.my_DBDataSet.modbus);

        }

        private void my_tes(object sender, DataGridViewCellEventArgs e)
        {

            this.modbusTableAdapter.Update(my_DBDataSet);
        }

        private void DataError_handle(object sender, DataGridViewDataErrorEventArgs e)

        {
            //Console.WriteLine(e.Exception);
            //dataGridView1.ClearSelection();
            //dataGridView1[e.ColumnIndex, e.RowIndex].Value = (short)0;
            //this.modbusTableAdapter.Update(my_DBDataSet);
           
        }

        private void DataGridView_Cellvalidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {

                DataGridView grid = (DataGridView)sender;
                Int64 buff;
                grid.Rows[e.RowIndex].ErrorText = "";
                if ((grid.Columns[e.ColumnIndex].Name == "保持寄存器DataGridViewTextBoxColumn") | (grid.Columns[e.ColumnIndex].Name == "输入寄存器DataGridViewTextBoxColumn"))
                {
                    if (Int64.TryParse(e.FormattedValue.ToString(),out buff)==false  ||Int64.Parse(e.FormattedValue.ToString()) >short.MaxValue|| Int64.Parse(e.FormattedValue.ToString()) <short.MinValue)
                    {
                        MessageBox.Show("数值上下限+ -32767");
                        dataGridView1.CancelEdit();
                        e.Cancel = true;
                    }
                }



            }
        }
    }
}
