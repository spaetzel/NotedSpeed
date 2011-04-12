using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotedSpeed
{
    /// <summary>
    /// Interaction logic for SimplenoteLoginWindow.xaml
    /// </summary>
    public partial class SimplenoteLoginWindow : Window
    {
        public SimplenoteLoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Email = email.Text;
            Settings.Default.Password = password.Password;

            Settings.Default.Save();

            if (OnDoneLogin != null)
            {
                OnDoneLogin();
            }
        }

        public event DoneLogin OnDoneLogin;
    }
}
