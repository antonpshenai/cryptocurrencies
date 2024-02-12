using CurrencyApp.ViewModels;
using CurrencyApp.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mainWindow = new MainWindow();
            //MainPage mainPage = new MainPage();
            //mainWindow.MainFrame.Navigate(mainPage);
            mainWindow.Show();
        }
    }
}
