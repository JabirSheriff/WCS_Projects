using ClinicAPI.Models;
using ClinicAPI.Models.DTOs;

namespace ClinicAPI.Interfaces
{
    public interface IPatientService
    {
        Task<PatientRegisterResponseDto> RegisterPatient(PatientRegisterDto patientRegisterDto);
        Task<Patient> UpdatePatientDetails(PatientUpdateRequestDto patientUpdateRequestDto);
    }
}