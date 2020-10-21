using System.Threading.Tasks;
using XamarinNativeExamples.Core.Services.RestServices.Base;
using XamarinNativeExamples.Core.Services.RestServices.Responses;
using XamarinNativeExamples.Core.Utils.Constants;

namespace XamarinNativeExamples.Core.Services.RestServices
{
    internal class StockRestService : BaseRestService, IStockRestService
    {
        public StockRestService(IHttpClientFactory httpfactory) : base (httpfactory)
        {
        }

        public Task<NewsSentimentResponse> GetNewsSentiment(string stock, string apiToken)
        {
            var endpoint = string.Format(ApiEndPoints.NewsSentimentAction, stock);
            return GetRequestAsync<NewsSentimentResponse>(endpoint, apiToken);
        }
    }
}
