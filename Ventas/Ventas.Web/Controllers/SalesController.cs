using Microsoft.AspNetCore.Mvc;
using Ventas.Web.Models.Requests;
using Ventas.Web.Models.Responses;
using Ventas.Web.Services.Abstractions;

namespace Ventas.Web.Controllers
{
    public class SalesController : Controller
    {
        private readonly IHttpService _httpService;

        public SalesController(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<IActionResult> Index()
        {
            List<SaleGetResponse> users = await _httpService.Get<SaleGetResponse>("http://localhost:5205/api/sales");
            if (users is not null) return View(users);

            ModelState.AddModelError(string.Empty, "Error al recuperar las ventas.");
            return View("Error");
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
            bool wasRequestSuccessful = await _httpService.Put(ModelState.IsValid, "http://localhost:5205/api/sales", request);
            if (wasRequestSuccessful is false)
            {
                ModelState.AddModelError(string.Empty, "Error al editar la venta.");
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(SaleCreateRequest request)
        {

            bool operationIsSuccessful = await _httpService.Post(ModelState.IsValid, "http://localhost:5205/api/sales", request);
            if (operationIsSuccessful) return RedirectToAction("Index");
            ModelState.AddModelError(string.Empty, "Error al crear la venta.");
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSale(int id)
        {
            bool wasRequestSuccessful = await _httpService.Delete(ModelState.IsValid, $"http://localhost:5205/api/sales/{id}");

            if (wasRequestSuccessful is false)
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar la venta.");
                return View("Error");
            }

            return RedirectToAction("Index");
        }
    }
}
