namespace WinFormsApp1
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
            label1 = new Label();
            SuspendLayout();
            // 
            // OpenDB
            // 
            OpenDB.Location = new Point(257, 122);
            OpenDB.Name = "OpenDB";
            OpenDB.Size = new Size(246, 59);
            OpenDB.TabIndex = 0;
            OpenDB.Text = "Відкрити";
            OpenDB.UseVisualStyleBackColor = true;
            OpenDB.Click += OpenDB_Click;
            // 
            // NewDBName
            // 
            NewDBName.Location = new Point(257, 238);
            NewDBName.Name = "NewDBName";
            NewDBName.PlaceholderText = "Назва бд";
            NewDBName.Size = new Size(246, 23);
            NewDBName.TabIndex = 1;
            NewDBName.TextAlign = HorizontalAlignment.Center;
            // 
            // CreateNewDB
            // 
            CreateNewDB.Location = new Point(257, 267);
            CreateNewDB.Name = "CreateNewDB";
            CreateNewDB.Size = new Size(246, 75);
            CreateNewDB.TabIndex = 2;
            CreateNewDB.Text = "Створити нову";
            CreateNewDB.UseVisualStyleBackColor = true;
            CreateNewDB.Click += CreateDb_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(366, 203);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 3;
            label1.Text = "або";
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(CreateNewDB);
            Controls.Add(NewDBName);
            Controls.Add(OpenDB);
            Name = "Welcome";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OpenDB;
        private TextBox NewDBName;
        private Button CreateNewDB;
        private Label label1;
    }
}