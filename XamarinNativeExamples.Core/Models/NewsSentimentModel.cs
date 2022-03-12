
namespace XamarinNativeExamples.Core.Models
{
    public class NewsSentimentModel
    {
        public BuzzModel Buzz { get; set; }
        public SentimentModel Sentiment { get; set; }
        public double? CompanyNewScore { get; set; }
        public double? SectorAverageBullishPercent { get; set; }
        public double? SectorAverageNewsScore { get; set; }
        public string Symbol { get; set; }
    }

    public class BuzzModel
    {
        public int ArticlesInLastWeek { get; set; }
        public double BuzzValue { get; set; }
        public double WeeklyAverage { get; set; }
    }

    public class SentimentModel
    {
        public double BearishPercent { get; set; }
        public double BullishPercent { get; set; }
    }
}
