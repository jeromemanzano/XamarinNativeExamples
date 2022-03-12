using System.Threading.Tasks;
using XamarinNativeExamples.Core.Services.RestServices.Base;
using XamarinNativeExamples.Core.Services.RestServices.Responses;
using XamarinNativeExamples.Core.Utils.Constants;

namespace XamarinNativeExamples.Core.Services.RestServices
{
    internal class StockRestService : BaseRestService, IStockRestService
    {
        public StockRestService(IHttpClientFactory httpFactory) : base (httpFactory)
        {
        }

        public Task<NewsSentimentResponse> GetNewsSentimentAsync(string stock, string apiToken)
        {
            var endpoint = string.Format(ApiEndPoints.NewsSentimentAction, stock);
            return GetRequestAsync<NewsSentimentResponse>(endpoint, apiToken);
        }
    }
}
