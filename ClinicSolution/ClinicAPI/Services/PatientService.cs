using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace ClinicAPI.Services
{
    public class PatientService : IPatientService, IAuthorize<Patient, LoginResponseDto>
    {
        private readonly IRepository<int, Patient> _patientRepository;
        private readonly IRepository<string, User> _userRepository;

        public PatientService(IRepository<int, Patient> patientRepository,
                            IRepository<string, User> userRepository)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;

        }
        public async Task<PatientRegisterResponseDto> RegisterPatient(PatientRegisterDto patientRegisterDto)
        {
            var patient = MapDtoToPatient(patientRegisterDto);
            var user = MapDtoToUser(patientRegisterDto);
            user = await _userRepository.Add(user);
            patient = await _patientRepository.Add(patient);
            return new PatientRegisterResponseDto { PatientId = patient.Id };
        }
        public Patient MapDtoToPatient(PatientRegisterDto patientRegisterDto)
        {
            if (patientRegisterDto.Age < 18)
                throw new Exception("Invalid patient age");
            return new Patient
            {
                Name = patientRegisterDto.Name,
                Age = patientRegisterDto.Age,
                Email = patientRegisterDto.Email,
                Phone = patientRegisterDto.Phone,
                Status = "Active"
            };
        }
        public User MapDtoToUser(PatientRegisterDto patientRegisterDto)
        {
            User user = new User
            {
                Email = patientRegisterDto.Email,

                Role = "Patient"
            };
            HMACSHA512 hMACSHA512 = new HMACSHA512();
            byte[] passwordHash = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(patientRegisterDto.Password));
            user.Password = passwordHash;
            user.HasKey = hMACSHA512.Key;
            return user;
        }

        public async Task<LoginResponseDto> Login(string email, string password)
        {
            var user = await _userRepository.Get(email);
            if (user == null)
            {
                throw new InvalidUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA512 = new HMACSHA512(user.HasKey);
            byte[] passwordHash = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(password));
            if (user.Password.SequenceEqual(passwordHash))
            {
                if (user.Role == "Patient")
                {
                    var patient = await GetPatientUsingEmail(email);
                    if (patient != null && patient.Status == "Active")
                        return new LoginResponseDto
                        {
                            Email = email,
                            Role = user.Role,
                            Name = patient.Name
                        };
                }
            }
            throw new InvalidUserException("Invalid username or password");

        }

        private async Task<Patient?> GetPatientUsingEmail(string email)
        {
            var patient = (await _patientRepository.GetAll()).FirstOrDefault(p => p.Email == email);
            return patient;
        }

        public async Task<Patient> UpdatePatientDetails(PatientUpdateRequestDto patientUpdateRequestDto)
        {
            var patient = await _patientRepository.Get(patientUpdateRequestDto.Id);
            if (patient == null)
            {
                throw new EntityNotFoundException("Patient not found");
            }
            if (patientUpdateRequestDto.Status != null)
            {
                patient.Status = patientUpdateRequestDto.Status;
                if (Update(patient) == null)
                {
                    throw new Exception("Patient status not updated");
                }
                return patient;
            }
            if (patient.Status == "Inactive")
            {
                throw new Exception("Patient is inactive");
            }
            if (patientUpdateRequestDto.Age != null)
            {
                patient.Age = (int)patientUpdateRequestDto.Age;
            }
            if (patientUpdateRequestDto.Phone != null)
            {
                patient.Phone = (decimal)patientUpdateRequestDto.Phone;
            }
            if (Update(patient) == null)
            {
                throw new Exception("Patient status not updated");
            }
            return patient;

        }
        private Patient? Update(Patient patient)
        {
            if (_patientRepository.Update(patient) == null)
            {
                return null;
            }
            return patient;
        }
    }
}