using System;
using System.Windows.Forms;

namespace WinAppProj
{
    public partial class MenuUI
    {
        private void OpenFile(Object? sender, EventArgs e)
        {

        }
        private void SaveFile(Object? sender, EventArgs e)
        {

        }
        private void SaveFileAs(Object? sender, EventArgs e)
        {

        }
        private void CloseWindow(Object? sender, EventArgs e)
        {
            Application.Exit();
        }
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