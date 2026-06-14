using Dsw2026Ej15.Data.Dtos;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json;

namespace Dsw2026Ej15.Data
{
    public class PersistenceInMemory : IPersistence
    {
        private readonly List<Speciality> Specialities = [];
        private readonly List<Doctor> Doctors = [];
        public PersistenceInMemory()
        {
            InitializeDatos();
        }

        private void InitializeDatos()
        {
            InitializeSpecialities();
            InitializeDoctors();
        }

        private void InitializeSpecialities()
        {
            var especialidadesData = LoadSpecialities<SpecialityDto>("specialities");
            if (especialidadesData != null)
            {
                foreach (var data in especialidadesData)
                {
                        Speciality s = new(data.Name, data.Description, data.Id);
                        Specialities.Add(s);
                }
            }
        }

        private void InitializeDoctors()
        {
            var s1 = Specialities.Find(s => s.Name == "Cardiología");
            var s2 = Specialities.Find(s => s.Name == "Dermatología");
            var s3 = Specialities.Find(s => s.Name == "Traumatología");
            var s4 = Specialities.Find(s => s.Name == "Oftalmología");

            Doctor d1 = new("Sergio Perez", "5429", true, s3, Guid.Parse("4ab58e4f-4ad5-7bf5-75e5-5bf42a3f4bf1"));
            Doctor d2 = new("Nahuel Pennisi", "4263", true, s4, Guid.Parse("5f68dae2-e7ff-f4a5-9fd1-f4a5ba45b31f"));
            Doctor d3 = new("Carlos Alberto Solari", "4121", false, s1, Guid.Parse("ab58a6a2-f4a5-f7a5-a81f-7f4b2ad5f637"));
            Doctor d4 = new("Agustin Tapia", "7812", true, s2, Guid.Parse("a4b5afb4-f5be-d7bc-77dc-f4aa223fb6ba"));

            Doctors.Add(d1);
            Doctors.Add(d2);
            Doctors.Add(d3);
            Doctors.Add(d4);
        }

        private List<T>? LoadSpecialities<T>(string file)
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources", $"{file}.json");
            string jsonContent = File.ReadAllText(jsonPath);
            return JsonSerializer.Deserialize<List<T>>(jsonContent);
        }

        public List<Doctor> GetDoctors()
        {
            return Doctors;
        }
        public Doctor? GetDoctor(Guid id)
        {
            return Doctors.Find(d => d.Id == id);
        }

        public List<Speciality> GetSpecialities()
        {
            return Specialities;
        }
        public bool AgregarDoctor(Doctor doctor)
        {
            try
            {
                Doctors.Add(doctor);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
