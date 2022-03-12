using System;

namespace XamarinNativeExamples.Core.Models
{
    public class PriceUpdateModel
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public DateTime Time { get; set; }
    }
}
