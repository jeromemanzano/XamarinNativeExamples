using System;
using System.Net.Http;

namespace XamarinNativeExamples.Core.Services.RestServices.Base
{
    internal class HttpClientFactory : IHttpClientFactory
    {
        public HttpClientFactory() 
        {
            HttpClient = new HttpClient();
        }

        public HttpClient HttpClient { get; private set; }

        public void UpdateBaseAddress(string baseAddress) 
        {
            if (HttpClient.BaseAddress?.AbsoluteUri != baseAddress)
            {
                HttpClient.BaseAddress = new Uri(baseAddress);
            }
        }
    }
}
