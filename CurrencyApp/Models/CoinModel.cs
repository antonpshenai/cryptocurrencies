using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    class CoinModel
    {      public string? Id { get; set; }
           
           public int RankCoinreRa { get; set; }
           public string? SymbolCoin { get; set; }
       
           public decimal SupplyData { get; set; }
           public decimal MaxSupplyData { get; set; }

           public decimal MarketCapUsdData { get; set; }

           public decimal VolumeUsd24HrData { get; set; }

           public decimal PriceUsdData { get; set; }

           public decimal ChangePercentDayData { get; set; }

           public decimal VwapDayHrData { get; set; }


        //"id": "bitcoin",
        //    "rank": "1",
        //    "symbol": "BTC",
        //    "name": "Bitcoin",
        //    "supply": "19621725.0000000000000000",
        //    "maxSupply": "21000000.0000000000000000",
        //    "marketCapUsd": "875955689034.6949818070340700",
        //    "volumeUsd24Hr": "14066341745.9397342480604119",
        //    "priceUsd": "44642.1346255079500812",
        //    "changePercent24Hr": "3.9688060588018672",
        //    "vwap24Hr": "43932.2986447904278354",
        //    "explorer": "https://blockchain.info/"
    }
}
