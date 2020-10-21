using System.Threading.Tasks;
using XamarinNativeExamples.Core.Services.RestServices.Base;
using XamarinNativeExamples.Core.Services.RestServices.Responses;

namespace XamarinNativeExamples.Core.Services.RestServices
{
    internal interface IStockRestService : IBaseRestService
    {
        Task<NewsSentimentResponse> GetNewsSentiment(string stock, string apiToken);
    }
}
