using System.Threading.Tasks;

namespace XamarinNativeExamples.Core.Services.RestServices.Base
{
    internal interface IBaseRestService
    {
        Task<bool> ValidateTokenAsync(string apiToken);
    }
}
