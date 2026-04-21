using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppProj
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.Text = "Moja aplikacja";
            this.Size = new Size(400, 300);

            Button btn = new Button();
            btn.Text = "Kliknij";
            btn.Location = new Point(150, 120);

            btn.Click += (s, e) => MessageBox.Show("Działa!");

            this.Controls.Add(btn);
        }
    }
}