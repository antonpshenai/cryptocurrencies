using CurrencyApp.ViewModels;
using System.Windows.Controls;

namespace CurrencyApp.Views
{
    /// <summary>
    /// Interaction logic for ExchangePage.xaml
    /// </summary>
    public partial class ExchangePage : Page
    {
        public ExchangePage(string exchangeId)
        {
            InitializeComponent();

            DataContext = new ExchangePageViewModel(exchangeId);
        }
    }
}
