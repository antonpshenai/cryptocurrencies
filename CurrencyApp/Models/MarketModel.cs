using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public class MarketModel
    {
        public string ExchangeId { get; set; }
        public string Rank { get; set; }
        public string BaseSymbol { get; set; }
        public string QuoteSymbol { get; set; }
        public string PriceUsd { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public string MarketShare { get; set; }
    }
}
