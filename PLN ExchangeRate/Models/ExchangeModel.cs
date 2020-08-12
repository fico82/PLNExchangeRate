using System;

namespace PLN_ExchangeRate.Models
{
    public class ExchangeModel
    {
        public string effectiveDateUSD { get; set; }
        public double midEUR { get; set; }
        public string effectiveDateUSD1 { get; set; }
        public double midEUR1 { get; set; }
        public double changeEUR { get; set; }
        public string effectiveDateEUR { get; set; }
        public double midUSD { get; set; }
        public string effectiveDateEUR1 { get; set; }
        public double midUSD1 { get; set; }
        public double changeUSD { get; set; }
    }
}
