using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;

namespace RemoteControlPC
{
    class SenderReceive
    {
         #region Variables Defined
        private Socket _socket = null;
        private String _screen = null;
        private int screenWidth = 0;
        private int screenHeight = 0;
        private Form1 form = null;
        #endregion

        #region Constructor with parameter socket
        public SenderReceive(Socket socket, Object form)
        {
            _socket = socket;
            form = form as Form1;
        }
        #endregion

        #region Constructor with Parameters socket and Screen
        public SenderReceive(Socket socket, String screen,Object form)
        {
            _socket = socket;
            _screen = screen;
            form = form as Form1;
            if (_screen != null && _screen.Length > 0)
            {
                if (_screen.IndexOf(":") > 0)
                {
                    String[] screensize = _screen.Split(':');
                    if (screensize != null && screensize.Length == 3)
                    {
                        try
                        {
                            screenWidth = Convert.ToInt32(screensize[1].Trim());
                            screenHeight = Convert.ToInt32(screensize[2].Trim());
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine(e.Message.ToString());
                        }
                    }
                }
            }
        }
        #endregion

        #region Function for Receiving Messages from socket and executing commands
        public void receiveMessage()
        {
            if (_socket != null)
            {
                _socket.ReceiveBufferSize = 256;
                _socket.Send(Encoding.UTF8.GetBytes("screen:" + System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width + ":" + System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height));
                byte[] mobile = new byte[512];
                _socket.Receive(mobile);
                String mobileStr = System.Text.Encoding.UTF8.GetString(mobile);
                if (mobileStr.IndexOf("\0") >= 0)
                {
                    mobileStr = mobileStr.Substring(0, mobileStr.IndexOf("\0"));
                }
                //form.showmessage(mobileStr + " " +  _socket.RemoteEndPoint.ToString());
                while (true && _socket.Connected)
                {
                    try
                    {
                        byte[] received = new byte[1024];
                        try
                        {
                            _socket.Receive(received);
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine(e.Message.ToString());
                            form.showmessage("断开连接从"+_socket.RemoteEndPoint.ToString());
                        }
                        string cmd = null;
                        System.Console.WriteLine((new DateTime()).Second.ToString());
                        cmd = System.Text.Encoding.UTF8.GetString(received,0,received.Length).Trim();
                        if (cmd != null)
                        {
                            cmd = cmd.Substring(0, cmd.IndexOf("\0"));
                        }
                        if (cmd.IndexOf("|") >= 0)
                        {
                            String[] cmds = cmd.Split('|');
                            for (int index = 0; index < cmds.Length; index++)
                            {
                                MouseKeysUtils.processCommand(cmds[index]);
                            }
                        }
                        else
                        {
                            MouseKeysUtils.processCommand(cmd);
                        }
                    }
                    catch (Exception ereceivemessage)
                    {
                        System.Console.WriteLine("ereceivemessage: " + ereceivemessage.Message.ToString());
                    }
                }
            }
        }
        #endregion

        #region Function for Send Screen with specified size
        public void sendScreen()
        {
            if (_socket != null)
            {
                while (true && _socket.Connected)
                {
                    try
                    {
                        _socket.SendBufferSize = GlobalConstants.SOCKETSENDBUFFERSIZE;
                        byte[] screenbyte = MouseKeysUtils.catchScreen(screenWidth == 0 ? 500 : screenWidth, screenHeight == 0 ? 200 : screenHeight);
                        _socket.Send(screenbyte);
                        _socket.Send(new byte[] { 19, 87, 11 });
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e.Message.ToString());
                    }
                }
            }
        }
        #endregion

        #region Function for destorying class
        public void Abort()
        {
            if (_socket != null)
            {
                if (_socket.Connected)
                {
                    _socket.Dispose();
                    _socket = null;
                }
                else
                {
                    _socket.Dispose();
                    _socket = null;
                }
            }
        }
        #endregion
    }
}
