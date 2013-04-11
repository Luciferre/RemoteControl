using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RemoteControlPC
{
    class CommandThread
    {
        private Socket socket = null;
        Thread RCThread = null;
        RemoteControlPC.SenderReceive handleScript = null;
        Form1 mainformc = null;
       
         public CommandThread(String ip, int port, Object form)
        {
            mainformc = form as Form1;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = IPAddress.Parse(ip);
            IPEndPoint ipendpoint = new IPEndPoint(ipaddress, port);
            socket.Bind(ipendpoint);
            socket.Listen(GlobalConstants.MAXLISTENSOCKETS);
        }

         public void Handle()
         {
             while (socket != null && socket.IsBound)
             {
                 Socket executorSocket = socket.Accept();
                 mainformc.showmessage(executorSocket.RemoteEndPoint.ToString());
                 RCThread = new Thread(new ThreadStart((handleScript = new RemoteControlPC.SenderReceive(executorSocket, mainformc)).receiveMessage));
                 RCThread.Start();
             }
         }
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
             if (RCThread != null)
             {
                 RCThread.Abort();
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
