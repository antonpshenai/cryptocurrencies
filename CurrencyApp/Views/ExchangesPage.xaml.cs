using CurrencyApp.Models;
using CurrencyApp.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CurrencyApp.Views
{
    /// <summary>
    /// Interaction logic for ExchangePage.xaml
    /// </summary>
    public partial class ExchangesPage : Page
    {
        public ExchangesPage()
        {
            InitializeComponent();
            DataContext = new ExchangesPageViewModel();
        }

        private void DataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (ExchangesModel)DataGridView.SelectedItems[0];
            var exchangeId = row?.ExchangeId;
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(new ExchangePage(exchangeId));
        }
    }

}
