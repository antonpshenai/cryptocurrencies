﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public class CoinHistoryDataModel
    {
        public double PriceUsd { get; set; }
        public long Time { get; set; }
        public DateTime Date { get; set; }
    }
}
