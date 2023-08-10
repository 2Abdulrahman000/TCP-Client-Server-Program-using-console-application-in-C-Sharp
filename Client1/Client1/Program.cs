using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Client1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client Side");
            TcpClient client = new TcpClient("192.168.1.6", 1234);
            try
            {
                Console.WriteLine("enter your message");
                string sdata = Console.ReadLine();
                int bcount = Encoding.ASCII.GetByteCount(sdata);
                byte[] bdata = new byte[bcount];
                bdata= Encoding.ASCII.GetBytes(sdata);

                NetworkStream nstream = client.GetStream();
                //nstream.Write(bdata, 0, bdata.Length);
                client.GetStream().Write(bdata, 0, bdata.Length);
                Console.WriteLine("Send data to server");

                nstream.Close();
                client.Close();
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Failed To Connect");
            }
        }
    }
}
