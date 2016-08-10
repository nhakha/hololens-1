namespace IPWorksServerDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lPort;
        private System.Windows.Forms.Button bRun;
        private System.Windows.Forms.TextBox tbLog;
        private nsoftware.IPWorks.Ipdaemon ipdaemon1;

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
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lPort = new System.Windows.Forms.Label();
            this.bRun = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.ipdaemon1 = new nsoftware.IPWorks.Ipdaemon(this.components);
            this.SuspendLayout();
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(45, 12);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(56, 20);
            this.tbPort.TabIndex = 11;
            this.tbPort.Tag = "stopped";
            this.tbPort.Text = "4444";
            // 
            // lPort
            // 
            this.lPort.Location = new System.Drawing.Point(5, 12);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(56, 23);
            this.lPort.TabIndex = 8;
            this.lPort.Text = "Port:";
            // 
            // bRun
            // 
            this.bRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRun.Location = new System.Drawing.Point(251, 12);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(75, 23);
            this.bRun.TabIndex = 12;
            this.bRun.Tag = "stopped";
            this.bRun.Text = "Start";
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Location = new System.Drawing.Point(5, 41);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbLog.Size = new System.Drawing.Size(321, 140);
            this.tbLog.TabIndex = 10;
            // 
            // ipdaemon1
            // 
            this.ipdaemon1.About = "IP*Works! V9 [Build 5962]";
            this.ipdaemon1.OnConnected += new nsoftware.IPWorks.Ipdaemon.OnConnectedHandler(this.ipdaemon1_OnConnected);
            this.ipdaemon1.OnDataIn += new nsoftware.IPWorks.Ipdaemon.OnDataInHandler(this.ipdaemon1_OnDataIn);
            this.ipdaemon1.OnDisconnected += new nsoftware.IPWorks.Ipdaemon.OnDisconnectedHandler(this.ipdaemon1_OnDisconnected);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(329, 186);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lPort);
            this.Controls.Add(this.bRun);
            this.Controls.Add(this.tbLog);
            this.Name = "Form1";
            this.Text = "TCP Echo Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

