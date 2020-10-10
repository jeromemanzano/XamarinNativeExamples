using System.Threading.Tasks;
using XamarinNativeExamples.Core.Services.Messages.Responses;

namespace XamarinNativeExamples.Core.Services.RestServices
{
    internal interface IStockRestService
    {
        Task<NewsSentimentResponse> GetNewsSentiment(string stock, string apiToken);
    }
}
