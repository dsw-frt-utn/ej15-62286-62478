using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        bool AgregarDoctor(Doctor doctor);
        List<Doctor> GetDoctors();
        Doctor? GetDoctor(Guid id);
        List<Speciality> GetSpecialities();
    }
}
