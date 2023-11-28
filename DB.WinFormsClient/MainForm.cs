using DB.WinFormsClient.DBAdapter;

namespace DB.WinFormsClient;

public partial class MainForm : Form
{
    private readonly IBaseDb _db;

    public MainForm(IBaseDb dbAdapter)
    {
        InitializeComponent();
        _db = dbAdapter;
    }

    private void CreateTable(object sender, EventArgs e)
    {
        var form = new CreateTable(_db);
        form.TableCreated += CreateTableForm_TableCreated;
        form.Show();
    }

    private void CreateTableForm_TableCreated(object? sender, EventArgs e)
    {
        RefreshMainForm();
    }

    private async void RefreshMainForm()
    {
        dbInfo.Clear();
        var text = "Database: " + _db.DbName;
        dbInfo.AppendText(text);
        dbInfo.AppendText(Environment.NewLine);
        var tables = await _db.GetTables();
        text = "Tables: " + tables.Count;
        dbInfo.AppendText(text);
        tableLayoutWhereTablesDisplay.Controls.Clear();
        // create a new table layout panel
        foreach (var table in tables)
        {
            var tableButton = new Button();
            tableButton.Text = table;
            tableButton.Click += (_, _) => OpenTable(table);
            tableLayoutWhereTablesDisplay.Controls.Add(tableButton);
            var deleteButton = new Button();
            deleteButton.Text = @"Delete";
            deleteButton.Click += async (_, _) => await DeleteTable(table);
            tableLayoutWhereTablesDisplay.Controls.Add(deleteButton);
        }

        var tableLayout = new TableLayoutPanel();
        tableLayout.ColumnCount = 2;
    }

    private async void OpenTable(string name)
    {
        var form = new TableForm(_db, name);
        await form.InitializeDataGridView1();
        form.Show();
    }

    private async Task DeleteTable(string name)
    {
        await _db.DeleteTable(name);
        RefreshMainForm();
    }


    private void CloseDb_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        RefreshMainForm();
    }
}