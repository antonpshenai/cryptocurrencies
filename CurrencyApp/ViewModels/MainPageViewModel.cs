using CurrencyApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CurrencyApp.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<CurrencyModel> _assets;
        private CoinCapAPIService _coinCapAPIService;

        public ObservableCollection<CurrencyModel> Assets
        {
            get { return _assets; }
            set
            {
                _assets = value;
                OnPropertyChanged(nameof(CurrencyModel));
            }
        }

        public MainPageViewModel()
        {
            _coinCapAPIService = new CoinCapAPIService();
            LoadAssets();
        }

        private  void LoadAssets()
        {
            List<CurrencyModel> assets = _coinCapAPIService.GetTopAssets();
            if (assets != null)
            {
                Assets = new ObservableCollection<CurrencyModel>(assets);
            }

            //try
            //{
            //    List<AssetsModel> assets = await _coinCapAPIService.GetTopAssets();

            //    // Use Dispatcher to update UI on the UI thread
            //    Application.Current.Dispatcher.Invoke(() =>
            //    {
            //        if (assets != null)
            //        {
            //            Assets = new ObservableCollection<AssetsModel>(assets);
            //        }
            //        // Handle errors if necessary
            //    });
            //}
            //catch (Exception ex)
            //{
            //    // Log or handle the exception
            //    Console.WriteLine($"Error loading assets: {ex.Message}");
            //}
        }
    }
}
