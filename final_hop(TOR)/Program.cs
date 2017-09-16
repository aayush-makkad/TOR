using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace final_hop_TOR_
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //double p = 3, q = 7;
            //double b = 3;
            //double y;
            //y = Math.Pow(p, b);
            //y = y % q;
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1266);
            sck.Connect(ipe);
            //byte[] msg = Encoding.Default.GetBytes(y.ToString());
            //sck.Send(msg,0,msg.Length,0);
            //byte[] msg2 = Encoding.Default.GetBytes("dummm");
            //sck.Send(msg2, 0, msg2.Length, 0);
            byte[] buffer = new byte[255];
            int rec = sck.Receive(buffer, 0, buffer.Length, 0);
            Array.Resize(ref buffer, rec);
            string str = Encoding.Default.GetString(buffer);
            Console.WriteLine(Encoding.Default.GetString(buffer));
            Socket Sckl = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipeo = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1269);
            Sckl.Bind(ipeo);
            Sckl.Listen(10);
            Socket acp = Sckl.Accept();
            byte[] bufferl = Encoding.Default.GetBytes(str);
            acp.Send(bufferl, 0, bufferl.Length, 0);

            Sckl.Close();
            acp.Close();
            Console.Read();
            Console.Read();
        }
    }
}
