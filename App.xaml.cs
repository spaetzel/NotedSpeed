using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace NotedSpeed
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Controller controller;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            controller = new Controller();
            controller.Launch();
        }
    }
}
