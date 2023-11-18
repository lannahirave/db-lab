namespace WinFormsApp1
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
            tableLayoutPanel1 = new TableLayoutPanel();
            SuspendLayout();
            // 
            // dbInfo
            // 
            dbInfo.Enabled = false;
            dbInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            dbInfo.Location = new Point(237, 12);
            dbInfo.Multiline = true;
            dbInfo.Name = "dbInfo";
            dbInfo.Size = new Size(306, 86);
            dbInfo.TabIndex = 0;
            // 
            // addTableToDb
            // 
            addTableToDb.Location = new Point(292, 104);
            addTableToDb.Name = "addTableToDb";
            addTableToDb.Size = new Size(196, 23);
            addTableToDb.TabIndex = 1;
            addTableToDb.Text = "Створити нову таблицю";
            addTableToDb.UseVisualStyleBackColor = true;
            addTableToDb.Click += CreateTable;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Location = new Point(237, 133);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(306, 94);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(addTableToDb);
            Controls.Add(dbInfo);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox dbInfo;
        private Button addTableToDb;
        private TableLayoutPanel tableLayoutPanel1;
    }
}