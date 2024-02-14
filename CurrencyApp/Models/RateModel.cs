namespace CurrencyApp.Models
{
    public class RateModel
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string CurrencySymbol { get; set; }
        public double RateUsd { get; set; }
        public string Type { get; set; }
    }
}
