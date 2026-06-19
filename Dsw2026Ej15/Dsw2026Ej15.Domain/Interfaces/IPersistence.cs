using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        Task<bool> AgregarDoctorAsync(Doctor doctor);
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task<Doctor?> GetDoctorByIdAsync(Guid id);
        Task<List<Speciality>> GetSpecialitiesAsync();
        Task<bool> EliminarDoctorPorIdAsync(Guid id);
        Task<Speciality?> GetSpecialityByIdAsync(Guid id);
    }
}
