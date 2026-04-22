using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppProj
{
    public class Body : UserControl
    {
        public Body()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Top;
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.AutoSize = true;

            // Number
            Label textInput = new Label();
            textInput.Text = "Wprowadź liczbę";

            TextBox input = new TextBox();
            input.Width = 150;

            // Row
            Label textRow = new Label();
            textRow.Text = "Numer wiersza";

            NumericUpDown row = new NumericUpDown();

            // Column
            Label textColumn = new Label();
            textColumn.Text = "Numer kolumny";

            NumericUpDown column = new NumericUpDown();

            // Add
            panel.Controls.Add(textInput);
            panel.Controls.Add(input);
            panel.Controls.Add(textRow);
            panel.Controls.Add(row);
            panel.Controls.Add(textColumn);
            panel.Controls.Add(column);

            this.Controls.Add(panel);
        }
    }
}