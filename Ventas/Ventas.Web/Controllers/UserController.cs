using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ventas.Web.Models;
using Ventas.Web.Models.Responses;
using Ventas.Web.Models.Requests;
using Ventas.Web.Services.Abstractions;

namespace Ventas.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpService _httpService;

        public UserController(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<IActionResult> Index()
        {
            List<UserGetResponse> users = await _httpService.Get<UserGetResponse>("http://localhost:5205/api/users");
            if (users is not null) return View(users);

            ModelState.AddModelError(string.Empty, "Error al recuperar los usuarios.");
            return View("Error");
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
            List<UserGetResponse> users = await _httpService.Get<UserGetResponse>("http://localhost:5205/api/users/roles");
            if (users is not null) return View(users);

            ModelState.AddModelError(string.Empty, "Error al recuperar los usuarios.");
            return View("Error");
          
           }
           public async Task<IActionResult> GetByName()
           {
                List<UserGetResponse> users = await _httpService.Get<UserGetResponse>("http://localhost:5205/api/users/names");
                if (users is not null) return View(users);

                ModelState.AddModelError(string.Empty, "Error al recuperar los usuarios.");
                return View("Error");
           }
           public async Task<IActionResult> CreateUser(UserCreateRequest request)
           {

                bool operationIsSuccessful = await _httpService.Post(ModelState.IsValid,"http://localhost:5205/api/users", request);
                if (operationIsSuccessful) return RedirectToAction("Index");
                ModelState.AddModelError(string.Empty, "Error al crear el usuario.");
                return View("Error");
        }

          public async Task<IActionResult> UpdateUser(UserUpdateRequest request)
           {
            bool wasRequestSuccessful = await _httpService.Put(ModelState.IsValid, "http://localhost:5205/api/users", request);
            if (wasRequestSuccessful is false)
            {
                ModelState.AddModelError(string.Empty, "Error al editar el usuario.");
                return View("Error");
            }

               return RedirectToAction("Index");              
           }

        
           [HttpPost]
           public async Task<IActionResult> DeleteUser(int id)
           {
                bool wasRequestSuccessful = await _httpService.Delete(ModelState.IsValid, $"http://localhost:5205/api/users/{id}");

                if (wasRequestSuccessful is false)
                {
                    ModelState.AddModelError(string.Empty, "Error al eliminar el usuario.");
                    return View("Error");
                }

                return RedirectToAction("Index");
           }
           

           [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
           public IActionResult Error()
           {
               return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
           }
    }
}
