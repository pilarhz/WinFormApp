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
            this.Text = "Windows application test";
            this.Size = new Size(900, 600);
            this.CenterToScreen();

            MenuPanel menuPanel = new MenuPanel();
            menuPanel.Dock = DockStyle.Top;
            this.Controls.Add(menuPanel);
        }
    }
}