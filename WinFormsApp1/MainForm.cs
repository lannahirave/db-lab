using DB;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private Db _db;
        public MainForm(Db db)
        {
            InitializeComponent();
            _db = db;
        }

        private async void CreateTable(object sender, EventArgs e)
        {
            var form = new CreateTable();
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var text = "Database: " + _db.Schema.Name;
            dbInfo.AppendText(text);
            dbInfo.AppendText(Environment.NewLine);
            text = "Tables: " + _db.Schema.Tables.Count;
            dbInfo.AppendText(text);

        }
    }
}
