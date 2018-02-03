using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerEndPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1269);
            sck.Connect(ipe);
            //byte[] msg = Encoding.Default.GetBytes("dummm");
            //sck.Send(msg, 0, msg.Length, 0);
            byte[] buffer = new byte[255];
            int rec = sck.Receive(buffer, 0, buffer.Length, 0);
            Array.Resize(ref buffer, rec);
            string str = Encoding.Default.GetString(buffer); //odd bytes/char 
            Console.WriteLine(str);
            sck.Close();
            Socket sckm = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipem = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1470);
            sckm.Connect(ipem);
            //byte[] msg = Encoding.Default.GetBytes("dummm");
            //sck.Send(msg, 0, msg.Length, 0);
            byte[] bufferm = new byte[2551000];
            int recm = sckm.Receive(bufferm, 0, bufferm.Length, 0);
            Array.Resize(ref bufferm, rec);
            string strm = Encoding.Default.GetString(bufferm); //odd bytes/char 
            Console.WriteLine(strm);
            String outp = str + strm;
            int len = outp.Length;
            char[] b = new char[len];
            //for (int i = 0; i < len - 1; i++)
            //{
            //    if (i % 2 != 0)
            //    {
            //        foreach (char c in str)
            //            b[i] = c;
            //    }
            //    else
            //    {
                    
            //    }
            //}
            Console.WriteLine(outp);
            Console.Read();
;        }
    }
}
