using DB.WinFormsClient.DBAdapter;

namespace DB.WinFormsClient;

public partial class CreateTable : Form
{
    private Button _addColumnButton;
    private Button _createTableButton;
    private readonly IBaseDb _db;
    private TextBox _tableNameTextBox;

    public CreateTable(IBaseDb db)
    {
        _db = db;
        InitializeComponent();
    }

    public event EventHandler TableCreated;


    private void AddColumnButton_Click(object sender, EventArgs e)
    {
        var comboBoxReplica = new ComboBox();

        // comboBox1

        var items = _db.GetTypes();
        comboBoxReplica.FormattingEnabled = true;
        object[] itemsReplica = items.Select(x => x.ToString()).Cast<object>().ToArray();
        comboBoxReplica.Items.AddRange(itemsReplica);
        comboBoxReplica.Location = new Point(3, 23);
        comboBoxReplica.Name = "comboBox1";
        comboBoxReplica.Size = new Size(121, 23);
        comboBoxReplica.TabIndex = 6;
        comboBoxReplica.SelectedIndex = 0;
        // 
        // label2
        // 
        var label2Replica = new Label();
        label2Replica.AutoSize = true;
        label2Replica.Location = new Point(131, 0);
        label2Replica.Name = "label2";
        label2Replica.Size = new Size(89, 15);
        label2Replica.TabIndex = 6;
        label2Replica.Text = "Column name";
        // 
        // button1
        // 
        var button1Replica = new Button();
        button1Replica.Location = new Point(259, 23);
        button1Replica.Name = "button1";
        button1Replica.Size = new Size(75, 22);
        button1Replica.TabIndex = 6;
        button1Replica.Text = "Delete";
        button1Replica.UseVisualStyleBackColor = true;

        // 
        // textBox1
        // 
        var textBox1Replica = new TextBox();

        textBox1Replica.Location = new Point(131, 23);
        textBox1Replica.Name = "textBox1";
        textBox1Replica.Size = new Size(122, 23);
        textBox1Replica.TabIndex = 6;
        // 
        // label1
        // 
        var label1Replica = new Label();
        label1Replica.AutoSize = true;
        label1Replica.Location = new Point(3, 0);
        label1Replica.Name = "label1";
        label1Replica.Size = new Size(77, 15);
        label1Replica.TabIndex = 6;
        label1Replica.Text = "Column type";


        var tableLayoutRowReplica = new TableLayoutPanel();
        tableLayoutRowReplica.ColumnCount = 3;
        tableLayoutRowReplica.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
        tableLayoutRowReplica.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
        tableLayoutRowReplica.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
        tableLayoutRowReplica.Controls.Add(comboBoxReplica, 0, 1);
        tableLayoutRowReplica.Controls.Add(label2Replica, 1, 0);
        tableLayoutRowReplica.Controls.Add(button1Replica, 2, 1);
        tableLayoutRowReplica.Controls.Add(textBox1Replica, 1, 1);
        tableLayoutRowReplica.Controls.Add(label1Replica, 0, 0);
        tableLayoutRowReplica.Location = new Point(3, 3);
        tableLayoutRowReplica.Name = "tableLayoutRowReplica";
        tableLayoutRowReplica.RowCount = 2;
        tableLayoutRowReplica.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutRowReplica.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutRowReplica.Size = new Size(385, 48);
        tableLayoutRowReplica.TabIndex = 5;
        tableLayoutPanel1.RowCount++;
        tableLayoutPanel1.Controls.Add(tableLayoutRowReplica, 0, tableLayoutPanel1.RowCount - 1);
        Console.Write(tableLayoutPanel1.RowCount);
        button1Replica.Click += (_, _) => { tableLayoutPanel1.Controls.Remove(tableLayoutRowReplica); };
    }

    private async void CreateTableButton_Click(object sender, EventArgs e)
    {
        var tableName = _tableNameTextBox.Text;

        var controlsFromTableLayoutPanel = tableLayoutPanel1.Controls;
        var columns = new List<ColumnScheme>();

        foreach (var controlObject in controlsFromTableLayoutPanel)
        {
            var control = (TableLayoutPanel)controlObject;
            var comboBox = (ComboBox)control.Controls[0];
            var textBox = (TextBox)control.Controls[3];
            var columnName = textBox.Text;
            var columnType = comboBox.Text;
            var column = new ColumnScheme(columnName, Enum.Parse<ColumnType>(columnType));
            columns.Add(column);
        }

        await _db.CreateTable(tableName, columns);
        Close();
        OnTableCreated(EventArgs.Empty);
    }

    protected virtual void OnTableCreated(EventArgs e)
    {
        TableCreated?.Invoke(this, e);
    }
}