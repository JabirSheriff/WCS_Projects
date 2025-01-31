using ClinicAPI.Contexts;
using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Models.DTOs;
using ClinicAPI.Repositories;
using ClinicAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace ClinicTest
{
    public class PatientServiceTest
    {
        IPatientService patientService;
        public PatientServiceTest()
        {
            DbContextOptions<ClinicContext> options = new DbContextOptionsBuilder<ClinicContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            ClinicContext context = new ClinicContext(options);
            IRepository<int, Patient> _patientRepository = new PatientRepository(context);
            IRepository<string, User> _userRepository = new UserRepository(context);
            patientService = new PatientService(_patientRepository, _userRepository);

        }
        [TestCase(18,"Somu","somu@gmail.com", 9876543210d, "somu123")]
        [TestCase(19, "Bimu", "bimu@gmail.com", 5432109876d, "bimu123")]

        public async Task AddPatientTest(int age,string name,string email,decimal phone,string password)
        {
            //Arrange
            var PatientDto = new PatientRegisterDto
            {
                Age = age,
                Email = email,
                Name = name,
                Password =password,
                Phone = phone
            };
            //Action
            var result = await patientService.RegisterPatient(PatientDto);
            //Assert
            Assert.That(result.PatientId, Is.GreaterThan(0));
        }
    }
}
