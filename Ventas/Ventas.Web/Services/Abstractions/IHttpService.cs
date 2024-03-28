using Microsoft.AspNetCore.Mvc;

namespace Ventas.Web.Services.Abstractions
{
    public interface IHttpService
    {
        public Task<List<T>> Get<T>(string url);
        public Task<bool> Post<T>(bool isModelValid, string url, T request);
        public Task<bool> Put<T>(bool isModelValid, string url, T request);
        public Task<bool> Delete(bool isModelValid, string url);
    }
}
