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
        Form1 mainform = null;
       
         public CommandThread(String ip, int port, Object form)
        {
            mainform = form as Form1;
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
                 this.mainform.showmessage(executorSocket.RemoteEndPoint.ToString());
                 this.mainform.changeIco(new System.Drawing.Bitmap(Properties.Resources.bot));
                 RCThread = new Thread(new ThreadStart((handleScript = new RemoteControlPC.ReceiveSender(executorSocket, this.mainformc)).receiveMessage));
                 RCThread.Start();
             }
         }
    }
}
