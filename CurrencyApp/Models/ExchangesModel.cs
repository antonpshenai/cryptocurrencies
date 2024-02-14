using System.Collections.Generic;

namespace CurrencyApp.Models
{
    public class ExchangesModel
    {
        public string? ExchangeId { get; set; }
        public string? Name { get; set; }
        public string?  Rank { get; set; }
        public string? PercentTotalVolume { get; set; }
        public string? VolumeUsd { get; set;}
        public string? TradingPairs { get; set; }
        public bool? Socket { get; set; } 
        public string? ExchangeUrl { get; set; }
        public List<MarketModel> Markets { get; set; }


    }
}