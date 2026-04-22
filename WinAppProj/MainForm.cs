using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppProj
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            // GUI
            this.Text = "Windows application test";
            this.Size = new Size(900, 600);

            this.CenterToScreen();
        }
    }
}