using ClinicAPI.Contexts;
using ClinicAPI.Exceptions;
using ClinicAPI.Models;

namespace ClinicAPI.Repositories
{
    public class PatientRepository : Repository<int, Patient>
    {
        public PatientRepository(ClinicContext context) : base(context)
        {
        }
        public async override Task<Patient> Get(int key)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.Id == key);
            if(patient == null)
            {
                throw new EntityNotFoundException("Patient not found");
            }
            return patient;
        }

        public async override Task<IEnumerable<Patient>> GetAll()
        {
            var patients = _context.Patients.ToList();
            if(patients.Count == 0)
            {
                throw new NoEntitiesFoundException("No patients found in database");
            }
            return patients;
        }
    }
}
