using System.Threading.Tasks;
using XamarinNativeExamples.Core.Models;

namespace XamarinNativeExamples.Core.Managers.Stocks
{
    internal interface IStockManager
    {
        Task<NewsSentimentModel> GetNewsSentiment(string stockSymbol);
    }
}
