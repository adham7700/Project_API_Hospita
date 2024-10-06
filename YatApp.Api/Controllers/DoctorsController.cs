using Dto;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using YatApp.Api;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : BaseApiController
    {

        public DoctorsController(IUnitOfWork unitofWork) : base(unitofWork)
        {
        }
        // GET: api/<DoctorsController>
        [HttpGet("GetAllAsy")]
        public async Task<IActionResult> GetAllAsy()
        {
            var doc = await _unitofWork.Doctors.GetAllAsync();
            return Ok(doc);

        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(DoctorDto dto)
        {
            //AutoMapper package
            Doctor Doctor = new Doctor()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ConsultationFee = dto.ConsultationFee,
                Availability = dto.Availability,
                ExperienceYears = dto.ExperienceYears,
                Qualifications = dto.Qualifications,
                Rating = dto.Rating,
                Image = dto.Image,
                Email = dto.Email,
                Phone = dto.Phone,
                Password = dto.Password,

                





            };
            var res = await _unitofWork.Doctors.AddAsync(Doctor);
            _unitofWork.Save();
            return Ok(Doctor);
        }



    }
}
