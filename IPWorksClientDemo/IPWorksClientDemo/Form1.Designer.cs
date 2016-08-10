namespace IPWorksClientDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.TextBox tbEcho;
        private nsoftware.IPWorks.Ipport ipport1;
        private System.Windows.Forms.Label label1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bSend = new System.Windows.Forms.Button();
            this.tbEcho = new System.Windows.Forms.TextBox();
            this.ipport1 = new nsoftware.IPWorks.Ipport(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lPort = new System.Windows.Forms.Label();
            this.lText = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lServer = new System.Windows.Forms.Label();
            this.bConnect = new System.Windows.Forms.Button();
            this.tbText = new System.Windows.Forms.TextBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bSend
            // 
            this.bSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSend.Location = new System.Drawing.Point(80, 196);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(75, 23);
            this.bSend.TabIndex = 21;
            this.bSend.Text = "Send";
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // tbEcho
            // 
            this.tbEcho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEcho.Location = new System.Drawing.Point(230, 22);
            this.tbEcho.Multiline = true;
            this.tbEcho.Name = "tbEcho";
            this.tbEcho.ReadOnly = true;
            this.tbEcho.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbEcho.Size = new System.Drawing.Size(292, 197);
            this.tbEcho.TabIndex = 20;
            // 
            // ipport1
            // 
            this.ipport1.About = "IP*Works! V9 [Build 5962]";
            this.ipport1.Firewall.Port = 1080;
            this.ipport1.OnConnected += new nsoftware.IPWorks.Ipport.OnConnectedHandler(this.ipport1_OnConnected);
            this.ipport1.OnDataIn += new nsoftware.IPWorks.Ipport.OnDataInHandler(this.ipport1_OnDataIn);
            this.ipport1.OnDisconnected += new nsoftware.IPWorks.Ipport.OnDisconnectedHandler(this.ipport1_OnDisconnected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Data received from server:";
            // 
            // lPort
            // 
            this.lPort.AutoSize = true;
            this.lPort.Location = new System.Drawing.Point(138, 16);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(29, 13);
            this.lPort.TabIndex = 26;
            this.lPort.Text = "Port:";
            // 
            // lText
            // 
            this.lText.AutoSize = true;
            this.lText.Location = new System.Drawing.Point(10, 78);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(135, 13);
            this.lText.TabIndex = 24;
            this.lText.Text = "Enter the text to send here:";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(170, 12);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(36, 20);
            this.tbPort.TabIndex = 29;
            this.tbPort.Text = "4444";
            // 
            // lServer
            // 
            this.lServer.AutoSize = true;
            this.lServer.Location = new System.Drawing.Point(11, 16);
            this.lServer.Name = "lServer";
            this.lServer.Size = new System.Drawing.Size(41, 13);
            this.lServer.TabIndex = 25;
            this.lServer.Text = "Server:";
            // 
            // bConnect
            // 
            this.bConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bConnect.Location = new System.Drawing.Point(80, 46);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(75, 23);
            this.bConnect.TabIndex = 30;
            this.bConnect.Tag = "disconnected";
            this.bConnect.Text = "Connect";
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbText.Location = new System.Drawing.Point(7, 94);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(217, 96);
            this.tbText.TabIndex = 27;
            this.tbText.Text = "Echo this text.";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(55, 12);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(80, 20);
            this.tbServer.TabIndex = 28;
            this.tbServer.Text = "localhost";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(534, 231);
            this.Controls.Add(this.lPort);
            this.Controls.Add(this.lText);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lServer);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.tbEcho);
            this.Name = "Form1";
            this.Text = "TCP Echo Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lPort;
        internal System.Windows.Forms.Label lText;
        internal System.Windows.Forms.TextBox tbPort;
        internal System.Windows.Forms.Label lServer;
        internal System.Windows.Forms.Button bConnect;
        internal System.Windows.Forms.TextBox tbText;
        internal System.Windows.Forms.TextBox tbServer;
    }
}

