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
using System.Net.Sockets;

namespace modbus_test
{
    public partial class Form1 : Form
    {
        private static Socket server_sock;//服务器连接
        private List<ClientThread> LIST_ClientThread = new List<ClientThread>();
        private List<Thread> LIST_Thread = new List<Thread>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//连接modbus数据源

        {
            button1.Enabled = false;
            server_build();

        }
        //private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        //{
        //    e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        //}



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
                    if (Int64.TryParse(e.FormattedValue.ToString(), out buff) == false || Int64.Parse(e.FormattedValue.ToString()) > short.MaxValue || Int64.Parse(e.FormattedValue.ToString()) < short.MinValue)
                    {
                        MessageBox.Show("数值上下限+ -32767");
                        dataGridView1.CancelEdit();
                        e.Cancel = true;
                    }
                }



            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“database1DataSet.modbusTable”中。您可以根据需要移动或删除它。
            this.modbusTableTableAdapter.Fill(this.database1DataSet.modbusTable);

        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            this.modbusTableTableAdapter.Update(database1DataSet);
        }

        private void server_build()//服务器建立
        {

            var serverFullAddr_build = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 502);
             server_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server_sock.Bind(serverFullAddr_build);
                server_sock.Listen(5);

                Thread tcpThread = new Thread(new ThreadStart(TcpListen));
                tcpThread.IsBackground = true;
                tcpThread.Start();
            }
            catch (Exception ee)
            {
                server_output.Invoke(new Action(() => server_output.AppendText("" + ee + "\n")));
            }
        }

        private void TcpListen()
        {

            while (true)
            {
                try
                {
                    Socket client = server_sock.Accept();
                    if (LIST_ClientThread.Count != 0)
                    {
                        for (int i = 0; i < LIST_ClientThread.Count; i++)
                        {
                            if (LIST_ClientThread[i].is_runing == false)
                            {
                                LIST_Thread[i].Abort();
                                LIST_ClientThread.RemoveAt(i);
                                server_output.Invoke(new Action(() => server_output.AppendText("正在销毁进程" + "\n")));
                            }

                        }
                    }
                    ClientThread newClient = new ClientThread(client, this.server_output,this.dataGridView1,this.database1DataSet);
                    LIST_ClientThread.Add(newClient);
                    Thread newThread = new Thread(new ThreadStart(newClient.ClientService));
                    newThread.IsBackground = true;
                    LIST_Thread.Add(newThread);
                  //  comboBox1.Invoke(new Action(() => comboBox1.Items.Add(client.RemoteEndPoint)));

                    newThread.Start();
                }
                catch (Exception ee)
                {
                    server_output.Invoke(new Action(() => server_output.AppendText("" + ee + "\n")));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         Console.WriteLine(   database1DataSet.Tables[0].Rows[2][3]);
        }
    }
    class ClientThread
    {
        public bool is_runing;
        public Socket client = null;
        public TextBox out_buff = null;
        public DataGridView z = null;
        public Database1DataSet z3 = null;
        int i;
        public ClientThread(Socket k, TextBox x, DataGridView Z, Database1DataSet z2)
        {
            client = k;
            out_buff = x;
            is_runing = true;
            z = Z;
            z3 = z2;
        }
        public void ClientService()
        {
            string data = null;
            byte[] bytes = new byte[4096];
            
            out_buff.Invoke(new Action(() => out_buff.AppendText("新用户的连接。。。" + "\n")));
            try
            {
                while ((i = client.Receive(bytes)) != 0)
                {
                    if (i < 0)
                    {
                        break;
                    }
                    data = Encoding.Default.GetString(bytes, 0, i);
                    out_buff.Invoke(new Action(() => out_buff.AppendText("收到数据:" + data + "\n")));
                    MODBUS_manage md = new MODBUS_manage(bytes, z, z3);
                    md.run();
                    client.Send(md.out_buff.ToArray());
                foreach(short x in md.out_buff)
                {
                    Console.WriteLine(x);
                }
                
                }
        }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
            client.Close();
            out_buff.Invoke(new Action(() => out_buff.AppendText("用户断开连接。。。" + "\n")));
            is_runing = false;

        }




    }
} 

   