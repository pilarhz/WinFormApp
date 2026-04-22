using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Drawing.Text;
using System.Runtime.InteropServices.ObjectiveC;

namespace WinAppProj
{
    public class MenuPanel : UserControl
    {
        public MenuPanel()
        {
            MenuStrip menu = new MenuStrip();
            menu.BackColor = Color.LightGray;

            // File
            ToolStripMenuItem file = new ToolStripMenuItem("Plik");
            ToolStripMenuItem createNew = new ToolStripMenuItem("Nowy");
            ToolStripMenuItem open = new ToolStripMenuItem("Otwórz");
            ToolStripMenuItem save = new ToolStripMenuItem("Zapisz");
            ToolStripMenuItem saveAs = new ToolStripMenuItem("Zapisz jako");

            file.DropDownItems.Add(createNew);
            file.DropDownItems.Add(open);
            file.DropDownItems.Add(save);
            file.DropDownItems.Add(saveAs);

            // Edit
            ToolStripMenuItem edit = new ToolStripMenuItem("Edytuj");
            ToolStripMenuItem undo = new ToolStripMenuItem("Cofnij");
            ToolStripMenuItem redo = new ToolStripMenuItem("Ponów");
            ToolStripMenuItem copy = new ToolStripMenuItem("Kopiuj");
            ToolStripMenuItem paste = new ToolStripMenuItem("Wklej");

            edit.DropDownItems.Add(undo);
            edit.DropDownItems.Add(redo);
            edit.DropDownItems.Add(copy);
            edit.DropDownItems.Add(paste);

            // View
            ToolStripMenuItem view = new ToolStripMenuItem("Widok");
            ToolStripMenuItem center = new ToolStripMenuItem("Wyśrodkuj okno");

            view.DropDownItems.Add(center);

            // Math
            ToolStripMenuItem math = new ToolStripMenuItem("Obliczenia");
            ToolStripMenuItem sum = new ToolStripMenuItem("Suma");
            ToolStripMenuItem min = new ToolStripMenuItem("Min");
            ToolStripMenuItem max = new ToolStripMenuItem("Max");

            math.DropDownItems.Add(sum);
            math.DropDownItems.Add(min);
            math.DropDownItems.Add(max);

            // Help
            ToolStripMenuItem help = new ToolStripMenuItem("Pomoc");
            ToolStripMenuItem about = new ToolStripMenuItem("O programie");
            about.Click += ShowAbout;

            help.DropDownItems.Add(about);

            // Creating menu
            menu.Items.Add(file);
            menu.Items.Add(edit);
            menu.Items.Add(view);
            menu.Items.Add(math);
            menu.Items.Add(help);

            this.Controls.Add(menu);
        }
        private void ShowAbout(Object? sender, EventArgs e)
        {
            MessageBox.Show("Aplikację napisał Michał Pilarski:)");
        }
    }
}