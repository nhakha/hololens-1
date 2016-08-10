using System;
using System.Windows.Forms;

namespace IPWorksClientDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bConnect_Click(object sender, System.EventArgs e)
        {
            bConnect.Enabled = false;
            try
            {
                if (bConnect.Text == "Connect")
                {
                    bConnect.Enabled = false;
                    ipport1.InvokeThrough = this;
                    ipport1.Connect(tbServer.Text, Convert.ToInt32(tbPort.Text));
                    bConnect.Text = "Disconnect";
                    bConnect.Enabled = true;
                }
                else
                {
                    bConnect.Enabled = false;
                    ipport1.Disconnect();
                    bConnect.Text = "Connect";
                    bConnect.Enabled = true;
                }
            }
            catch
            {
                bConnect.Text = "Connect";
                bConnect.Enabled = true;
            }
        }

        private void ipport1_OnConnected(object sender, nsoftware.IPWorks.IpportConnectedEventArgs e)
        {
            bConnect.Enabled = true;
            tbEcho.AppendText(e.StatusCode == 0 ? "Connected.\r\n" : "Failed to connect. Reason: " + e.Description + ".\r\n");
        }

        private void ipport1_OnDataIn(object sender, nsoftware.IPWorks.IpportDataInEventArgs e)
        {
            tbEcho.AppendText("Received '" + e.Text + "' from " + ipport1.RemoteHost + "\r\n");
        }

        private void bSend_Click(object sender, System.EventArgs e)
        {
            if (ipport1.Connected == true)
            {
                ipport1.DataToSend = tbText.Text + "\r\n";
                tbEcho.AppendText("Sending '" + tbText.Text + "'.\r\n");
            }
            else
            {
                tbEcho.AppendText("You're not connected.\r\n");
            }
        }

        private void ipport1_OnDisconnected(object sender, nsoftware.IPWorks.IpportDisconnectedEventArgs e)
        {
            bConnect.Text = "Connect";
            tbEcho.AppendText("Disconnected.\r\n");
        }
    }
}
