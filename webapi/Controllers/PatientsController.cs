using Microsoft.AspNetCore.Mvc;
using webapi.Contracts.Services;
using webapi.DataTransferObjects;

namespace webapi.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger _logger;
        public PatientsController(IPatientService patientService, ILogger<PatientsController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _patientService.GetPatientsAsync();
            _logger.LogInformation("got all patients");

            return Ok(patients);
        }

        [HttpGet("{id}", Name = "GetPatient")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var patient = await _patientService.GetPatientAsync(id);
            _logger.LogInformation($"got patient by id: {id}");

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientForManipulationDto patientDto)
        {
            var patient = await _patientService.CreatePatientAsync(patientDto);
            _logger.LogInformation("patient was created");

            return CreatedAtRoute("GetPatient", new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] PatientForManipulationDto patientDto)
        {
            await _patientService.UpdatePatientAsync(id, patientDto);
            _logger.LogInformation($"patient was updated, id: {id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            await _patientService.DeletePatientAsync(id);
            _logger.LogInformation($"patient was deleted, id: {id}");

            return NoContent();
        }
    }
}
