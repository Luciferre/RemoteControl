﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace RemoteControlPC
{
    public partial class Form1 : Form
    {
        bool connected = false;
        private RemoteControlPC.CommandThread pcthread = null;
        private RemoteControlPC.ScThread scthread = null;
        Thread threadExe = null;
        Thread threadSender = null;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            QueryIP();
            QueryPort();
            this.button2.Enabled = false;
        }

        private void QueryIP()
        {
            IPHostEntry Ip = Dns.GetHostEntry(Dns.GetHostName());
            foreach (System.Net.IPAddress ip in Ip.AddressList)
            {
                if (!ip.IsIPv6LinkLocal && ip != null&&ip.ToString().Length <= 15)
                    IPBox.Items.Add(ip);
            }          
        }

        private void QueryPort()
        {
            PCPort.Text = GlobalConstants.PCPORT;
            SCPort.Text = GlobalConstants.SCPORT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
            if (connected)
            {
                this.pbimage.Image = this.pbimage.InitialImage;
                this.lstatus.Text = GlobalConstants.SERVERSTATUSINLISTEN;
                this.bstart.Enabled = false;
                this.bstop.Enabled = true;
            }
        }

        private void Connect()
        {
            int pcport=0, scport=0;
            try
            {
                if (IPBox.Text != null && IPBox.Text.Length > 0)
                {
                    try
                    {
                        pcport = int.Parse(PCPort.Text.Trim());
                        scport = int.Parse(SCPort.Text.Trim());
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message.ToString());
                    }
                }
                else
                {
                    pcport = -1; scport = -1;
                     connected = false;                    
                }
                if (pcport != -1 && scport != -1)
                {
                    threadExe = new Thread(new ThreadStart((pcthread = new RemoteControlPC.CommandThread(IPBox.Text.ToString().Trim(), pcport, this)).Handle));
                    threadExe.Start();
                    threadSender = new Thread(new ThreadStart((scthread = new RemoteControlPC.ScThread(IPBox.Text.ToString().Trim(), scport, this)).Handle));
                    threadSender.Start();
                    connected = true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
