using CurrencyApp.Models;
using CurrencyApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class SearchPageViewModel : ViewModelBase
{
    private ObservableCollection<CurrencyModel> _assets;
    private CoinCapAPIService _coinCapAPIService;
    private string _searchTerm;
    private ObservableCollection<CurrencyModel> _searchSuggestions;

    public ObservableCollection<CurrencyModel> Assets
    {
        get { return _assets; }
        set
        {
            _assets = value;
            OnPropertyChanged(nameof(Assets));
        }
    }

    public string SearchTerm
    {
        get { return _searchTerm; }
        set
        {
            _searchTerm = value;
            OnPropertyChanged(nameof(SearchTerm));
            SearchAsync();
        }
    }

    public ObservableCollection<CurrencyModel> SearchSuggestions
    {
        get { return _searchSuggestions; }
        set
        {
            _searchSuggestions = value;
            OnPropertyChanged(nameof(SearchSuggestions));
        }
    }

    public SearchPageViewModel()
    {
        _coinCapAPIService = new CoinCapAPIService();
        LoadAssetsAsync();
    }

    private async void LoadAssetsAsync()
    {
        List<CurrencyModel> assets = await _coinCapAPIService.GetAssetsAsync();
        if (assets != null)
        {
            Assets = new ObservableCollection<CurrencyModel>(assets);
        }
    }

    private void SearchAsync()
    {
        var filtered = Assets
            .Where(c => c.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.Symbol.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();

        SearchSuggestions = new ObservableCollection<CurrencyModel>(filtered);
    }
}
