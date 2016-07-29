using System.Windows.Forms;
using nsoftware.IPWorksWS;

namespace WSClient
{
    public partial class WSClient : Form
    {
        public WSClient()
        {
            InitializeComponent();
        }

        private void wsclient1_OnConnected(object sender, nsoftware.IPWorksWS.WsclientConnectedEventArgs e)
		{
			bConnect.Enabled = true;
			tbEcho.AppendText(e.StatusCode == 0 ? "Connected.\r\n" : "Failed to connect. Reason: " + e.Description + ".\r\n");
        }

        private void wsclient1_OnDisconnected(object sender, nsoftware.IPWorksWS.WsclientDisconnectedEventArgs e)
        {
            bConnect.Enabled = true;
            bConnect.Text = "Connect";
            tbEcho.AppendText("Disconnected.\r\n");
        }

        private void wsclient1_OnDataIn(object sender, nsoftware.IPWorksWS.WsclientDataInEventArgs e)
		{
			tbEcho.AppendText("Receiving data '" + e.Text + "'.\r\n");
		}

		private void bConnect_Click(object sender, System.EventArgs e)
		{
			bConnect.Enabled = false;
            try
            {
                if (bConnect.Text == "Connect")
                {
                    wsclient1.Timeout = 10;
                    wsclient1.InvokeThrough = this;

                    wsclient1.Connect(tbServer.Text);
                    bConnect.Text = "Disconnect";
                }
                else
                {
                    wsclient1.Disconnect();
                }
            }
            catch (IPWorksWSException ipwse)
            {
                MessageBox.Show(this, ipwse.Message, "Error", MessageBoxButtons.OK);
                bConnect.Text = "Connect";
                bConnect.Enabled = true;
            }
		}

		private void bSend_Click(object sender, System.EventArgs e)
		{
			if (wsclient1.Connected)
			{
				tbEcho.AppendText("Sending '" + tbText.Text + "'.\r\n");
				try
				{
					wsclient1.DataToSend = tbText.Text;
				}
				catch (IPWorksWSException ipwse)
				{
					tbEcho.AppendText("Failed to send '" + tbText.Text + "'. Reason: " + ipwse.Message + ".\r\n");
				}
			}
			else
			{
				tbEcho.AppendText("You are not connected.\r\n");
			}
		}
    }
}
