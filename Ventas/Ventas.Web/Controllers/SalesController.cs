using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Ventas.Web.Models.Requests;
using Ventas.Web.Models.Responses;

namespace Ventas.Web.Controllers
{
    public class SalesController : Controller
    {
        private readonly ILogger<SalesController> _logger;
        private HttpClientHandler _httpClientHandler = new HttpClientHandler();

        public SalesController(ILogger<SalesController> logger)
        {
            _logger = logger;
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }
        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:5205/api/sales"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ResponseResult<List<SaleGetResponse>> rawResult = JsonConvert.DeserializeObject<ResponseResult<List<SaleGetResponse>>>(apiResponse);

                        if (rawResult.Success && rawResult.Result is not null)
                        {
                            List<SaleGetResponse> users = rawResult.Result.Select(e => e).ToList();
                            return View(users);

                        }
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Update(int id, string numeroDocumento, string pago, decimal total, DateTime fechaRegistro)
        {
            SaleUpdateRequest saleUpdateRequest = new() { Id = id, numeroDocumento = numeroDocumento, tipoPago = pago, total = total, fechaRegistro = fechaRegistro };
            return View(saleUpdateRequest);
        }

        public async Task<IActionResult> UpdateSale(SaleUpdateRequest request)
        {
            if (!ModelState.IsValid) return RedirectToAction("Error");

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("http://localhost:5205/api/sales", content);


                if (!response.IsSuccessStatusCode)
                {
                    // Manejar el error de la solicitud a la API
                    ModelState.AddModelError(string.Empty, "Error al crear el usuario.");
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(SaleCreateRequest request)
        {
            if (!ModelState.IsValid) return RedirectToAction("Error");

            SaleCreateRequest salesCreateRequest = new SaleCreateRequest
            {
                numeroDocumento = request.numeroDocumento,
                tipoPago = request.tipoPago,
                total = request.total,
            };

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var content = new StringContent(JsonConvert.SerializeObject(salesCreateRequest), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5205/api/sales", content);


                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el usuario.");
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSale(int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Error");

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var response = await httpClient.DeleteAsync($"http://localhost:5205/api/sales/{id}");


                if (!response.IsSuccessStatusCode)
                {
                    // Manejar el error de la solicitud a la API
                    ModelState.AddModelError(string.Empty, "Error al crear el usuario.");
                }
                return RedirectToAction("Index");
            }
        }
    }
}
