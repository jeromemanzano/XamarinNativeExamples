using System.Threading.Tasks;
using XamarinNativeExamples.Core.Services.RestServices.Base;
using XamarinNativeExamples.Core.Services.RestServices.Responses;

namespace XamarinNativeExamples.Core.Services.RestServices
{
    internal interface IStockRestService : IBaseRestService
    {
        Task<NewsSentimentResponse> GetNewsSentimentAsync(string stock, string apiToken);
    }
}
