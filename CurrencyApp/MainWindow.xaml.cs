using CurrencyApp.ViewModels;
using CurrencyApp.Views;
using System.Windows;
using System.Windows.Controls;

namespace CurrencyApp
{
    public partial class MainWindow : Window
    {
        //private readonly MainPageViewModel mainPageViewModel;
        //private readonly CurrencyViewModel currencyViewModel;

        public MainWindow()
        {
            InitializeComponent();
            //mainPageViewModel = new MainPageViewModel();
            //DataContext = mainPageViewModel;
            NavigateToPage(new MainPage());
        }

        private void NavigateToPage(Page page)
        {
            MainFrame.NavigationService.Navigate(page);
        }

        private void AllCoinsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage(new CurrencyPage());
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
