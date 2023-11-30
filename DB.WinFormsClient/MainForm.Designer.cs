namespace DB.WinFormsClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            dbInfo = new TextBox();
            addTableToDb = new Button();
            tableLayoutWhereTablesDisplay = new TableLayoutPanel();
            CloseDb = new Button();
            SuspendLayout();
            // 
            // dbInfo
            // 
            dbInfo.Enabled = false;
            dbInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            dbInfo.Location = new Point(172, 12);
            dbInfo.Multiline = true;
            dbInfo.Name = "dbInfo";
            dbInfo.Size = new Size(306, 86);
            dbInfo.TabIndex = 0;
            // 
            // addTableToDb
            // 
            addTableToDb.Location = new Point(220, 104);
            addTableToDb.Name = "addTableToDb";
            addTableToDb.Size = new Size(196, 23);
            addTableToDb.TabIndex = 1;
            addTableToDb.Text = "Create new table";
            addTableToDb.UseVisualStyleBackColor = true;
            addTableToDb.Click += CreateTable;
            // 
            // tableLayoutWhereTablesDisplay
            // 
            tableLayoutWhereTablesDisplay.AutoScroll = true;
            tableLayoutWhereTablesDisplay.ColumnCount = 2;
            tableLayoutWhereTablesDisplay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.7346039F));
            tableLayoutWhereTablesDisplay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.2653961F));
            tableLayoutWhereTablesDisplay.Location = new Point(172, 133);
            tableLayoutWhereTablesDisplay.Name = "tableLayoutWhereTablesDisplay";
            tableLayoutWhereTablesDisplay.RowCount = 1;
            tableLayoutWhereTablesDisplay.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutWhereTablesDisplay.Size = new Size(405, 182);
            tableLayoutWhereTablesDisplay.TabIndex = 2;
            // 
            // CloseDb
            // 
            CloseDb.Location = new Point(250, 350);
            CloseDb.Name = "CloseDb";
            CloseDb.Size = new Size(146, 23);
            CloseDb.TabIndex = 4;
            CloseDb.Text = "Close db";
            CloseDb.UseVisualStyleBackColor = true;
            CloseDb.Click += CloseDb_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(679, 450);
            Controls.Add(CloseDb);
            Controls.Add(tableLayoutWhereTablesDisplay);
            Controls.Add(addTableToDb);
            Controls.Add(dbInfo);
            Name = "MainForm";
            Text = "Database viewer";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox dbInfo;
        private Button addTableToDb;
        private TableLayoutPanel tableLayoutWhereTablesDisplay;
        private Button CloseDb;
    }
}