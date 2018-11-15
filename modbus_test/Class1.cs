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
        byte[] in_buff=new byte[1024];
        byte[] modbus_handle = new byte[12];
        List<byte> out_buff = new List<byte>();
        DataGridView Ref_dataGridView;
       public MODBUS_manage(byte[] x, DataGridView REF_dataGridView)
        {
            in_buff = x;
            get_modbus_handle();
        }
        void get_modbus_handle()//截取包头
        {
            modbus_handle = in_buff.Take(12).ToArray();
        }
        void modbus_handle_analysis( )
        {
            int len;
            int start_address;
            int read_len;

          if ( modbus_handle[2]!=0x00|| modbus_handle[3] != 0x00)
            {
                Console.WriteLine("这不是MODBUS报文"); 
                return;
            }
          else
            {
                len = BitConverter.ToInt16(modbus_handle, 4);//获取总长度
                start_address= BitConverter.ToInt16(modbus_handle, 8);//起始地址
                read_len = BitConverter.ToInt16(modbus_handle, 10);//读取长度
                switch (modbus_handle[7])//判断功能码（具体细节未想好）
                {
                    case 0x01: break;
                    case 0x02: break;
                    case 0x03:
                      //  Ref_dataGridView[2, 0].Value
                               break;
                    case 0x04: break;
                    case 0x05: break;
                    case 0x06: break;
                    case 0x0f: break;
                    case 0x10: break;
                }


            }
         
        }
        void modbus_output()
        {
            out_buff[0] = modbus_handle[0];
            out_buff[1] = modbus_handle[1];
            out_buff[2] = 0x00;
            out_buff[3] = 0x00;
            out_buff[6] = modbus_handle[6];
            out_buff[7] = modbus_handle[7];
        }

    }
}
