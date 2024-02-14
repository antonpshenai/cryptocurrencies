using CurrencyApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CurrencyApp.Views
{
    public partial class SearchPage : Page
    {
        private SearchPageViewModel viewModel;

        public SearchPage()
        {
            InitializeComponent();
            viewModel = new SearchPageViewModel();
            DataContext = viewModel;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem is CurrencyModel selectedCryptocurrency)
            {
                string selectedCryptocurrencyDetails = selectedCryptocurrency.Name;
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(new CoinPage(selectedCryptocurrencyDetails));
            }
        }
    }
}
