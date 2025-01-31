using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Misc;
using ClinicAPI.Models;
using ClinicAPI.Models.DTOs;
using ClinicAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class AuthenticatePatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IAuthorize<Patient, LoginResponseDto> _authorize;
        private readonly ILogger<AuthenticatePatientController> _logger;

        public AuthenticatePatientController(IPatientService patientService,
                                    IAuthorize<Patient, LoginResponseDto> authorize,
                                    ILogger<AuthenticatePatientController> logger)
        {
            _patientService = patientService;
            _authorize = authorize;
            _logger = logger;
        }


        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<PatientRegisterResponseDto>> RegisterPatient(PatientRegisterDto patientRegisterDto)
        {
            try
            {
                var patient = await _patientService.RegisterPatient(patientRegisterDto);
                return Ok(patient);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(new ErrorObjectDto { ErrorNumber = 404, Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorObjectDto { ErrorNumber = 500, Message = e.Message });
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> LoginPatient(LoginDto login)
        {
            try
            {
                var user = await _authorize.Login(login.Username, login.Password);
                return Ok(user);
            }
            catch (InvalidUserException e)
            {
                _logger.LogError(e.Message);
                return Unauthorized(new ErrorObjectDto { ErrorNumber = 401, Message = e.Message });
            }
            //catch (Exception e)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorObjectDto { ErrorNumber = 500, Message = e.Message });
            //}
        }
    }
}