using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinNativeExamples.Core.Exceptions;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.Services.Messages.Requests;
using XamarinNativeExamples.Core.Services.Messages.Responses;
using XamarinNativeExamples.Core.Utils.Constants;

namespace XamarinNativeExamples.Core.Services.RestServices.Base
{
    internal abstract class BaseRestService
    {
        protected virtual string BaseAddress { get; } = ApiConstants.StocksUrl;

        private readonly HttpClient _httpClient;

        public BaseRestService(IHttpClientFactory httpfactory)
        {
            _httpClient = httpfactory.HttpClient;
            httpfactory.UpdateBaseAddress(BaseAddress);
        }

        /// <summary>
        /// Request an asynchronous call to webservices by the given endpoint.
        /// </summary>
        /// <param name="requestUri">The endpoint of webservices.</param>
        /// <returns>The content of the requested endpoint.</returns>
        public async Task<TResponse> GetRequestAsync<TResponse>(string requestUri, string apiToken = null) 
            where TResponse : BaseResponse
        {
            if (string.IsNullOrEmpty(apiToken))
            {
                throw new ApiTokenException("API Token required");
            }

            var endpoint = $"{requestUri}&token={apiToken}";
            var fullPath = $"{_httpClient.BaseAddress.AbsoluteUri}{endpoint}";

            var requestResponse = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);

            if (requestResponse != null && !requestResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format(Resources.HttpErrorMessage, fullPath));
            }

            if (requestResponse != null && requestResponse.StatusCode == HttpStatusCode.OK && requestResponse.IsSuccessStatusCode)
            {
                var responseJson =  await requestResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var response = JsonConvert.DeserializeObject<TResponse>(responseJson);
                response.RequestUrl = fullPath;

                return response;
            }

            return default;
        }

        /// <summary>
        /// Puts the request asynchronous.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="content">The object that will be serialized to json string.</param>
        /// <param name="apiToken">The access token of the logged in user.</param>
        /// <returns>The content of the requested endpoint.</returns>
        public async Task<TResponse> PutRequestAsync<TRequest, TResponse>(string requestUri, TRequest content, string apiToken = null)
            where TResponse : BaseResponse
            where TRequest : BaseRequest
        {
            if (string.IsNullOrEmpty(apiToken))
            {
                throw new ApiTokenException("API Token required");
            }

            var endpoint = $"{requestUri}&token={apiToken}";

            var jsonString = JsonConvert.SerializeObject(content);

            var stringJsonContent = new StringContent(jsonString, Encoding.UTF8, ApiConstants.JsonMediaType);

            var requestResponse = await _httpClient.PutAsync(endpoint, stringJsonContent).ConfigureAwait(false);

            if (requestResponse != null && !requestResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("request failed");
            }

            if (requestResponse != null && requestResponse.StatusCode == HttpStatusCode.OK && requestResponse.IsSuccessStatusCode)
            {
                var responseJson = await requestResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var response = JsonConvert.DeserializeObject<TResponse>(responseJson);
                response.RequestUrl = $"{_httpClient.BaseAddress.AbsoluteUri}{endpoint}";

                return response;
            }

            return default;
        }

        /// <summary>
        /// Posts the request asynchronous.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="content">The object that will be serialized to json string.</param>
        /// <param name="apiToken">The access token of the logged in user.</param>
        /// <returns>The content of the requested endpoint.</returns>
        public async Task<TResponse> PostRequestAsync<TRequest, TResponse>(string requestUri, TRequest content, string apiToken = null)
            where TResponse : BaseResponse
            where TRequest : BaseRequest
        {

            if (string.IsNullOrEmpty(apiToken))
            {
                throw new ApiTokenException("API Token required");
            }

            var endpoint = $"{requestUri}&token={apiToken}";

            var requestContent = GetRequestContent(content);

            var requestResponse = await _httpClient.PostAsync(endpoint, requestContent).ConfigureAwait(false);

            if (requestResponse != null && !requestResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("request failed");
            }

            if (requestResponse != null && requestResponse.StatusCode == HttpStatusCode.OK && requestResponse.IsSuccessStatusCode)
            {
                var responseJson = await requestResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var response = JsonConvert.DeserializeObject<TResponse>(responseJson);
                response.RequestUrl = $"{_httpClient.BaseAddress.AbsoluteUri}{endpoint}";

                return response;
            }

            return default;
        }

        /// <summary>
        /// Call a delete request asynchronous.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="apiToken">The access token of the logged in user.</param>
        /// <returns></returns>
        public async Task<TResponse> DeleteRequestAsync<TResponse>(string requestUri, string apiToken = null)
            where TResponse : BaseResponse
        {
            if (string.IsNullOrEmpty(apiToken))
            {
                throw new ApiTokenException("API Token required");
            }

            var endpoint = $"{requestUri}&token={apiToken}";

            var requestResponse = await _httpClient.DeleteAsync(endpoint).ConfigureAwait(false);

            if (requestResponse != null && !requestResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("request failed");
            }

            if (requestResponse != null && requestResponse.StatusCode == HttpStatusCode.OK && requestResponse.IsSuccessStatusCode)
            {
                var responseJson = await requestResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var response = JsonConvert.DeserializeObject<TResponse>(responseJson);
                response.RequestUrl = $"{_httpClient.BaseAddress.AbsoluteUri}{endpoint}";

                return response;
            }

            return default;
        }

        private HttpContent GetRequestContent(object content)
        {
            MultipartFormDataContent formDataContent = content as MultipartFormDataContent;

            if (formDataContent != null) return formDataContent;

            var httpContent = content as StringContent;
            httpContent = httpContent ?? new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

            return httpContent;
        }
    }
}
