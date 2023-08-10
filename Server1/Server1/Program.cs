using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server side");
            TcpListener listener = new TcpListener(IPAddress.Any, 1234);
            listener.Start();
            while (true)
            {
                Console.WriteLine("Waiting For Connecting");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Connect is Successed");
                NetworkStream nstream = client.GetStream();
                try
                {
                    byte[] bdata=new byte[1024];
                    nstream.Read(bdata,0,bdata.Length);
                    int recv=0;
                    foreach (byte b in bdata)
                    {
                        if (b != 0) recv++;
                    }
                    string sdata = Encoding.ASCII.GetString(bdata,0,recv);
                    Console.WriteLine("the Client Send : "+sdata);
                }
                catch (Exception)
                {
                    Console.WriteLine("Connect is Failed");
                }
            
            }
        }
    }
}
