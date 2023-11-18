using DB;

namespace WinFormsApp1;

public partial class TableForm : Form
{
    private Table _table;
    private bool isRowBeingEdited = false;
    public TableForm(Table table)
    {
        InitializeComponent();
        _table = table;
        foreach (var column in _table.Columns) dataGridView1.Columns.Add(column.Name, column.Name);

        var idColumn = dataGridView1.Columns["$id"];
        if (idColumn != null) idColumn.ReadOnly = true;

        foreach (var row in _table.Rows) dataGridView1.Rows.Add(row.ToArray());
        dataGridView1.UserDeletingRow += DataGridView1_UserDeletingRow;
        dataGridView1.CellEndEdit += DataGridView1_UserAddedRow;
        //dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        dataGridView1.RowValidated += DataGridView1_RowValidated;
    }

    private void DataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
    {
        var rowIndex = e.Row.Index;
        var rowData = _table.Rows.ElementAt(rowIndex);
        var id = (int)rowData[0];
        _table.RemoveRow(id);
    }

    private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (dataGridView1.Rows[e.RowIndex].IsNewRow)
        {
            return;
        }
        var rowIndex = e.RowIndex;
        var columnIndex = e.ColumnIndex;

        var modifiedValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value;
        var rowData = _table.Rows.ElementAt(rowIndex);
        var columnName = dataGridView1.Columns[columnIndex].Name;
        var newCellDictionary = new Dictionary<string, object?>();
        newCellDictionary[columnName] = modifiedValue;
        var id = (int)rowData[0];
        _table.UpdateRow(id, newCellDictionary);
    }
    
    
    private void DataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex != dataGridView1.NewRowIndex)
        {
            var rowIndex = e.RowIndex;
            var columnIndex = e.ColumnIndex;

            var modifiedValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value;
            var rowData = _table.Rows.ElementAt(rowIndex);
            var columnName = dataGridView1.Columns[columnIndex].Name;
            var newCellDictionary = new Dictionary<string, object?>();
            newCellDictionary[columnName] = modifiedValue;
            var id = (int)rowData[0];
            _table.UpdateRow(id, newCellDictionary);
        }
    }
    
    private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        isRowBeingEdited = true;
    }

    private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        isRowBeingEdited = false;
    }

    
    private void DataGridView1_UserAddedRow(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex != dataGridView1.Rows.Count - 1 && !dataGridView1.Rows[e.RowIndex].IsNewRow)
        {
            return;
        }
        var newRow = new Dictionary<string, object?>();
        for(int i = 1; i < _table.Columns.Count; ++i)
        {
            var columnName = dataGridView1.Columns[i].Name;
            newRow[columnName] = dataGridView1.Rows[e.RowIndex].Cells[i].Value;
        }
        _table.AddRow(newRow);
    }
}