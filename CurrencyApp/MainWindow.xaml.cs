using CurrencyApp.Views;
using System.Windows;
using System.Windows.Controls;

namespace CurrencyApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigateToPage(new MainPage());
        }

        private void NavigateToPage(Page page)
        {
            MainFrame.NavigationService.Navigate(page);
        }

        private void DragGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursor(index);
            switch (index)
            {
                case 0:
                    NavigateToPage(new MainPage());
                    break;
                case 1:
                    NavigateToPage(new CurrencyPage());
                    break;
                case 2:
                    NavigateToPage(new ExchangesPage());
                    break;
                case 3:
                    NavigateToPage(new SearchPage());
                    break;
                case 4:
                    NavigateToPage(new ConverterPage());
                    break;
            }
        }

        private void MoveCursor(int index)
        {
            TransitionContentSlide.OnApplyTemplate();
            TransitionGrid.Margin = new Thickness(0, (index * 60) + 70, 0, 0);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
