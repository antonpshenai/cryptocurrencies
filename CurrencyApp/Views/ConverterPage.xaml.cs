using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CurrencyApp.Views
{
    /// <summary>
    /// Interaction logic for ConverterPage.xaml
    /// </summary>
    public partial class ConverterPage : Page
    {
        private ConverterPageViewModel viewModel;
        public ConverterPage()
        {
            InitializeComponent();
            viewModel = new ConverterPageViewModel();
            DataContext = viewModel;
        }
        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Convert();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Clear();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !double.TryParse(e.Text, out _);
        }

        private void cmbFromCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
