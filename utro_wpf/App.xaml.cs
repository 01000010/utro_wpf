using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using utro_wpf.core;

namespace utro_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custum start up for the application
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Leave whatever is going on here in peace
            base.OnStartup(e);

            // Load up the IoC
            IoC.Setup();

            // Show up the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
