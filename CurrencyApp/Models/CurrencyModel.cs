using LiveCharts;
using System.Collections.Generic;

namespace CurrencyApp.Models
{
    public class CurrencyModel
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
    }
}
