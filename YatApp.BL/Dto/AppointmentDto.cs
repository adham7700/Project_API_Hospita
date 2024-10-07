using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.BL.Dto
{
    public class AppointmentDto
    {
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = string.Empty;
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        
    }
}
