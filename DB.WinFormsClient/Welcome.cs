using CoreRPC;
using CoreRPC.Transport.NamedPipe;
using DB.RPC.Common;
using DB.WinFormsClient.DBAdapter;

namespace DB.WinFormsClient;

public partial class Welcome : Form
{
    public Welcome()
    {
        InitializeComponent();
    }

    private async void ConnectToRPC_Click(object sender, EventArgs e)
    {
        var pipeName = RPCPipeName.Text;
        if (string.IsNullOrWhiteSpace(pipeName))
        {
            MessageBox.Show(@"Please enter a pipe name.");
            return;
        }
        var transport = new NamedPipeClientTransport(pipeName);

        var proxy = new Engine().CreateProxy<IDbService>(transport);
        
        IBaseDb dbAdapter = new RpcDb(proxy);
        
        
        
        OpenMainFormIDbAdapter(dbAdapter);
    }

    private async void ConnectTogRPC_Click(object sender, EventArgs e)
    {
        var host = gRPCHost.Text;
        var port = gRPCPort.Text;
        if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(port))
        {
            MessageBox.Show(@"Please enter a host and a port.");
            return;
        }
        
    }
    private async void CreateLocalDb_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NewDBName.Text))
        {
            MessageBox.Show(@"Please enter a database name.");
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
                OpenMainFormLocalDb(db);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private async void OpenLocalDB_Click(object sender, EventArgs e)
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
                OpenMainFormLocalDb(db);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }

    private void OpenMainFormLocalDb(Db db)
    {
        IBaseDb dbAdapter = new LocalDb(db);
        OpenMainFormIDbAdapter(dbAdapter);
    }
    
    private void OpenMainFormIDbAdapter(IBaseDb dbAdapter)
    {
        var mainForm = new MainForm(dbAdapter);
        mainForm.Show();
    }


}