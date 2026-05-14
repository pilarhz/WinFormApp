using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppProj
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            // Window
            this.Text = "Windows application test";
            this.Size = new Size(920, 670);
            this.Icon = new Icon("..\\..\\..\\icons\\appIcon.ico");
            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Layout
            TableLayoutPanel layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;

            layout.RowCount = 2;
            layout.ColumnCount = 1;

            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // New classes
            BodyUI body = new BodyUI();
            MenuUI menu = new MenuUI(body);

            // Add controls
            layout.Controls.Add(menu, 0, 0);
            layout.Controls.Add(body, 0, 1);

            this.Controls.Add(layout);
        }
    }
}