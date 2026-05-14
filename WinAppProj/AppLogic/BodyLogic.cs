using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinAppProj
{
    public partial class BodyUI
    {
        public class MatrixAction
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public string OldValue { get; set; }
            public string NewValue { get; set; }
        }

        public class MatrixOperation
        {
            public List<MatrixAction> Actions { get; set; } = new();
        }

        private Stack<MatrixOperation> undoStack = new();
        private Stack<MatrixOperation> redoStack = new();

        private void HistoryLog(string log)
        {
            historyBox.AppendText($"{DateTime.Now:HH:mm:ss} - {log}\r\n");
        }
        public void SumMatrix(object? sender, EventArgs e)
        {
            double sum = 0;

            for (int i = 1; i < matrixTable.RowCount; i++)
            {
                for (int j = 0; j < matrixTable.ColumnCount; j++)
                {
                    var ctrl = matrixTable.GetControlFromPosition(j, i);

                    if (ctrl is TextBox box && double.TryParse(box.Text, out double value))
                    {
                        sum += value;
                    }
                }
            }

            HistoryLog($"Suma macierzy = {sum}");
        }
        public void MinMatrix(object? sender, EventArgs e)
        {
            double min = double.MaxValue;

            for (int i = 1; i < matrixTable.RowCount; i++)
            {
                for (int j = 0; j < matrixTable.ColumnCount; j++)
                {
                    var ctrl = matrixTable.GetControlFromPosition(j, i);

                    if (ctrl is TextBox box && double.TryParse(box.Text, out double value))
                    {
                        if (value < min)
                        {
                            min = value;
                        }
                    }
                }
            }

            HistoryLog($"Wartość minimalna = {min}");
        }
        public void MaxMatrix(object? sender, EventArgs e)
        {
            double max = double.MinValue;

            for (int i = 1; i < matrixTable.RowCount; i++)
            {
                for (int j = 0; j < matrixTable.ColumnCount; j++)
                {
                    var ctrl = matrixTable.GetControlFromPosition(j, i);

                    if (ctrl is TextBox box && double.TryParse(box.Text, out double value))
                    {
                        if (value > max)
                        {
                            max = value;
                        }
                    }
                }
            }

            HistoryLog($"Wartość maksymalna = {max}");
        }
        public void AddNumberToMatrix(object? sender, EventArgs e)
        {
            if (!double.TryParse(inputNumber.Text, out double number))
            {
                return;
            }

            int row = (int)rowNumber.Value;
            int column = (int)columnNumber.Value;

            var box = GetCell(row, column);

            if (box != null)
            {
                string oldValue = box.Text;

                var op = new MatrixOperation();

                op.Actions.Add(new MatrixAction
                {
                    Row = row,
                    Column = column,
                    OldValue = oldValue,
                    NewValue = number.ToString()
                });

                box.Text = number.ToString();

                undoStack.Push(op);
                redoStack.Clear();

                HistoryLog($"Dodano {number} do ({row},{column})");
            }
        }
        public void ClearMatrix(object? sender, EventArgs e)
        {
            var operation = new MatrixOperation();

            for (int i = 1; i < matrixTable.RowCount; i++)
            {
                for (int j = 0; j < matrixTable.ColumnCount; j++)
                {
                    var box = matrixTable.GetControlFromPosition(j, i) as TextBox;

                    if (box != null)
                    {
                        operation.Actions.Add(new MatrixAction
                        {
                            Row = i,
                            Column = j + 1,
                            OldValue = box.Text,
                            NewValue = "0"
                        });

                        box.Text = "0";
                    }
                }
            }

            undoStack.Push(operation);
            redoStack.Clear();

            HistoryLog("Macierz została wyzerowana");
        }
        public void FillMatrix(object? sender, EventArgs e)
        {
            if (!double.TryParse(inputNumber.Text, out double number))
            {
                return;
            }

            var op = new MatrixOperation();

            for (int i = 1; i < matrixTable.RowCount; i++)
            {
                for (int j = 0; j < matrixTable.ColumnCount; j++)
                {
                    var box = matrixTable.GetControlFromPosition(j, i) as TextBox;

                    if (box == null) continue;

                    op.Actions.Add(new MatrixAction
                    {
                        Row = i,
                        Column = j + 1,
                        OldValue = box.Text,
                        NewValue = number.ToString()
                    });

                    box.Text = number.ToString();
                }
            }

            undoStack.Push(op);
            redoStack.Clear();

            HistoryLog($"Macierz została wypełniona = {number}");
        }
        private TextBox? GetCell(int row, int column)
        {
            return matrixTable.GetControlFromPosition(column - 1, row) as TextBox;
        }
        public void Undo(object? sender, EventArgs e)
        {
            if (undoStack.Count == 0)
            {
                return;
            }

            var operation = undoStack.Pop();

            foreach (var action in operation.Actions)
            {
                var box = matrixTable.GetControlFromPosition(action.Column - 1, action.Row) as TextBox;

                if (box != null)
                {
                    box.Text = action.OldValue;
                }
            }

            redoStack.Push(operation);

            foreach (var action in operation.Actions)
            {
                HistoryLog($"Cofnięcie ({action.Row},{action.Column}) {action.NewValue} -> {action.OldValue}");
            }
        }
        public void Redo(object? sender, EventArgs e)
        {
            if (redoStack.Count == 0)
            {
                return;
            }

            var operation = redoStack.Pop();

            foreach (var action in operation.Actions)
            {
                var box = matrixTable.GetControlFromPosition(action.Column - 1, action.Row) as TextBox;

                if (box != null)
                {
                    box.Text = action.NewValue;
                }
            }

            undoStack.Push(operation);

            foreach (var action in operation.Actions)
            {
                HistoryLog($"Ponowienie ({action.Row},{action.Column}) {action.OldValue} -> {action.NewValue}");
            }
        }
    }
}