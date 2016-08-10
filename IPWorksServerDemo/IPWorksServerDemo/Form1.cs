using System;
using System.Threading;
using System.Windows.Forms;
using nsoftware.IPWorks;

namespace IPWorksServerDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void bRun_Click(object sender, System.EventArgs e)
        {
            if (bRun.Text == "Start")
            {
                ipdaemon1.LocalPort = Convert.ToInt32(tbPort.Text);
                ipdaemon1.InvokeThrough = this;
                ipdaemon1.Listening = true;
                bRun.Text = "Stop";
                tbLog.AppendText("Started server.\r\n");
            }
            else
            {
                ipdaemon1.Listening = false;
                ipdaemon1.Shutdown();
                bRun.Text = "Start";
                tbLog.AppendText("Stopped server.\r\n");
            }
        }

        private void ipdaemon1_OnConnected(object sender, IpdaemonConnectedEventArgs e)
        {
            ipdaemon1.Connections[e.ConnectionId].AcceptData = true;
            tbLog.AppendText(ipdaemon1.Connections[e.ConnectionId].RemoteHost + " has connected.\r\n");
            ipdaemon1.Connections[e.ConnectionId].EOL = "\r\n";
        }

        private void ipdaemon1_OnDataIn(object sender, IpdaemonDataInEventArgs e)
        {
            // Receive data
            tbLog.AppendText("Receiving data '" + e.Text + "' from client " + ipdaemon1.Connections[e.ConnectionId].RemoteHost + ".\r\n");
            ThreadPool.QueueUserWorkItem(new WaitCallback(SendData), e);
        }

        private void ipdaemon1_OnDisconnected(object sender, IpdaemonDisconnectedEventArgs e)
        {
            tbLog.AppendText("Disconnected '" + e.Description + "' from " + e.ConnectionId + ".\r\n");
        }

        private void SendData(Object state)
        {
            IpdaemonDataInEventArgs e = (IpdaemonDataInEventArgs)state;
            // Send data to other clients
            foreach (Connection conn in ipdaemon1.Connections.Values)
            {
                //if (conn.ConnectionId != e.ConnectionId)
                //{
                    tbLog.AppendText("Sending data '" + e.Text + "' to client " + conn.ConnectionId.ToString() + ".\r\n");
                    ipdaemon1.Connections[conn.ConnectionId].DataToSend = e.Text;
                //}
            }
        }
    }
}
