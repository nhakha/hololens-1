namespace WSServer
{
    partial class WSServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lPort;
        private System.Windows.Forms.Button bRun;
        private System.Windows.Forms.TextBox tbLog;
        private nsoftware.IPWorksWS.Wsserver wsserver1;

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
            this.wsserver1 = new nsoftware.IPWorksWS.Wsserver(this.components);
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lPort = new System.Windows.Forms.Label();
            this.bRun = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // wsserver1
            // 
            this.wsserver1.About = "IP*Works! WS V9 [Build 5962]";
            this.wsserver1.OnConnected += new nsoftware.IPWorksWS.Wsserver.OnConnectedHandler(this.wsserver1_OnConnected);
            this.wsserver1.OnConnectionRequest += new nsoftware.IPWorksWS.Wsserver.OnConnectionRequestHandler(this.wsserver1_OnConnectionRequest);
            this.wsserver1.OnDataIn += new nsoftware.IPWorksWS.Wsserver.OnDataInHandler(this.wsserver1_OnDataIn);
            this.wsserver1.OnDisconnected += new nsoftware.IPWorksWS.Wsserver.OnDisconnectedHandler(this.wsserver1_OnDisconnected);
            this.wsserver1.OnWebSocketOpenRequest += new nsoftware.IPWorksWS.Wsserver.OnWebSocketOpenRequestHandler(this.wsserver1_OnWebSocketOpenRequest);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(47, 133);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(56, 20);
            this.tbPort.TabIndex = 16;
            this.tbPort.Tag = "stopped";
            this.tbPort.Text = "4444";
            // 
            // lPort
            // 
            this.lPort.Location = new System.Drawing.Point(7, 136);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(56, 23);
            this.lPort.TabIndex = 13;
            this.lPort.Text = "Port:";
            // 
            // bRun
            // 
            this.bRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRun.Location = new System.Drawing.Point(221, 131);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(75, 23);
            this.bRun.TabIndex = 17;
            this.bRun.Tag = "stopped";
            this.bRun.Text = "Start";
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Location = new System.Drawing.Point(3, 12);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbLog.Size = new System.Drawing.Size(294, 115);
            this.tbLog.TabIndex = 15;
            // 
            // WSServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 163);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lPort);
            this.Controls.Add(this.bRun);
            this.Controls.Add(this.tbLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WSServer";
            this.Text = "WSServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

