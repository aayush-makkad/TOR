using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace _2ndhop_TOR_
{
    class Program
    {
        static void Main(string[] args)
        {
            string y;
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12331);
            sck.Bind(ipe);
            sck.Listen(10);
            Socket acp = sck.Accept();
            y = "aaaaaaaaaaaaaaaaaaaaaaaaheyyyyyyttt";
            //byte[] data = new byte[DATA_SIZE];
            //byte[] result;
            //byte[] data = new byte[4000];
            //byte[] del = new byte[2];
            //del[0] = 0;
            //del[1] = 0;
            ////del[1] = 0;
            //data = Encoding.Default.GetBytes(y);
            // foreach(byte b in data)
            // {
            //     Console.Write(b);
            // }
            // Console.WriteLine("\n");
            // IEnumerable<byte> act = data.Concat(del);
            // foreach (byte b in act)
            // {
            //     Console.Write(b);
            // }
            // SHA1 sha = new SHA1CryptoServiceProvider();
            // // This is one implementation of the abstract class SHA1.
            // result = sha.ComputeHash(data);
            // Console.WriteLine("\n");
            // Console.WriteLine(Encoding.Default.GetString(result));
            // IEnumerable<byte> msg = act.Concat(result);
            // foreach (byte b in msg)
            // {
            //     Console.Write(b);
            //}
            //Console.WriteLine(Encoding.Default.GetString(msg));
            Console.Read();
            byte[] buffer = Encoding.Default.GetBytes(y);
        acp.Send(buffer, 0, buffer.Length, 0);
            Console.Read();
            sck.Close();
            acp.Close();
        }
    }
}
