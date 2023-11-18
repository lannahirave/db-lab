namespace WinFormsApp1
{
    partial class CreateTable
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
            _tableNameTextBox = new TextBox();
            _addColumnButton = new Button();
            _createTableButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            comboBox1 = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // _tableNameTextBox
            // 
            _tableNameTextBox.Location = new Point(12, 12);
            _tableNameTextBox.Name = "_tableNameTextBox";
            _tableNameTextBox.PlaceholderText = "Назва таблиці";
            _tableNameTextBox.Size = new Size(398, 23);
            _tableNameTextBox.TabIndex = 1;
            // 
            // _addColumnButton
            // 
            _addColumnButton.Location = new Point(167, 352);
            _addColumnButton.Name = "_addColumnButton";
            _addColumnButton.Size = new Size(75, 23);
            _addColumnButton.TabIndex = 2;
            _addColumnButton.Text = "Add Column";
            _addColumnButton.Click += AddColumnButton_Click;
            // 
            // _createTableButton
            // 
            _createTableButton.Location = new Point(153, 381);
            _createTableButton.Name = "_createTableButton";
            _createTableButton.Size = new Size(100, 23);
            _createTableButton.TabIndex = 3;
            _createTableButton.Text = "Create Table";
            _createTableButton.Click += CreateTableButton_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Location = new Point(19, 43);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Size = new Size(391, 303);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.Controls.Add(comboBox1, 0, 1);
            tableLayoutPanel2.Controls.Add(label2, 1, 0);
            tableLayoutPanel2.Controls.Add(button1, 2, 1);
            tableLayoutPanel2.Controls.Add(textBox1, 1, 1);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(385, 48);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Integer", "Real", "Char", "String", "DateTime", "DateInterval" });
            comboBox1.Location = new Point(3, 23);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 6;
            label2.Text = "Назва колонки";
            // 
            // button1
            // 
            button1.Location = new Point(259, 23);
            button1.Name = "button1";
            button1.Size = new Size(75, 22);
            button1.TabIndex = 6;
            button1.Text = "Видалити";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(131, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(122, 23);
            textBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 6;
            label1.Text = "Тип колонки";
            // 
            // CreateTable
            // 
            ClientSize = new Size(423, 416);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(_tableNameTextBox);
            Controls.Add(_addColumnButton);
            Controls.Add(_createTableButton);
            Name = "CreateTable";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ComboBox comboBox1;
        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
    }
}