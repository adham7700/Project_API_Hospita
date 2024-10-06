using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models;

public class Appointment
{
    [Key]
    public int AppointmentId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public DateTime AppointmentDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(50, ErrorMessage = "{0} must be a maximum of 50 characters")]
    public string Status { get; set; } = string.Empty;

    [ForeignKey("Patient")]
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    [ForeignKey("Doctor")]
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
}
