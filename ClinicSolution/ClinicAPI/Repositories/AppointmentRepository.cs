using ClinicAPI.Contexts;
using ClinicAPI.Exceptions;
using ClinicAPI.Models;
using ClinicAPI.Interfaces;

namespace ClinicAPI.Repositories
{
    public class AppointmentRepository : Repository<string, Appointment>
    {
        public AppointmentRepository(ClinicContext context) : base(context) { }

        public async override Task<Appointment> Get(string key)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentNumber == key);
            if (appointment == null)
                throw new EntityNotFoundException("Appointment not found");
            return appointment;
        }

        public async override Task<IEnumerable<Appointment>> GetAll()
        {
            var appointments = _context.Appointments.ToList();
            if (appointments.Count == 0)
                throw new NoEntitiesFoundException("No appointments found");
            return appointments;
        }
    }
}
