using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modbus_test
{
    class  MODBUS_manage
    {
        byte[] swap = new byte[4] {0,0,0,0}; 
        int len;
        int start_address;
        int read_len;
        int command = 0;
        List<short> value_buff = new List<short>();
        byte[] in_buff=new byte[1024];
        byte[] modbus_handle = new byte[12];
        public byte[] out_buff = new byte[30];
        DataGridView Ref_dataGridView;
        Database1DataSet in_BS;
       public MODBUS_manage(byte[] x, DataGridView REF_dataGridView , Database1DataSet BS)
        {
            in_buff = x;
            get_modbus_handle();
            Ref_dataGridView = REF_dataGridView;
            in_BS = BS;
        }
        void get_modbus_handle()//截取包头
        {
            modbus_handle = in_buff.Take(12).ToArray();
        }
        void modbus_handle_analysis( )//包头处理
        {


          if ( modbus_handle[2]!=0x00|| modbus_handle[3] != 0x00)
            {
                MessageBox.Show("这不是MODBUS报文"); 
                return;
            }
          else
            {
                swap[0] = modbus_handle[5]; swap[1] = modbus_handle[4];
                len = BitConverter.ToInt32(swap, 0);//获取总长度
                swap[0] = modbus_handle[9]; swap[1] = modbus_handle[8];
                start_address = BitConverter.ToInt32(swap,0);//起始地址
                swap[0] = modbus_handle[11]; swap[1] = modbus_handle[10];
                read_len = BitConverter.ToInt32(swap,0);//读取长度
                switch (modbus_handle[7])//判断功能码（具体细节未想好）
                {
                    case 0x01: command = 1; break;
                    case 0x02: command = 2; break;
                    case 0x03: command = 3; break;
                    case 0x04: command = 4; break;
                    case 0x05: command = 5; break;
                    case 0x06: command = 6; break;
                    case 0x0f: command = 15; break;
                    case 0x10: command = 16; break;
                }


            }
         
        }
        int get_value()
        {
            int getColumn=0;
            int real_start_address=0;
            switch (command)
            {
                case 1: getColumn = 1; real_start_address = start_address; break;
                case 2:
                    getColumn = 2;
                    if (start_address >= 10000)

                        real_start_address = start_address - 10000;
                    else
                        real_start_address = start_address;
                    break;

                case 3:
                    getColumn = 3;
                    if (start_address >= 40000)

                        real_start_address = start_address - 40000;
                    else
                        real_start_address = start_address;
                    break;

                case 4:
                    getColumn =4;
                    if (start_address >= 30000)

                        real_start_address = start_address - 30000;
                    else
                        real_start_address = start_address;
                    break;

                case 5: getColumn = 1; real_start_address = start_address; break;
                case 6:
                    getColumn = 3;
                    if (start_address >= 40000)

                        real_start_address = start_address - 40000;
                    else
                        real_start_address = start_address;
                    break;
                   
                case 15: getColumn = 1; real_start_address = start_address; break;

                case 16:
                    getColumn = 3;
                    if (start_address >= 40000)

                        real_start_address = start_address - 40000;
                    else
                        real_start_address = start_address;
                    break;
            }
           if (Ref_dataGridView.RowCount< real_start_address)
            {
                MessageBox.Show("起始地址不正确");
                return 1;
            }
            if (Ref_dataGridView.RowCount < (real_start_address+ read_len))
            {
                MessageBox.Show("读取长度超限");
                return 1;
            }
            for(int i= real_start_address-1;i< (read_len+1);i++)
            {
                //value_buff.Add(short.Parse(Ref_dataGridView[getColumn, i].Value.ToString()));
                value_buff.Add((short)(in_BS.Tables[0].Rows[i][getColumn]) );

            }
            return 0;


        }//获取数据
        void modbus_output()
        {
            int try_pass = 0;
            out_buff.Initialize();
            value_buff.Clear();
            out_buff[0]= modbus_handle[0];
            out_buff[1] = modbus_handle[1];
            out_buff[2] = 0x00;
            out_buff[3]= 0x00;
            //out_buff.Insert(6, modbus_handle[6]);
            //out_buff.Insert(7, modbus_handle[7]);
            try_pass = get_value();
            if (try_pass == 1)
            {
                out_buff.Initialize();
                value_buff.Clear();
                return;
            }
            else
            {
                List<byte> value_buff_byte = new List<byte>();
                byte[] buff = new byte[2];
                byte[] buff2 = new byte[2];
                foreach (short item in value_buff)
                { 
                    buff = BitConverter.GetBytes(item);
                    buff2[0] = buff[1];
                    buff2[1] = buff[0];
                    value_buff_byte.AddRange(buff2);
                }

                for (int i = 9; i < value_buff_byte.Count + 9; i++)
                {
                    out_buff[i] = value_buff_byte[i - 9];
                }
                out_buff[6] = modbus_handle[6];
                out_buff[7] = modbus_handle[7];
                out_buff[4] = (byte)((3 + value_buff_byte.Count>>8) & 0xff);
                out_buff[5] = (byte)((3 + value_buff_byte.Count)&0xff);
                out_buff[8] = (byte)value_buff_byte.Count;

            
               // out_buff.AddRange(value_buff_byte);
  

            }
        }//数据输出
        public void run()
        {
            get_modbus_handle();
            modbus_handle_analysis();
            modbus_output();
        }

    }
}
