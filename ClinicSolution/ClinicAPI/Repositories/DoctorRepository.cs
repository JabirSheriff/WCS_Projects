using ClinicAPI.Contexts;
using ClinicAPI.Exceptions;
using ClinicAPI.Models;
using ClinicAPI.Interfaces;
using ClinicAPI.Models.DTOs;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace ClinicAPI.Repositories
{
    public class DoctorRepository : Repository<string, Doctor>
    {
        public DoctorRepository(ClinicContext context) : base(context) { }

        public async override Task<Doctor> Get(string key)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.DoctorNumber == key);
            if (doctor == null)
                throw new EntityNotFoundException("Doctor not found");
            return doctor;
        }

        public async override Task<IEnumerable<Doctor>> GetAll()
        {
            var doctors = _context.Doctors.ToList();
            if (doctors.Count == 0)
                throw new NoEntitiesFoundException("No doctors found in database");
            return doctors;
        }
    }
}