using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        Task<bool> AgregarDoctorAsync(Doctor doctor);
        Task<List<Doctor>> GetDoctorsAsync();
        Task<Doctor?> GetDoctorAsync(Guid id);
        Task<List<Speciality>> GetSpecialitiesAsync();
    }
}
