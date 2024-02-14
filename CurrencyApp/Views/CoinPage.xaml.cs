using CurrencyApp.ViewModels;
using System.Windows.Controls;

namespace CurrencyApp.Views
{
    /// <summary>
    /// Interaction logic for CoinPage.xaml
    /// </summary>
    public partial class CoinPage : Page
    {
        public CoinPage(string coinId)
        {
            InitializeComponent();
            DataContext = new CoinPageViewModel(coinId);
        }
    }
}
