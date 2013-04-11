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
        private Form1 form = null;

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
                    form = form as Form1;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message.ToString());
                }
            }
        }


         #region Start a new Thread to handle sreen sent to the end socket
         public void Handle()
         {
             if (socket != null)
             {
                 try
                 {
                     while (socket != null && socket.IsBound)
                     {
                         Socket senderSocket = socket.Accept();
                         byte[] screen = new byte[GlobalConstants.BYTESIZE];
                         int size = senderSocket.Receive(screen);
                         String screenSize = null;
                         if (size > 0)
                         {
                             screenSize = Encoding.UTF8.GetString(screen);
                         }
                         sendThread = new Thread(new ThreadStart((handleScript = new RemoteControlPC.SenderReceive(senderSocket, screenSize, form)).sendScreen));
                         sendThread.Start();
                     }
                 }
                 catch (Exception e)
                 {
                     System.Console.WriteLine(e.Message.ToString());
                 }
             }
         }
         #endregion

         #region Function for destorying class and release all the resource
         public void Abort()
         {
             if (socket != null)
             {
                 if (socket.Connected)
                 {
                     socket.Disconnect(true);
                     socket = null;
                 }
                 else
                 {
                     socket.Dispose();
                     socket = null;
                 }
             }
             if (sendThread != null)
             {
                 sendThread.Abort();
                 if (handleScript != null)
                 {
                     handleScript.Abort();
                 }
                 handleScript = null;
             }
         }
         #endregion
    }
}
