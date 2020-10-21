using Newtonsoft.Json;

namespace XamarinNativeExamples.Core.Services.RestServices.Responses
{
    internal class NewsSentimentResponse : BaseResponse
    {
        [JsonProperty("buzz")]
        public Buzz Buzz { get; set; }
        [JsonProperty("sentiment")]
        public Sentiment Sentiment { get; set; }
        [JsonProperty("companyNewsScore")]
        public double? CompanyNewScore { get; set; }
        [JsonProperty("sectorAverageBullishPercent")]
        public double? SectorAverageBullishPercent { get; set; }
        [JsonProperty("sectorAverageNewsScore")]
        public double? SectorAverageNewsScore { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }

    internal class Buzz 
    {
        [JsonProperty("articlesInLastWeek")]
        public int ArticlesInLastWeek { get; set; }
        [JsonProperty("buzz")]
        public double BuzzValue { get; set; }
        [JsonProperty("weeklyAverage")]
        public double WeeklyAverage { get; set; }
    }

    internal class Sentiment
    {
        [JsonProperty("bearishPercent")]
        public double BearishPercent { get; set; }
        [JsonProperty("bullishPercent")]
        public double BullishPercent { get; set; }
    }
}
