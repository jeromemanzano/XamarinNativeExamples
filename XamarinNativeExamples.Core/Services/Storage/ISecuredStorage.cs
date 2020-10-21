using System.Threading.Tasks;

namespace XamarinNativeExamples.Core.Services.Storage
{
    internal interface ISecuredStorage
    {
        Task<string> GetAsync(string key);
        Task SetAsync(string key, string value);
        bool Remove(string key);
        void RemoveAll();
    }
}
