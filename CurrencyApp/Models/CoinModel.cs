using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public class CoinModel
    {
        public string Id { get; set; }
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Supply { get; set; }
        public string MarketCapUsd { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public string PriceUsd { get; set; }
        public string ChangePercent24Hr { get; set; }
        public List<MarketModel> Markets { get; set; }
        public List<CoinHistoryDataModel> HistoricalData { get; set; }

        //for chart
        public SeriesCollection HistoricalDataChartSeries { get; set; }
        public List<string> HistoricalDataLabels { get; set; }


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
