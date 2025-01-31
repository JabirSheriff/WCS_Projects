using ClinicAPI.Models;
using ClinicAPI.Models.DTOs;
using ClinicAPI.Interfaces;

namespace ClinicAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<string, Appointment> _appointmentRepository;
        private readonly IRepository<int, Patient> _patientRepository;
        private readonly IRepository<string, Doctor> _doctorRepository;

        public AppointmentService(IRepository<string, Appointment> appointmentRepository,
                                  IRepository<int, Patient> patientRepository,
                                  IRepository<string, Doctor> doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<AppointmentResponseDto> CreateAppointment(AppointmentCreateDto appointmentCreateDto)
        {
            var patient = await _patientRepository.Get(appointmentCreateDto.PatientId);
            var doctor = await _doctorRepository.Get(appointmentCreateDto.DoctorNumber);

            var appointment = new Appointment
            {
                AppointmentNumber = Guid.NewGuid().ToString(),  // Generate appointment number
                DoctorNumber = doctor.DoctorNumber,
                PatientId = patient.Id,
                AppointmentDate = appointmentCreateDto.AppointmentDate,
                Status = "Scheduled",
                Remarks = appointmentCreateDto.Remarks
            };

            appointment = await _appointmentRepository.Add(appointment);

            return new AppointmentResponseDto
            {
                AppointmentNumber = appointment.AppointmentNumber,
                DoctorName = doctor.Name,
                PatientName = patient.Name,
                AppointmentDate = appointment.AppointmentDate
            };
        }
    }
}
