using System.Threading.Tasks;
using XamarinNativeExamples.Core.Exceptions;
using XamarinNativeExamples.Core.Managers.Base;
using XamarinNativeExamples.Core.Models;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.Services.RestServices;

namespace XamarinNativeExamples.Core.Managers.Stocks
{
    internal class StockManager : BaseManager, IStockManager
    {
        private readonly IStockRestService _stockRestService;

        public StockManager(IStockRestService stockRestService)
        {
            _stockRestService = stockRestService;
        }

        public async Task<NewsSentimentModel> GetNewsSentiment(string stockSymbol)
        {
            //TODO: move apiToken to config
            var response = await _stockRestService.GetNewsSentiment(stockSymbol, "btv7rtf48v6qgbpjvci0");
            var newsSentimentModel = Mapper.Map<NewsSentimentModel>(response);

            if (newsSentimentModel.Buzz == null)
            {
                throw new BusinessException(string.Format(Resources.StockEmptyErrorMessage, stockSymbol));
            }

            return newsSentimentModel;
        }
    }
}
