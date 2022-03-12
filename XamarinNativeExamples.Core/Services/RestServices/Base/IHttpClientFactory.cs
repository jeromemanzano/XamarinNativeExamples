using System.Net.Http;

namespace XamarinNativeExamples.Core.Services.RestServices.Base
{
    internal interface IHttpClientFactory
    {
        HttpClient HttpClient { get; }

        void UpdateBaseAddress(string baseAddress);
    }
}
