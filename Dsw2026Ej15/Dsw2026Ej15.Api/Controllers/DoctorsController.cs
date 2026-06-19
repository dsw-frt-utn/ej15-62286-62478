using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Domain.Exceptions;
using Dsw2026Ej15.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2026Ej15.Api.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IPersistence _persistencia;
        public DoctorsController(IPersistence persistencia)
        {
            _persistencia = persistencia;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorModel.Request request)
        {
            if(string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.LicenseNumber))
            {
                throw new ValidationException("Nombre y numero de licencia requeridos");
            }

            var speciality = await _persistencia.GetSpecialityByIdAsync(request.SpecialityId);

            if (speciality == null)
            {
                throw new ValidationException("La especialidad no existe");
            }

            Doctor doctor = new(request.Name, request.LicenseNumber, speciality);
            await _persistencia.AgregarDoctorAsync(doctor);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _persistencia.GetAllDoctorsAsync();
            var activos = doctors.Where(d => d.IsActive == true);
            return Ok(activos);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var doctor = await _persistencia.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                throw new ValidationException("No se encontro al medico o esta inactivo");
            }
            var specialty = doctor.Speciality;
            DoctorModel.Response response = new(doctor.Name, doctor.LicenseNumber, specialty.Name);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorById(Guid id)
        {
            var eliminado = await _persistencia.EliminarDoctorPorIdAsync(id);
            if (eliminado == false)
            {
                throw new ValidationException("No se encontro al medico o esta inactivo");
            }
            return NoContent();
        }
    }
}
