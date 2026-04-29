using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace WinAppProj
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            // Set window
            this.Text = "Windows application test";
            this.Size = new Size(900, 630);//900x600
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

            // Create menu and body
            Body body = new Body();
            MenuPanel menuPanel = new MenuPanel();

            // Add layout
            layout.Controls.Add(menuPanel, 0, 0);
            layout.Controls.Add(body, 0, 1);
            this.Controls.Add(layout);
        }
    }
}