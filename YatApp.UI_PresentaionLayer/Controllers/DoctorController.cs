using ApiConsume;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ClinicManagement.UI_PresentaionLayer.Controllers
{
    public class DoctorController : Controller
    {
        private IApiCall _api;
        public DoctorController(IApiCall api)
        {
            _api = api;
        }
        public async Task<IActionResult> Index()
        {
            var doc =await _api.GetAllAsync<List<Doctor>>("Doctors/GetAllAsy");
            var t=doc.Count();
            return View(doc);
        }
    }
}
