using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppProj
{
    public partial class BodyUI : UserControl
    {
        private TextBox inputNumber = new TextBox();
        private NumericUpDown columnNumber = new NumericUpDown();
        private NumericUpDown rowNumber = new NumericUpDown();
        private TableLayoutPanel matrixTable = new TableLayoutPanel();
        private TextBox historyBox = new TextBox();

        public BodyUI()
        {
            this.Dock = DockStyle.Fill;
            this.AutoSize = true;

            TableLayoutPanel layout = new TableLayoutPanel()
            {
                RowCount = 5,
                ColumnCount = 1,
                Dock = DockStyle.Fill
            };

            layout.Controls.Add(CreateFirstRow(), 0, 0);
            layout.Controls.Add(CreateSecondRow(), 0, 1);
            layout.Controls.Add(CreateThirdRow(), 0, 2);
            layout.Controls.Add(CreateFourthRow(), 0, 3);
            layout.Controls.Add(CreateFifthRow(), 0, 4);

            this.Controls.Add(layout);
        }

        Control CreateFirstRow()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Top;
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.AutoSize = true;

            // Number
            Label textInput = new Label();
            textInput.Text = "Wprowadź liczbę";
            inputNumber.Width = 150;

            // Row
            Label textRow = new Label();
            textRow.Text = "Numer wiersza";
            rowNumber.Minimum = 1;
            rowNumber.Maximum = 5;

            // Column
            Label textColumn = new Label();
            textColumn.Text = "Numer kolumny";
            columnNumber.Minimum = 1;
            columnNumber.Maximum = 5;

            // Add
            panel.Controls.Add(textInput);
            panel.Controls.Add(inputNumber);
            panel.Controls.Add(textRow);
            panel.Controls.Add(rowNumber);
            panel.Controls.Add(textColumn);
            panel.Controls.Add(columnNumber);

            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Margin = new Padding(0, 30, 0, 30);
            }

            textInput.Margin = new Padding(37, 33, 0, 30);
            textRow.Margin = new Padding(37, 33, 0, 30);
            textColumn.Margin = new Padding(37, 33, 0, 30);

            return panel;
        }
        Control CreateSecondRow()
        {
            // Container
            FlowLayoutPanel secondRowContainer = new FlowLayoutPanel();
            secondRowContainer.FlowDirection = FlowDirection.LeftToRight;
            secondRowContainer.AutoSize = true;

            // Table
            matrixTable.RowCount = 6;
            matrixTable.ColumnCount = 5;
            matrixTable.AutoSize = true;

            TextBox CreateTextBox(string text, Color color)
            {
                return new TextBox
                {
                    Text = text,
                    BackColor = color,
                    Size = new Size(100, 20),
                    ReadOnly = true,
                    TextAlign = HorizontalAlignment.Center
                };
            }

            matrixTable.Controls.Add(CreateTextBox("1", Color.LightGray), 0, 0);
            matrixTable.Controls.Add(CreateTextBox("2", Color.LightGray), 1, 0);
            matrixTable.Controls.Add(CreateTextBox("3", Color.LightGray), 2, 0);
            matrixTable.Controls.Add(CreateTextBox("4", Color.LightGray), 3, 0);
            matrixTable.Controls.Add(CreateTextBox("5", Color.LightGray), 4, 0);

            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrixTable.Controls.Add(CreateTextBox("0", Color.White), j, i);
                }
            }

            // Buttons
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
            buttonPanel.FlowDirection = FlowDirection.TopDown;
            buttonPanel.AutoSize = true;

            Button CreateButton(string text, Image image)
            {
                return new Button
                {
                    Text = text,
                    Image = new Bitmap(image, new Size(20, 20)),
                    ImageAlign = ContentAlignment.MiddleLeft,
                    TextAlign = ContentAlignment.MiddleRight,
                    Size = new Size(120, 30)
                };
            }

            Button addButton = CreateButton("Dodaj", Image.FromFile("..\\\\..\\\\..\\\\icons\\\\add.png"));
            addButton.Margin = new Padding(3, 15, 0, 0);
            addButton.Click += AddNumberToMatrix;
            buttonPanel.Controls.Add(addButton);

            Button clearButton = CreateButton("Wyzeruj", Image.FromFile("..\\\\..\\\\..\\\\icons\\\\empty.png"));
            clearButton.Click += ClearMatrix;
            buttonPanel.Controls.Add(clearButton);

            Button fillButton = CreateButton("Wypełnij", Image.FromFile("..\\\\..\\\\..\\\\icons\\\\fill.png"));
            fillButton.Click += FillMatrix;
            buttonPanel.Controls.Add(fillButton);

            buttonPanel.Controls.Add(
                CreateButton("Zapisz", Image.FromFile("..\\\\..\\\\..\\\\icons\\\\save.png"))
            );

            matrixTable.Margin = new Padding(80, 0, 60, 0);

            secondRowContainer.Controls.Add(matrixTable);
            secondRowContainer.Controls.Add(buttonPanel);

            return secondRowContainer;
        }
        Control CreateThirdRow()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.AutoSize = true;

            // Text
            Label label = new Label();
            label.Text = "Obliczenia";
            label.Margin = new Padding(100, 7, 0, 0);
            label.Size = new Size(65, 20);

            // ComboBox
            ComboBox comboBox = new ComboBox();
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox.Items.Add("Wybierz operacje");
            comboBox.Items.Add("Suma");
            comboBox.Items.Add("Min");
            comboBox.Items.Add("Max");

            comboBox.SelectedIndex = 0;

            // Button
            Button button = new Button();
            button.Text = "Oblicz";

            Image btnImage = Image.FromFile("..\\..\\..\\icons\\solve.png");

            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.TextAlign = ContentAlignment.MiddleRight;
            button.Image = new Bitmap(btnImage, new Size(20, 20));
            button.Size = new Size(100, 30);
            button.Margin = new Padding(10, 0, 0, 0);

            button.Click += (s, e) =>
            {
                string wybor = comboBox.SelectedItem?.ToString();

                switch (wybor)
                {
                    case "Suma":
                        SumMatrix(s, e);
                        break;

                    case "Min":
                        MinMatrix(s, e);
                        break;

                    case "Max":
                        MaxMatrix(s, e);
                        break;

                    default:
                        MessageBox.Show("Nie wybrano operacji");
                        break;
                }
            };

            panel.Controls.Add(label);
            panel.Controls.Add(comboBox);
            panel.Controls.Add(button);

            return panel;
        }
        Control CreateFourthRow()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.FlowDirection = FlowDirection.TopDown;
            panel.AutoSize = true;

            // Label
            Label label = new Label();
            label.Text = "Uzyskany rezultat";
            label.Margin = new Padding(370, 0, 0, 0);

            // TextBox
            historyBox.Multiline = true;
            historyBox.ReadOnly = true;
            historyBox.BackColor = Color.White;
            historyBox.ScrollBars = ScrollBars.Vertical;
            historyBox.Size = new Size(800, 120);
            historyBox.Margin = new Padding(35, 0, 0, 0);

            panel.Controls.Add(label);
            panel.Controls.Add(historyBox);

            return panel;
        }
        Control CreateFifthRow()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.AutoSize = true;
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.LightGray;
            panel.FlowDirection = FlowDirection.LeftToRight;

            // Label 1
            Label labelLeft = new Label();
            labelLeft.Text = "Info";
            labelLeft.AutoSize = true;
            labelLeft.Margin = new Padding(12, 6, 0, 0);

            // TextBox 1
            TextBox textBoxLeft = new TextBox();
            textBoxLeft.Text = "Start aplikacji";
            textBoxLeft.BackColor = Color.White;
            textBoxLeft.Width = 375;
            textBoxLeft.ReadOnly = true;

            // Label 2
            Label labelRight = new Label();
            labelRight.Text = "Status";
            labelRight.AutoSize = true;
            labelRight.Margin = new Padding(15, 6, 0, 0);

            // TextBox 2
            TextBox textBoxRight = new TextBox();
            textBoxRight.Text = "ON";
            textBoxRight.BackColor = Color.White;
            textBoxRight.Width = 375;
            textBoxRight.ReadOnly = true;

            panel.Controls.Add(labelLeft);
            panel.Controls.Add(textBoxLeft);

            panel.Controls.Add(labelRight);
            panel.Controls.Add(textBoxRight);

            return panel;
        }
    }
}