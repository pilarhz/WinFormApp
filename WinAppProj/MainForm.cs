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
            // Setting window
            this.Text = "Windows application test";
            this.Size = new Size(900, 600);
            this.CenterToScreen();

            // Menu panel
            MenuPanel menuPanel = new MenuPanel();
            menuPanel.Dock = DockStyle.Top;
            this.Controls.Add(menuPanel);

            // Body

        }
    }
}