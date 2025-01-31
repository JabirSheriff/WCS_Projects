using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientService patientService, ILogger<PatientController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [Route("update")]
        [HttpPut]
        public async Task<ActionResult<Patient>> UpdatePatientDetails(PatientUpdateRequestDto patientUpdateRequestDto)
        {
            try
            {
                var patient = await _patientService.UpdatePatientDetails(patientUpdateRequestDto);
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
    }
}