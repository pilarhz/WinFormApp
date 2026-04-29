using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Drawing.Text;
using System.Runtime.InteropServices.ObjectiveC;
using System.Data;
using System.Windows.Forms.VisualStyles;

namespace WinAppProj
{
    public class MenuPanel : UserControl
    {
        public MenuPanel()
        {
            this.Dock = DockStyle.Fill;
            this.AutoSize = false;
            this.Height = 85;

            TableLayoutPanel layout = new TableLayoutPanel();
            layout.RowCount = 2;
            layout.ColumnCount = 1;
            layout.Dock = DockStyle.Fill;

            layout.Controls.Add(CreateFirstRow(), 0, 0);
            layout.Controls.Add(CreateSecondRow(), 0, 1);

            this.Controls.Add(layout);
        }
        Control CreateFirstRow()
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

            return menu;
        }
        Control CreateSecondRow()
        {
            FlowLayoutPanel iconPanel = new FlowLayoutPanel();
            iconPanel.FlowDirection = FlowDirection.LeftToRight;
            iconPanel.AutoSize = true;

            // Save
            Button btnSave = new Button();
            btnSave.Size = new Size(50, 50);
            Image btnSaveImage = Image.FromFile("..\\..\\..\\icons\\save.jpg");
            btnSave.BackgroundImage = btnSaveImage;
            btnSave.BackgroundImageLayout = ImageLayout.Zoom;

            // Print
            Button btnPrint = new Button();
            btnPrint.Size = new Size(50, 50);
            Image btnPrintImage = Image.FromFile("..\\..\\..\\icons\\print.png");
            btnPrint.BackgroundImage = btnPrintImage;
            btnPrint.BackgroundImageLayout = ImageLayout.Zoom;

            // Open
            Button btnOpen = new Button();
            btnOpen.Size = new Size(50, 50);
            Image btnOpenImage = Image.FromFile("..\\..\\..\\icons\\open.png");
            btnOpen.BackgroundImage = btnOpenImage;
            btnOpen.BackgroundImageLayout = ImageLayout.Zoom;

            // Add
            Button btnAdd = new Button();
            btnAdd.Size = new Size(50, 50);
            Image btnAddImage = Image.FromFile("..\\..\\..\\icons\\add.png");
            btnAdd.BackgroundImage = btnAddImage;
            btnAdd.BackgroundImageLayout = ImageLayout.Zoom;

            // Empty
            Button btnEmpty = new Button();
            btnEmpty.Size = new Size(50, 50);
            Image btnEmptyImage = Image.FromFile("..\\..\\..\\icons\\empty.png");
            btnEmpty.BackgroundImage = btnEmptyImage;
            btnEmpty.BackgroundImageLayout = ImageLayout.Zoom;

            // Fill
            Button btnFill = new Button();
            btnFill.Size = new Size(50, 50);
            Image btnFillImage = Image.FromFile("..\\..\\..\\icons\\fill.png");
            btnFill.BackgroundImage = btnFillImage;
            btnFill.BackgroundImageLayout = ImageLayout.Zoom;

            // Sum
            Button btnSum = new Button();
            btnSum.Size = new Size(50, 50);
            Image btnSumImage = Image.FromFile("..\\..\\..\\icons\\sum.png");
            btnSum.BackgroundImage = btnSumImage;
            btnSum.BackgroundImageLayout = ImageLayout.Zoom;
            
            // Min
            Button btnMin = new Button();
            btnMin.Size = new Size(50, 50);
            Image btnMinImage = Image.FromFile("..\\..\\..\\icons\\min.png");
            btnMin.BackgroundImage = btnMinImage;
            btnMin.BackgroundImageLayout = ImageLayout.Zoom;

            // Sum
            Button btnMax = new Button();
            btnMax.Size = new Size(50, 50);
            Image btnMaxImage = Image.FromFile("..\\..\\..\\icons\\max.png");
            btnMax.BackgroundImage = btnMaxImage;
            btnMax.BackgroundImageLayout = ImageLayout.Zoom;
            
            // About
            Button btnAbout = new Button();
            btnAbout.Size = new Size(50, 50);
            Image btnAboutImage = Image.FromFile("..\\..\\..\\icons\\about.jpg");
            btnAbout.BackgroundImage = btnAboutImage;
            btnAbout.BackgroundImageLayout = ImageLayout.Zoom;
            btnAbout.Click += ShowAbout;

            // Sum
            Button btnHelp = new Button();
            btnHelp.Size = new Size(50, 50);
            Image btnHelpImage = Image.FromFile("..\\..\\..\\icons\\help.jpg");
            btnHelp.BackgroundImage = btnHelpImage;
            btnHelp.BackgroundImageLayout = ImageLayout.Zoom;

            Panel CreateSpacer(int width)
            {
                return new Panel
                {
                    Size = new Size(width, 20),
                    Margin = new Padding(0),
                    BackColor = Color.Transparent
                };
            }

            iconPanel.Controls.Add(btnSave);
            iconPanel.Controls.Add(btnPrint);
            iconPanel.Controls.Add(btnOpen);
            iconPanel.Controls.Add(CreateSpacer(25));

            iconPanel.Controls.Add(btnAdd);
            iconPanel.Controls.Add(btnEmpty);
            iconPanel.Controls.Add(btnFill);
            iconPanel.Controls.Add(CreateSpacer(25));

            iconPanel.Controls.Add(btnSum);
            iconPanel.Controls.Add(btnMin);
            iconPanel.Controls.Add(btnMax);
            iconPanel.Controls.Add(CreateSpacer(25));

            iconPanel.Controls.Add(btnAbout);
            iconPanel.Controls.Add(btnHelp);

            return iconPanel;
        }
        private void ShowAbout(Object? sender, EventArgs e)
        {
            MessageBox.Show("Aplikacja służy przeprowadzania prostych" +
                " operacji na macierzy 5x5");

        }
    }
}