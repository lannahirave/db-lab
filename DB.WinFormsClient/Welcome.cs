using DB.WinFormsClient.DBAdapter;

namespace DB.WinFormsClient;

public partial class Welcome : Form
{
    public Welcome()
    {
        InitializeComponent();
    }


    private async void CreateDb_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NewDBName.Text))
        {
            MessageBox.Show("Please enter a database name.");
            return;
        }

        var dbName = NewDBName.Text;
        var saveFileDialog = new SaveFileDialog
        {
            Filter = "Database files (*.db)|*.db",
            Title = "Save Database",
            InitialDirectory =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDatabases")
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            var dbPath = saveFileDialog.FileName;

            try
            {
                var db = await Db.CreateAsync(Utility.Filesystem, dbPath, dbName);
                OpenMainForm(db);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private async void OpenDB_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "Database files (*.db)|*.db",
            Title = "Select db file",
            InitialDirectory =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDatabases")
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
            try
            {
                var db = await Db.LoadAsync(Utility.Filesystem, openFileDialog.FileName);
                OpenMainForm(db);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }

    private void OpenMainForm(Db db)
    {
        IBaseDb dbAdapter = new LocalDb(db);
        var mainForm = new MainForm(dbAdapter);
        mainForm.Show();
    }


}