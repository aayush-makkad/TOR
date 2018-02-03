using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client_TOR_
{
    class Program
    {
      

        static void Main(string[] args)
        {
            double p = 3, q = 7;
            double a = 2;
            double y;
            y = Math.Pow(p, a);
            y = y % q;
            int i = 1;
            Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //sk.GetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress);
            IPEndPoint io = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12331);
            
            sk.Connect(io);
            //Socket ac = sk.Accept();
            Byte[] buff = new byte[2147480];
            int rece = sk.Receive(buff, 0, buff.Length, 0);
            Array.Resize(ref buff, rece);
            Console.WriteLine(Encoding.Default.GetString(buff));
            sk.Close();
           Socket Sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1266);
            Sck.Bind(ipe);
            Sck.Listen(10);
            Socket Sck2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe2 = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1267);
            Sck2.Bind(ipe2);
            Sck2.Listen(10);
            string str, str1, str2 ;
            str1 = null;
            str2 = null;
            //str = Console.ReadLine();
            string stro = Encoding.Default.GetString(buff);
            foreach(char  c in stro)
            {
                i++;
                if(i%2==0)
                    {
                    str1 = str1 + c;
                    }
                else
                {
                    str2 = str2 + c;
                }
            }
           
            Socket acp = Sck.Accept();
            byte[] buffer = Encoding.Default.GetBytes(str1);
            
            acp.Send(buffer, 0, buffer.Length, 0);
            //byte[] buffer3 = Encoding.Default.GetBytes(str1);
            //acp.Send(buffer3, 0, buffer3.Length, 0);
            //buffer = new byte[255];
            //int rec = acp.Receive(buffer, 0, buffer.Length, 0);
            //Array.Resize(ref buffer, rec);
            //Console.WriteLine(Encoding.Default.GetString(buffer));
            Sck.Close();
            acp.Close();
           
            Socket acp2 = Sck2.Accept();
            byte[] buffer2 = Encoding.Default.GetBytes(str2);
            
            acp2.Send(buffer2, 0, buffer2.Length, 0);
            buffer2 = new byte[25510];
            //int rec2 = acp2.Receive(buffer2, 0, buffer2.Length, 0);
            //Array.Resize(ref buffer2, rec2);
            //Console.WriteLine(Encoding.Default.GetString(buffer2));
            Sck.Close();
            acp.Close();
            Console.Read();
            //
           


        }
      

    }
}
