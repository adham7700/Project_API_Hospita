

using Models;

namespace Interfaces;

public interface IUnitOfWork :IDisposable
{
    public IRepository<Appointment> Appointments { get;  }
    public IRepository<Doctor> Doctors { get; }
    public IRepository<Patient> Patients { get; }
    public IRepository<Gender> Genders { get; }
    public IRepository<Review> Reviews { get; }
    public IRepository<Specialization> Specializations { get; }
    int Save();
}
