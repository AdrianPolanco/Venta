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

        public IActionResult Filter(string filterOption)
        {
            switch (filterOption)
            {
                case "date":
                    return RedirectToAction("Index");
                case "role":
                    return RedirectToAction("GetByRole");
                case "name":
                    return RedirectToAction("GetByName");
                default:
                    return View(); // O puedes redirigir a una vista predeterminada
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string name, string email, int idRol, bool activo)
        {
            UserUpdateRequest userUpdateRequest = new() { Id = id, nombreCompleto = name, correo = email, idRol = idRol, esActivo = activo};
            return View(userUpdateRequest);
        }

        public async Task<IActionResult> GetByRole()
        {
            if (!ModelState.IsValid) return RedirectToAction("Error");

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:5205/api/users/roles"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
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
        public async Task<IActionResult> GetByName()
        {
            if (!ModelState.IsValid) return RedirectToAction("Error");

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:5205/api/users/names"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
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

        public async Task<IActionResult> UpdateUser(UserUpdateRequest request)
        {
            if (!ModelState.IsValid) return RedirectToAction("Error");

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("http://localhost:5205/api/users", content);


                if (!response.IsSuccessStatusCode)
                {
                    // Manejar el error de la solicitud a la API
                    ModelState.AddModelError(string.Empty, "Error al crear el usuario.");
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Error");

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var response = await httpClient.DeleteAsync($"http://localhost:5205/api/users/{id}");


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