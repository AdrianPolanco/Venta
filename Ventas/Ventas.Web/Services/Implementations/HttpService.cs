using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Ventas.Web.Models.Responses;
using Ventas.Web.Services.Abstractions;

namespace Ventas.Web.Services.Implementations
{
    public class HttpService : IHttpService
    {

        private HttpClientHandler _httpClientHandler = new HttpClientHandler();
        public HttpService()
        {
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }
        public async Task<List<T>?> Get<T>(string url)
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ResponseResult<List<T>> rawResult = JsonConvert.DeserializeObject<ResponseResult<List<T>>>(apiResponse);

                        if (rawResult.Success && rawResult.Result is not null)
                        {
                            List<T> users = rawResult.Result.Select(e => e).ToList();
                            return users;

                        }
                    }
                }
            }
            return null;
        }

        public async Task<bool> Post<T>(bool isModelValid, string url, T request)
        {
            if (isModelValid is false) return false;

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);


                if (!response.IsSuccessStatusCode) return false;
                // Manejar el error de la solicitud a la API
                // ModelState.AddModelError(string.Empty, "Error al crear el usuario.");

                return true; // RedirectToAction("Index");
            }
        }

        public async Task<bool> Put<T>(bool isModelValid, string url, T request)
        {
            if (isModelValid is false) return false;

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, content);


                if (!response.IsSuccessStatusCode) return false;

                return true;
            }
        }

        public async Task<bool> Delete(bool isModelValid, string url)
        {
            if (isModelValid is false) return false;

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var response = await httpClient.DeleteAsync(url);


                if (!response.IsSuccessStatusCode) return false;
                // Manejar el error de la solicitud a la API
                //

                return true;
            }
        }
    }
}

