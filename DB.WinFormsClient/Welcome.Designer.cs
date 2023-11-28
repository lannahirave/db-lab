namespace DB.WinFormsClient
{
    partial class Welcome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OpenDB = new Button();
            NewDBName = new TextBox();
            CreateNewDB = new Button();
            textBox1 = new TextBox();
            ConnectToRpc = new Button();
            gRPSHost = new TextBox();
            gRPCPort = new TextBox();
            ConnectTogRPC = new Button();
            SuspendLayout();
            // 
            // OpenDB
            // 
            OpenDB.Location = new Point(50, 12);
            OpenDB.Name = "OpenDB";
            OpenDB.Size = new Size(246, 59);
            OpenDB.TabIndex = 0;
            OpenDB.Text = "Open";
            OpenDB.UseVisualStyleBackColor = true;
            OpenDB.Click += OpenDB_Click;
            // 
            // NewDBName
            // 
            NewDBName.Location = new Point(50, 93);
            NewDBName.Name = "NewDBName";
            NewDBName.PlaceholderText = "DB name";
            NewDBName.Size = new Size(246, 23);
            NewDBName.TabIndex = 1;
            NewDBName.TextAlign = HorizontalAlignment.Center;
            // 
            // CreateNewDB
            // 
            CreateNewDB.Location = new Point(50, 122);
            CreateNewDB.Name = "CreateNewDB";
            CreateNewDB.Size = new Size(246, 75);
            CreateNewDB.TabIndex = 2;
            CreateNewDB.Text = "Create new";
            CreateNewDB.UseVisualStyleBackColor = true;
            CreateNewDB.Click += CreateDb_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(50, 229);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Pipe name";
            textBox1.Size = new Size(246, 23);
            textBox1.TabIndex = 3;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // ConnectToRpc
            // 
            ConnectToRpc.Location = new Point(50, 258);
            ConnectToRpc.Name = "ConnectToRpc";
            ConnectToRpc.Size = new Size(246, 75);
            ConnectToRpc.TabIndex = 4;
            ConnectToRpc.Text = "Connect to RPC server";
            ConnectToRpc.UseVisualStyleBackColor = true;
            // 
            // gRPSHost
            // 
            gRPSHost.Location = new Point(50, 373);
            gRPSHost.Name = "gRPSHost";
            gRPSHost.PlaceholderText = "Host";
            gRPSHost.Size = new Size(157, 23);
            gRPSHost.TabIndex = 5;
            gRPSHost.TextAlign = HorizontalAlignment.Center;
            // 
            // gRPCPort
            // 
            gRPCPort.Location = new Point(205, 373);
            gRPCPort.Name = "gRPCPort";
            gRPCPort.PlaceholderText = "Port";
            gRPCPort.Size = new Size(91, 23);
            gRPCPort.TabIndex = 6;
            gRPCPort.TextAlign = HorizontalAlignment.Center;
            // 
            // ConnectTogRPC
            // 
            ConnectTogRPC.Location = new Point(50, 402);
            ConnectTogRPC.Name = "ConnectTogRPC";
            ConnectTogRPC.Size = new Size(246, 75);
            ConnectTogRPC.TabIndex = 7;
            ConnectTogRPC.Text = "Connect to gRPC server";
            ConnectTogRPC.UseVisualStyleBackColor = true;
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 523);
            Controls.Add(ConnectTogRPC);
            Controls.Add(gRPCPort);
            Controls.Add(gRPSHost);
            Controls.Add(ConnectToRpc);
            Controls.Add(textBox1);
            Controls.Add(CreateNewDB);
            Controls.Add(NewDBName);
            Controls.Add(OpenDB);
            Name = "Welcome";
            Text = "DB Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OpenDB;
        private TextBox NewDBName;
        private Button CreateNewDB;
        private TextBox textBox1;
        private Button ConnectToRpc;
        private TextBox gRPSHost;
        private TextBox gRPCPort;
        private Button ConnectTogRPC;
    }
}