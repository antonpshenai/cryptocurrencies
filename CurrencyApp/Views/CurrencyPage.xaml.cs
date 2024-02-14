using CurrencyApp.Models;
using CurrencyApp.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CurrencyApp.Views
{
    /// <summary>
    /// Interaction logic for CurrencyPage.xaml
    /// </summary>
    public partial class CurrencyPage : Page
    {
        public CurrencyPage()
        {
            InitializeComponent();
            DataContext = new CurrencyPageViewModel();
        }

        private void DataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (CurrencyModel)DataGridView.SelectedItems[0];
            var coinId = row?.Id;
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(new CoinPage(coinId));
        }
    }
}
