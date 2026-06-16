using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data.Dtos
{
    internal class DoctorDto
    {
        public string Name { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public Guid SpecialityId { get; set; }
        public Guid Id { get; set; }
    }
}
