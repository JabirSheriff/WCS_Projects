using ClinicAPI.Models.DTOs;
using System.Threading.Tasks;

namespace ClinicAPI.Interfaces
{
    public interface IDoctorService
    {
        
        Task<DoctorRegisterResponseDto> RegisterDoctor(DoctorRegisterDto doctorRegisterDto);
    }
}
