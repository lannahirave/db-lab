using DB;

namespace WinFormsApp1;

public partial class TableForm : Form
{
    private Table _table;
    private bool _isRowBeingEdited;
    private bool _isRowBeingAdded;
    public TableForm(Table table)
    {
        InitializeComponent();
        _table = table;

        foreach (var column in _table.Columns)
        {
            dataGridView1.Columns.Add(column.Name, column.Name);
        }

        var idColumn = dataGridView1.Columns["$id"];
        if (idColumn != null)
        {
            idColumn.ReadOnly = true;
        }

        foreach (var row in _table.Rows)
        {
            var rowArray = new object[_table.Columns.Count];
            for(int i = 0; i < row.Count; i++)
            {
                var item = row.ElementAt(i);
                if (item is DateTime time)
                {
                    rowArray[i] = time.ToString("dd.MM.yyyy");
                }
                else
                {
                    rowArray[i] = item;
                }
            }
            dataGridView1.Rows.Add(rowArray);
        }

        dataGridView1.UserDeletingRow += DataGridView1_UserDeletingRow;
        dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
        dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
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
        if (!_isRowBeingEdited)
        {
            return;
        }

        if (_isRowBeingAdded)
        {
            _isRowBeingAdded = false;
            return;
        }

        if (e.RowIndex == dataGridView1.NewRowIndex - 1)
        {

            DataGridView1_RowsAdded(e);
            return;
        }
        
        // if id is null, then it's a new row
        if (string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[0].Value as string))
        {
            DataGridView1_RowsAdded(e);
            return;
        }

        var rowIndex = e.RowIndex;
        var columnIndex = e.ColumnIndex;

        var modifiedValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value;
        
        // check if value can be cast to type of column
        var column = _table.Columns.Skip(columnIndex).First();
        if (!column.TryCast(modifiedValue, out var parsedValue))
        {
            // Show error message and paint the cell red for 1 second
            MessageBox.Show($@"Cannot cast {modifiedValue} to {column.Type}");
            dataGridView1.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Red;
            Task.Delay(1000).ContinueWith(_ =>
            {
                dataGridView1.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.White;
            });
            return;
        }
        
        var rowData = _table.Rows.ElementAt(rowIndex);
        var columnName = column.Name;
        var newCellDictionary = new Dictionary<string, object?>();
        newCellDictionary[columnName] = parsedValue;
        var id = (int)rowData[0];
        try
        {
            _table.UpdateRow(id, newCellDictionary);
        }
        catch (InvalidCastException exp)
        {
            // Show error message and paint the cell red for 1 second
            MessageBox.Show(exp.Message);
            dataGridView1.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Red;
            Task.Delay(1000).ContinueWith(_ =>
            {
                dataGridView1.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.White;
            });
        }
    }

    private void DataGridView1_RowsAdded(DataGridViewCellEventArgs e)
    {
        _isRowBeingAdded = true;
        var newRow = new Dictionary<string, object?>();
        for (int i = 1; i < _table.Columns.Count; ++i)
        {
            var column = _table.Columns.ElementAt(i);
            var modifiedValue = dataGridView1.Rows[e.RowIndex].Cells[i].Value;
            if (!column.TryCast(modifiedValue, out var parsedValue))
            {
                // Show error message and paint the cell red for 1 second
                MessageBox.Show($@"Cannot cast {modifiedValue} to {column.Type}");
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                Task.Delay(1000).ContinueWith(_ =>
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                });
                _isRowBeingAdded = false;
                return;
            }
            var columnName = column.Name;
            newRow[columnName] = parsedValue;
        }

        try
        {
            int id = _table.AddRow(newRow);
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = id;

        }
        catch (Exception exp)
        {
            // Show error message and paint the cell red for 1 second
            MessageBox.Show(exp.Message);
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
            Task.Delay(1000).ContinueWith(_ =>
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            });
        }
        finally
        {
            _isRowBeingAdded = false;
        }
    }
    
    private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        _isRowBeingEdited = true;
    }

    private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        _isRowBeingEdited = false;
    }
}