using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using Ventas.Web.Models;
using Ventas.Web.Models.Responses;
using Newtonsoft.Json;
using Ventas.Web.Models.Requests;
using System.Text;

namespace Ventas.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private HttpClientHandler _httpClientHandler = new HttpClientHandler();

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        public async Task<IActionResult> Index()
        {
            using(var httpClient = new HttpClient(_httpClientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:5205/api/users"))
                {
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ResponseResult<List<UserGetResponse>> rawResult = JsonConvert.DeserializeObject<ResponseResult<List<UserGetResponse>>>(apiResponse);

                        if (rawResult.Success && rawResult.Result is not null)
                        {
                            List<UserGetResponse> users = rawResult.Result.Select(e => e).ToList();
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
     

        public async Task<IActionResult> CreateUser(UserCreateRequest request)
        {

            if (!ModelState.IsValid) return RedirectToAction("Error");

            UserCreateRequest userCreateRequest = new()
            {
                nombreCompleto = request.nombreCompleto,
                correo = request.correo,
                clave = request.clave,
                idRol = request.idRol,
                esActivo = request.esActivo,
            };

            using (var httpClient = new HttpClient(_httpClientHandler))
            { 
               var content = new StringContent(JsonConvert.SerializeObject(userCreateRequest), Encoding.UTF8, "application/json");
               var response = await httpClient.PostAsync("http://localhost:5205/api/users", content);
           

                if (!response.IsSuccessStatusCode)
                {
                    // Manejar el error de la solicitud a la API
                    ModelState.AddModelError(string.Empty, "Error al crear el usuario.");
                }
                return RedirectToAction("Index"); 
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}