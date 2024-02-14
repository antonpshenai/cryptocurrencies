using System;

namespace CurrencyApp.Models
{
    public class CoinHistoryDataModel
    {
        public double PriceUsd { get; set; }
        public long Time { get; set; }
        public DateTime Date { get; set; }
    }
}
