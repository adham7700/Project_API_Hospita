using ApiConsume;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace YatApp.UI_PresentaionLayer.Controllers
{
    public class PatientController : Controller
    {
        private IApiCall _api;

        public PatientController(IApiCall api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
           
            return View();
        }

        public async Task<IActionResult> SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(PatientDto dto)
        {
            if (ModelState.IsValid)
            {
                var res =await _api.GetByIdAsync<bool>($"Patient/isValidEmail?email={dto.Email}");
                if (res)
                {
                    await _api.CreateAsync<PatientDto>("Patient/AddAsync", dto);

                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError("Email", "this mail already exist");
                    return View( );
                }
            }
          return View();
        }
    }
}
