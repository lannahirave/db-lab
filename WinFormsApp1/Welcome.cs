using DB;

namespace WinFormsApp1
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDatabases")
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var dbPath = saveFileDialog.FileName;

                try
                {
                    var db = await Db.CreateAsync(Utility.Filesystem, dbPath, dbName);
                    //MessageBox.Show("Database created successfully.");

                  
                    
                    var mainForm = new MainForm(db);
                    mainForm.Show();
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
                Title = "Селект датабазу",
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDatabases")
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                try
                {

                    var dbName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    var db = await Db.LoadAsync(Utility.Filesystem, openFileDialog.FileName);
                    //MessageBox.Show("Датабаза завантажена.");
                    var mainForm = new MainForm(db);
                    mainForm.Show();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return; 
                }

                
                
                
            }
        }

    }
}