using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Models.DTOs;

namespace ClinicAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<string, Doctor> _doctorRepository;
        private readonly IRepository<string, User> _userRepository;

        public DoctorService(IRepository<string, Doctor> doctorRepository,
                             IRepository<string, User> userRepository)
        {
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
        }

        public async Task<DoctorRegisterResponseDto> RegisterDoctor(DoctorRegisterDto doctorRegisterDto)
        {
            var doctor = MapDtoToDoctor(doctorRegisterDto);
            var user = MapDtoToUser(doctorRegisterDto);
            doctor = await _doctorRepository.Add(doctor);
            user = await _userRepository.Add(user);
            return new DoctorRegisterResponseDto { DoctorNumber = doctor.DoctorNumber };
        }

        private Doctor MapDtoToDoctor(DoctorRegisterDto doctorRegisterDto)
        {
            return new Doctor
            {
                //DoctorNumber = doctorRegisterDto.,
                Name = doctorRegisterDto.Name,
                Experience = doctorRegisterDto.Experience,
                Email = doctorRegisterDto.Email,
                Phone = doctorRegisterDto.Phone,
                Status = "Active"
            };
        }

        private User MapDtoToUser(DoctorRegisterDto doctorRegisterDto)
        {
            User user = new User
            {
                Email = doctorRegisterDto.Email,
                Role = "Doctor"
            };
            return user;
        }
    }
}
