using ClinicAPI.Contexts;
using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicTest
{
    public class Tests
    {
        IRepository<int, Patient> _patientRepository;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<ClinicContext> options = new DbContextOptionsBuilder<ClinicContext>()
                 .UseInMemoryDatabase(databaseName: "Test")
                 .Options;
            ClinicContext context = new ClinicContext(options);
            _patientRepository = new PatientRepository(context);

        }

        [Test]
        public async Task AddPatientTest()
        {
            //Arrange
            Patient patient = new Patient()
            {
                Name = "Ramu",
                Age = 25,
                Email = "ramu@gmail.com",
                Phone = 9876543210,
                Status = "Active"
            };
            //Action
            var result = await _patientRepository.Add(patient);
            //Assert
            Assert.IsTrue(result.Id > 0);
        }
        [Test]
        public async Task GetPatientPassTest()
        {
            //Arrange
            Patient patient = new Patient()
            {
                Name = "Ramu",
                Age = 25,
                Email = "ramu@gmail.com",
                Phone = 9876543210,
                Status = "Active"
            };
            var result = await _patientRepository.Add(patient);
            //Action
            var patientResult = await _patientRepository.Get(result.Id);
            //Assert
            Assert.IsTrue(patientResult.Id == result.Id);
        }
        [Test]
        public async Task GetPatientFailTest()
        {
            //Arrange
            Patient patient = new Patient()
            {
                Name = "Ramu",
                Age = 25,
                Email = "ramu@gmail.com",
                Phone = 9876543210,
                Status = "Active"
            };
            var result = await _patientRepository.Add(patient);
            //Action
            var patientResult = await _patientRepository.Get(result.Id);
            //Assert
            Assert.That(patientResult.Id==(result.Id+1));
        }
        [Test]
        public async Task GetPatientExceptionTest()
        {
            //Arrange
            Patient patient = new Patient()
            {
                Name = "Ramu",
                Age = 25,
                Email = "ramu@gmail.com",
                Phone = 9876543210,
                Status = "Active"
            };
            var result = await _patientRepository.Add(patient);
            //Action
           
            //Assert
            Assert.ThrowsAsync<EntityNotFoundException>(() => _patientRepository.Get((result.Id + 1)));
        }
    }
}