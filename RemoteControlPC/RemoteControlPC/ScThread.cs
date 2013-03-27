using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace RemoteControlPC
{
    class ScThread
    {
        private Socket socket = null;
        Thread sendThread = null;
        RemoteControlPC.SenderReceive handleScript = null;
        private Form1 mainform = null;

         public ScThread(String ip, int port, Object form)
        {
            if (ip != null && ip.IndexOf(".") > 0 && port > 0)
            {
                try
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ipaddress = IPAddress.Parse(ip);
                    IPEndPoint ipendpoint = new IPEndPoint(ipaddress, port);
                    socket.Bind(ipendpoint);
                    socket.Listen(GlobalConstants.MAXLISTENSOCKETS);
                    mainform = form as Form1;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message.ToString());
                }
            }
        }
    }
}
