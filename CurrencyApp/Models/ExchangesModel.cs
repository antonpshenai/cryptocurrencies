using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public class ExchangesModel
    {
        public string? ExchangeId { get; set; }
        public string? Name { get; set; }
        public string?  Rank { get; set; }
        public string? PercentTotalVolume { get; set; }
        public string? VolumeUsd { get; set;}
        public string?    TradingPairs { get; set; }
        public bool?   Socket { get; set; } 
        public string? ExchangeUrl { get; set; } 


    }
}

//"exchangeId": "binance",
//            "name": "Binance",
//            "rank": "1",
//            "percentTotalVolume": "43.023383020396495704000000000000000000",
//            "volumeUsd": "5171823523.7434980670644143",
//            "tradingPairs": "793",
//            "socket": true,
//            "exchangeUrl": "https://www.binance.com/",
//            "updated": 1707740325714