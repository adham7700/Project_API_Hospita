using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Interfaces;
using YatApp.Api;
using Models;
using ClinicManagement.BL.Dto;

namespace ClinicsBookingDEPIProject.Controllers
{
    public class AppointmentController : BaseApiController
    {

        public AppointmentController(IUnitOfWork unitofWork) : base(unitofWork)
        {
        }

        //public AppointmentController(IGenericRepository<Appointment> context, IGenericRepository<Patient> patientcontext, IGenericRepository<Doctor> doctorcontext)
        //{
        //    this.context = context;
        //    this.patientcontext = patientcontext;
        //    this.doctorcontext = doctorcontext;
        //}
        // GET: AppointmentController


        [HttpGet]
        public IActionResult Index()
        {
            var appointments = _unitofWork.Appointments.GetAll();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var appointment = await _unitofWork.Appointments.GetByIdAsync(id); // Await the asynchronous call

            if (appointment == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return Ok(appointment); // Pass the appointment to the view
        }


        [HttpPost("create")]
        public IActionResult create(AppointmentDto dto)
        {
            Appointment appointment1 = new Appointment()
            {
                AppointmentDate = DateTime.Now,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                Status = dto.Status,
            };
            var appoint = _unitofWork.Appointments.Add(appointment1);
            _unitofWork.Save();
            return Ok(appoint);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            // Retrieve the appointment by ID
            var appointment = _unitofWork.Appointments.GetById(id);

            if (appointment == null)
            {
                // Return 404 if the appointment is not found
                return NotFound("Appointment not found.");
            }

            // Delete the appointment
            _unitofWork.Appointments.Delete(appointment);
            _unitofWork.Save();

            // Return a 204 No Content response to indicate successful deletion
            return NoContent();
        }

        [HttpGet("patient/{patientId}")]
        public IActionResult GetAppointmentsByPatient(int patientId)
        {
            // Retrieve all appointments for the specific patient
            var appointments = _unitofWork.Appointments.Find(a => a.PatientId == patientId);

            if (appointments == null)
            {
                return NotFound("No appointments found for this patient.");
            }

            return Ok(appointments);
        }


        //public async Task<IActionResult> AppointmentHistory(int patientId)
        //{
        //    // Retrieve all appointments for the patient
        //    var appointments = await context.Find(a => a.PatientId == patientId);

        //    // Create the view model
        //    var viewModel = new AppointmentHistoryViewModel
        //    {
        //        UpcomingAppointments = appointments
        //            .Where(a => a.AppointmentDate >= DateTime.Now)
        //            .Select(a => new AppointmentViewModel
        //            {
        //                AppointmentId = a.AppointmentId,
        //                DoctorName = $"{a.Doctor?.FirstName} {a.Doctor?.LastName}",
        //                DoctorAddress = a.Doctor?.Address,
        //                AppointmentDate = a.AppointmentDate,
        //                Status = a.Status
        //            }).ToList(),

        //        PreviousAppointments = appointments
        //            .Where(a => a.AppointmentDate < DateTime.Now)
        //            .Select(a => new AppointmentViewModel
        //            {
        //                AppointmentId = a.AppointmentId,
        //                DoctorName = $"{a.Doctor?.FirstName} {a.Doctor?.LastName}",
        //                DoctorAddress = a.Doctor?.Address,
        //                AppointmentDate = a.AppointmentDate,
        //                Status = a.Status
        //            }).ToList()
        //    };

        //    return View(viewModel);
        //}


    }

}
