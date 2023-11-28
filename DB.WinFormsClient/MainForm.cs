using DB;

namespace WinFormsApp1;

public partial class MainForm : Form
{
    private readonly Db _db;

    public MainForm(Db db)
    {
        InitializeComponent();
        _db = db;
        SaveDb.Click += async (sender, e) => { await SaveDb_Click(); };
    }

    private async void CreateTable(object sender, EventArgs e)
    {
        var form = new CreateTable(_db);
        form.TableCreated += CreateTableForm_TableCreated;
        form.Show();
    }

    private void CreateTableForm_TableCreated(object sender, EventArgs e)
    {
        // This method will be called when the table is created
        // Update your main form here
        // For example, you might want to refresh a DataGridView or perform any other necessary updates
        RefreshMainForm();
    }

    private void RefreshMainForm()
    {
        dbInfo.Clear();
        var text = "Database: " + _db.Schema.Name;
        dbInfo.AppendText(text);
        dbInfo.AppendText(Environment.NewLine);
        text = "Tables: " + _db.Schema.Tables.Count;
        dbInfo.AppendText(text);
        tableLayoutWhereTablesDisplay.Controls.Clear();
        // create a new table layout panel
        foreach (var table in _db.Schema.Tables)
        {
            var tableButton = new Button();
            tableButton.Text = table.Key;
            tableButton.Click += (sender, e) => OpenTable(table.Key);
            tableLayoutWhereTablesDisplay.Controls.Add(tableButton);
            var deleteButton = new Button();
            deleteButton.Text = "Видалити";
            deleteButton.Click += (sender, e) => DeleteTable(table.Key);
            tableLayoutWhereTablesDisplay.Controls.Add(deleteButton);
        }

        var tableLayout = new TableLayoutPanel();
        tableLayout.ColumnCount = 2;
    }

    private void OpenTable(string name)
    {
        var table = _db.Schema.Tables[name];
        var form = new TableForm(table);
        form.Show();
    }

    private void DeleteTable(string name)
    {
        _db.RemoveTable(name);
        RefreshMainForm();
    }

    private async Task SaveDb_Click()
    {
        var fileSystem = Utility.Filesystem;
        await _db.SaveAsync(fileSystem);
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