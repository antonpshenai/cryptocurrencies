using CurrencyApp.Models;
using CurrencyApp.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyApp.Views
{
    /// <summary>
    /// Interaction logic for ExchangePage.xaml
    /// </summary>
    public partial class ExchangePage : Page
    {
        public ExchangePage()
        {
            InitializeComponent();
            DataContext = new ExchangesPageViewModel();
        }

        private void DataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (ExchangesModel)DataGridView.SelectedItems[0];
            var a = row?.ExchangeId;//It is returning the id of selected row

            var b = a;
        }
    }

}
