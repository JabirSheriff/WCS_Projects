using ClinicAPI.Models.DTOs;
using System.Threading.Tasks;

namespace ClinicAPI.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentResponseDto> CreateAppointment(AppointmentCreateDto appointmentCreateDto);
    }
}
