using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotedSpeed
{
    public delegate void DoneLogin();

    public class Controller
    {
        SimplenoteLoginWindow loginWindow;
        MainWindow mainWindow;

        public void Launch()
        {
            if (String.IsNullOrEmpty(Settings.Default.Password))
            {
                DisplayLoginWindow();
            }
            else
            {
                DisplayMainWindow();
            }
        }

        private void DisplayMainWindow()
        {
            mainWindow = new MainWindow();

            mainWindow.Show();
            mainWindow.BringIntoView();
        }

        private void DisplayLoginWindow()
        {
            loginWindow = new SimplenoteLoginWindow();
            loginWindow.OnDoneLogin += new DoneLogin(loginWindow_OnDoneLogin);
            loginWindow.Show();
            loginWindow.BringIntoView();
        }

        void loginWindow_OnDoneLogin()
        {
            loginWindow.Close();
            DisplayMainWindow();

        }
    }
}
