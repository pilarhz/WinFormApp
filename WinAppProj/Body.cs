using System;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace WinAppProj
{
    public class Body : UserControl
    {
        public Body()
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

            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Margin = new Padding(0, 30, 0, 30);
            }
            textInput.Margin = new Padding(37, 33, 0, 30);
            textRow.Margin = new Padding(37, 33, 0, 30);
            textColumn.Margin = new Padding(37, 33, 0, 30);
            this.Controls.Add(panel);

            return panel;
        }
        Control CreateSecondRow()
        {
            // Container
            FlowLayoutPanel secondRowContainer = new FlowLayoutPanel();
            secondRowContainer.FlowDirection = FlowDirection.LeftToRight;
            secondRowContainer.AutoSize = true;

            // Table
            TableLayoutPanel table = new TableLayoutPanel();
            table.RowCount = 6;
            table.ColumnCount = 5;
            table.AutoSize = true;

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

            table.Controls.Add(CreateTextBox("1", Color.LightGray), 0, 0);
            table.Controls.Add(CreateTextBox("2", Color.LightGray), 1, 0);
            table.Controls.Add(CreateTextBox("3", Color.LightGray), 2, 0);
            table.Controls.Add(CreateTextBox("4", Color.LightGray), 3, 0);
            table.Controls.Add(CreateTextBox("5", Color.LightGray), 4, 0);
            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    table.Controls.Add(CreateTextBox("0", Color.White), j, i);
                }
            }

            // Buttons
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
            buttonPanel.FlowDirection = FlowDirection.TopDown;
            buttonPanel.AutoSize = true;

            // Add
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
            buttonPanel.Controls.Add(CreateButton("Dodaj", Image.FromFile("..\\\\..\\\\..\\\\icons\\\\add.png")));
            buttonPanel.Controls.Add(CreateButton("Wyzeruj", Image.FromFile("..\\\\..\\\\..\\\\icons\\\\empty.png")));
            buttonPanel.Controls.Add(CreateButton("Wypełnij", Image.FromFile("..\\\\..\\\\..\\\\icons\\\\fill.png")));
            buttonPanel.Controls.Add(CreateButton("Zapisz", Image.FromFile("..\\\\..\\\\..\\\\icons\\\\save.jpg")));

            table.Margin = new Padding(80, 3, 60, 0);
            secondRowContainer.Controls.Add(table);
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

            // Choose menu
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
            button.Size = new Size(100, 30);
            button.Margin = new Padding(10, 0, 0, 0);

            button.Click += (s, e) =>
            {
                string wybor = comboBox.SelectedItem?.ToString();

                switch (wybor)
                {
                    case "Suma":
                        MessageBox.Show("Wykonuję sumę");
                        break;

                    case "Min":
                        MessageBox.Show("Szukam minimum");
                        break;

                    case "Max":
                        MessageBox.Show("Szukam maksimum");
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
            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            textBox.ReadOnly = true;
            textBox.BackColor = Color.White;
            textBox.Size = new Size(800, 150);
            textBox.Margin = new Padding(35, 0, 0, 0);

            panel.Controls.Add(label);
            panel.Controls.Add(textBox);

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

            panel.Controls.Add(labelLeft);
            panel.Controls.Add(textBoxLeft);

            panel.Controls.Add(labelRight);
            panel.Controls.Add(textBoxRight);

            return panel;
        }
    }
}