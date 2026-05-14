using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppProj
{
    public partial class MenuUI
    {
        public string currentFile = "";

        private void Save(string path)
        {
            StreamWriter writer = new StreamWriter(path);

            for (int row = 1; row < 6; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Control? cell = body.matrixTable.GetControlFromPosition(col, row);

                    if (cell != null) writer.Write(cell.Text);

                    if (col < 4) writer.Write(" | ");
                }

                writer.WriteLine();
            }

            writer.Close();

            MessageBox.Show("Plik został zapisany");
        }

        // File
        public void NewFile(Object? sender, EventArgs e)
        {
            for (int row = 1; row < 6; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Control? cell = body.matrixTable.GetControlFromPosition(col, row);
                    
                    if (cell != null) cell.Text = "0";
                }
            }
            currentFile = "";
        }
        private void OpenFile(Object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Pliki txt|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = openFileDialog.FileName;

                string[] lines = File.ReadAllLines(currentFile);

                for (int row = 0; row < 5; row++)
                {
                    string[] data = lines[row].Split(new string[] { " | " }, StringSplitOptions.None);

                    for (int col = 0; col < 5; col++)
                    {
                        Control? cell = body.matrixTable.GetControlFromPosition(col, row + 1);
                        
                        if (cell != null)
                            cell.Text = data[col];
                    }
                }
            }
        }
        private void SaveFile(Object? sender, EventArgs e)
        {
            if (currentFile == "")
                SaveFileAs(sender, e);
            else
                Save(currentFile);
        }
        private void SaveFileAs(Object? sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Pliki txt|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = saveFileDialog.FileName;

                Save(currentFile);
            }
        }
        private void CloseWindow(Object? sender, EventArgs e)
        {
            Application.Exit();
        }
        // View
        private void CenterWindow(Object? sender, EventArgs e)
        {
            var form = this.FindForm();

            if (form != null)
            {
                form.Left = (Screen.PrimaryScreen.WorkingArea.Width - form.Width) / 2;
                form.Top = (Screen.PrimaryScreen.WorkingArea.Height - form.Height) / 2;
            }
        }
        private void MinimalizeWindow(Object? sender, EventArgs e)
        {
            var form = this.FindForm();

            if (form != null)
            {
                form.WindowState = FormWindowState.Minimized;
            }
        }
        // Help
        private void ShowAbout(Object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Autorem aplikacji jest Michał Pilarski,\n" +
                "student Politechniki Koszalińskiej na kierunku informatycznym\n\n" +
                "Aplikacja pozwala wykonywać działania na macierzy 5x5."
            );
        }
        private void ShowInf(Object? sender, EventArgs e)
        {
            MessageBox.Show("Instrukcja aplikacji");
        }
    }
}