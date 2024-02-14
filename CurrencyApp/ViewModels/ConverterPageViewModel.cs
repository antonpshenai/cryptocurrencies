using CurrencyApp.Models;
using CurrencyApp.Services;
using System.Collections.Generic;
using System.Linq;

public class ConverterPageViewModel : ViewModelBase
{
    private CoinCapAPIService coinCapService;
    private List<RateModel> rates;

    public ConverterPageViewModel()
    {
        coinCapService = new CoinCapAPIService();
        Initialize();
    }

    private async void Initialize()
    {
        rates = await coinCapService.GetRatesAsync();

        Currencies = rates.Select(rate => rate.CurrencySymbol).Distinct().ToList();
    }

    private double amount;
    public double Amount
    {
        get { return amount; }
        set { SetProperty(ref amount, value, nameof(Amount)); }
    }

    private string selectedFromCurrency;
    public string SelectedFromCurrency
    {
        get { return selectedFromCurrency; }
        set { SetProperty(ref selectedFromCurrency, value, nameof(SelectedFromCurrency)); }
    }

    private string selectedToCurrency;
    public string SelectedToCurrency
    {
        get { return selectedToCurrency; }
        set { SetProperty(ref selectedToCurrency, value, nameof(SelectedToCurrency)); }
    }

    private double conversionRate;
    public double ConversionRate
    {
        get { return conversionRate; }
        set { SetProperty(ref conversionRate, value, nameof(ConversionRate)); }
    }

    private List<string> currencies;
    public List<string> Currencies
    {
        get { return currencies; }
        set { SetProperty(ref currencies, value, nameof(Currencies)); }
    }

    private string result;
    public string Result
    {
        get { return result; }
        set { SetProperty(ref result, value, nameof(Result)); }
    }

    public async void Convert()
    {
        var toCurrencyRate = rates.FirstOrDefault(r => r.CurrencySymbol == SelectedToCurrency)?.RateUsd ?? 1.0;
        ConversionRate = toCurrencyRate;
        double convertedAmount = Amount * ConversionRate;

        Result = $"{Amount} {SelectedFromCurrency} = {convertedAmount} {SelectedToCurrency}";
    }

    public void Clear()
    {
        Amount = 0;
        SelectedFromCurrency = null;
        SelectedToCurrency = null;
        Result = "";
    }
}
