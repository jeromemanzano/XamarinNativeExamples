using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinNativeExamples.Core.Services.Storage
{
    internal class SecuredStorage : ISecuredStorage
    {
        public Task<string> GetAsync(string key)
        {
            try
            {
                return SecureStorage.GetAsync(key);
            }
            catch
            {
                return null;
            }
        }

        public bool Remove(string key)
        {
            return SecureStorage.Remove(key);

        }

        public void RemoveAll()
        {
            SecureStorage.RemoveAll();

        }

        public Task SetAsync(string key, string value)
        {
            try
            {
                return SecureStorage.SetAsync(key, value ?? string.Empty);
            }
            catch
            {
                return Task.CompletedTask;
            }
        }
    }
}
