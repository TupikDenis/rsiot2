using Microsoft.AspNetCore.Mvc;
using webapi.Contracts.Services;
using webapi.DataTransferObjects;

namespace webapi.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly ILogger _logger;
        public DoctorsController(IDoctorService doctorService, ILogger<DoctorsController> logger)
        {
            _doctorService = doctorService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _doctorService.GetDoctorsAsync();
            _logger.LogInformation("got all doctors");

            return Ok(doctors);
        }

        [HttpGet("{id}", Name = "GetDoctor")]
        public async Task<IActionResult> GetDoctor(Guid id)
        {
            var doctor = await _doctorService.GetDoctorAsync(id);
            _logger.LogInformation($"got doctor by id: {id}");

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorForManipulationDto doctorDto)
        {
            var doctor = await _doctorService.CreateDoctorAsync(doctorDto);
            _logger.LogInformation("doctor was created");

            return CreatedAtRoute("GetDoctor", new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(Guid id, [FromBody] DoctorForManipulationDto doctorDto)
        {
            await _doctorService.UpdateDoctorAsync(id, doctorDto);
            _logger.LogInformation($"doctor was updated, id: {id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            _logger.LogInformation($"doctor was deleted, id: {id}");

            return NoContent();
        }
    }
}
