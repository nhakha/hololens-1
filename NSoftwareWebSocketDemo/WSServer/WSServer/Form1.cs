using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using nsoftware.IPWorksWS;

namespace WSServer
{
    public partial class WSServer : Form
    {
        public WSServer()
        {
            InitializeComponent();
        }

        private void wsserver1_OnConnectionRequest(object sender, WsserverConnectionRequestEventArgs e)
        {
            tbLog.AppendText("Connection request from " + e.Address + ". Accepting.\r\n");
            e.Accept = true;
        }

        private void wsserver1_OnWebSocketOpenRequest(object sender, WsserverWebSocketOpenRequestEventArgs e)
        {
            tbLog.AppendText("WebSocket Open Request from " + e.HostHeader + ".\r\n");
        }

        private void wsserver1_OnConnected(object sender, nsoftware.IPWorksWS.WsserverConnectedEventArgs e)
        {
            tbLog.AppendText("Client " + wsserver1.Connections[e.ConnectionId].RemoteHost + " has connected.\r\n");
        }

        private void wsserver1_OnDisconnected(object sender, nsoftware.IPWorksWS.WsserverDisconnectedEventArgs e)
        {
            tbLog.AppendText("Client " + e.ConnectionId.ToString() + " disconnected.\r\n");
        }

        private void wsserver1_OnDataIn(object sender, nsoftware.IPWorksWS.WsserverDataInEventArgs e)
        {
            tbLog.AppendText("Receiving data '" + e.Text + "' from client " + e.ConnectionId.ToString() + ".\r\n");
            ThreadPool.QueueUserWorkItem(new WaitCallback(SendData), e);
        }

        private void bRun_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!wsserver1.Listening)
                {
                    wsserver1.UseSSL = false;
                    wsserver1.LocalPort = Convert.ToInt16(tbPort.Text);
                    wsserver1.InvokeThrough = this;
                    wsserver1.Listening = true;
                    bRun.Text = "Stop";
                    tbLog.AppendText("Started server.\r\n");
                }
                else
                {
                    wsserver1.Shutdown();
                    bRun.Text = "Start";
                    tbLog.AppendText("Stopped server.\r\n");
                }
            }
            catch (IPWorksWSException ipwse)
            {
                MessageBox.Show(this, ipwse.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void SendData(Object state)
        {
            WsserverDataInEventArgs e = (WsserverDataInEventArgs)state;
            foreach (WSConnection conn in wsserver1.Connections.Values)
            {
                if (conn.ConnectionId != e.ConnectionId)
                {
                    tbLog.AppendText("Sending data '" + e.Text + "' to client " + conn.ConnectionId.ToString() + ".\r\n");
                    wsserver1.Connections[conn.ConnectionId].DataToSend = e.Text;
                }
            }
        }

        //private void bSend_Click(object sender, EventArgs e)
        //{
        //    foreach (WSConnection conn in wsserver1.Connections.Values)
        //    {
        //        conn.DataToSend = tbMessage.Text;
        //    }
        //}
    }
}
