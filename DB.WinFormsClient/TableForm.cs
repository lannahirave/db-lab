using DB.WinFormsClient.DBAdapter;

namespace DB.WinFormsClient;

public partial class TableForm : Form
{
    private bool _isRowBeingAdded;
    private bool _isRowBeingEdited;
    private readonly IBaseDb _db;
    private readonly string _tableName;
    private List<ColumnScheme> _columnsSchemes = new();

    public TableForm(IBaseDb db, string tableName)
    {
        InitializeComponent();
        _db = db;
        _tableName = tableName;
        
    }

    public async Task InitializeDataGridView1()
    {
        var columns = await _db.GetColumns(_tableName);
        _columnsSchemes = columns;
        foreach (var column in columns) 
            dataGridView1.Columns.Add(column.Name, column.Name);

        var idColumn = dataGridView1.Columns["$id"];
        if (idColumn != null) idColumn.ReadOnly = true;
        var rows = await _db.GetRows(_tableName);
        foreach (var row in rows)
        {
            var rowArray = new object[columns.Count];
            for (var i = 0; i < row.Count; i++)
            {
                var item = row.ElementAt(i);
                if (item is DateTime time)
                    rowArray[i] = time.ToString("dd.MM.yyyy");
                else if (item is DateInterval interval)
                    rowArray[i] = interval.ToString();
                else
                    rowArray[i] = item;
            }

            dataGridView1.Rows.Add(rowArray);
        }

        dataGridView1.UserDeletingRow += DataGridView1_UserDeletingRow;
        dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
        dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
    }

    private void DataGridView1_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
    {
        if (e.Row != null && e.Row.Cells[0].Value != null)
        {
            var rowIndexInFirstColumn= e.Row.Cells[0].Value;
            var id = Int32.TryParse(rowIndexInFirstColumn.ToString(), out var idParsed) ? idParsed : throw new Exception("Id is null");
            _db.DeleteRow(_tableName, id);
        }
    }

    private async void DataGridView1_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (!_isRowBeingEdited) return;

        if (_isRowBeingAdded)
        {
            _isRowBeingAdded = false;
            return;
        }

        bool twoNewRows;
        // check if two last rows has no $id    
        if (dataGridView1.NewRowIndex == dataGridView1.Rows.Count - 1)
        {
            var lastRow = dataGridView1.Rows[dataGridView1.NewRowIndex - 1];
            var lastRowId = lastRow.Cells[0].Value;
            var lastRowIdIsNull = string.IsNullOrEmpty(lastRowId as string);
            var lastRowIsEmpty = lastRow.Cells.Cast<DataGridViewCell>().All(cell => string.IsNullOrEmpty(cell.Value as string));
            twoNewRows = lastRowIdIsNull && lastRowIsEmpty;
        }
        else
        {
            twoNewRows = false;
        }
        
        if (e.RowIndex == dataGridView1.NewRowIndex - 1 && twoNewRows)
        {
            DataGridView1_RowsAdded(e);
            return;
        }

        // if id is null, then it's a new row
        if (string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString()))
        {
            DataGridView1_RowsAdded(e);
            return;
        }

        var rowIndex = e.RowIndex;
        var columnIndex = e.ColumnIndex;

        var modifiedValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value;

        // check if value can be cast to type of column
        var columns = await _db.GetColumns(_tableName);
        var column = columns.Skip(columnIndex).First();
        if (!column.TryCast(modifiedValue, out var parsedValue))
        {
            // Show error message and paint the cell red for 1 second
            MessageBox.Show($@"Cannot cast {modifiedValue} to {column.Type}");
            dataGridView1.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Red;
            await Task.Delay(1000).ContinueWith(_ =>
            {
                dataGridView1.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.White;
            });
            return;
        }
       
        var columnName = column.Name;
        var newCellDictionary = new Dictionary<string, object>
        {
            [columnName] = parsedValue
        };
        // add all others column and their values
        for (var i = 1; i < _columnsSchemes.Count; ++i)
        {
            var modifiedValue2 = dataGridView1.Rows[rowIndex].Cells[i].Value.ToString();
            if (string.IsNullOrEmpty(modifiedValue2))
            {
                _isRowBeingAdded = false;
                return;
            }

            var column2 = _columnsSchemes.ElementAt(i);
            if (!column2.TryCast(modifiedValue2, out var parsedValue2))
            {
                // Show error message and paint the cell red for 1 second
                MessageBox.Show($@"Cannot cast {modifiedValue2} to {column2.Type}");
                dataGridView1.Rows[rowIndex].Cells[i].Style.BackColor = Color.Red;
                await Task.Delay(1000).ContinueWith(_ =>
                {
                    dataGridView1.Rows[rowIndex].Cells[i].Style.BackColor = Color.White;
                });
                return;
            }

            var columnName2 = column2.Name;
            newCellDictionary[columnName2] = parsedValue2;
        }
        var id = Int32.TryParse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), out var idParsed) ? idParsed : throw new Exception("Id is null");
        try
        {
            await _db.UpdateRow(_tableName, id, newCellDictionary);
        }
        catch (InvalidCastException exp)
        {
            // Show error message and paint the cell red for 1 second
            MessageBox.Show(exp.Message);
            dataGridView1.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Red;
            await Task.Delay(1000).ContinueWith(_ =>
            {
                dataGridView1.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.White;
            });
        }
    }

    private async void DataGridView1_RowsAdded(DataGridViewCellEventArgs e)
    {
        _isRowBeingAdded = true;
        var newRow = new Dictionary<string, object>();
        for (var i = 1; i < _columnsSchemes.Count; ++i)
        {
            var modifiedValue = dataGridView1.Rows[e.RowIndex].Cells[i].Value;
            if (string.IsNullOrEmpty(modifiedValue as string))
            {
                _isRowBeingAdded = false;
                return;
            }
        }
        for (var i = 1; i < _columnsSchemes.Count; ++i)
        {
            var column = _columnsSchemes.ElementAt(i);
            var modifiedValue = dataGridView1.Rows[e.RowIndex].Cells[i].Value;
            if (!column.TryCast(modifiedValue, out var parsedValue))
            {
                // Show error message and paint the cell red for 1 second
                MessageBox.Show($@"Cannot cast {modifiedValue} to {column.Type}");
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                await Task.Delay(1000).ContinueWith(_ =>
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
            var id = await _db.AddRow(_tableName, newRow);
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = id;
        }
        catch (Exception exp)
        {
            // Show error message and paint the cell red for 1 second
            MessageBox.Show(exp.Message);
            foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
            {
                cell.Style.BackColor = Color.Red;
            }
            await Task.Delay(1000).ContinueWith(_ =>
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            });
        }
        finally
        {
            _isRowBeingAdded = false;
        }
    }

    private void DataGridView1_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
    {
        _isRowBeingEdited = true;
    }

    private void DataGridView1_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
    {
        _isRowBeingEdited = false;
    }
}