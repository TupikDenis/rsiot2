using webapi.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using webapi.Contracts.Services;

namespace webapi.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger _logger;
        public AppointmentsController(IAppointmentService appointmentService, ILogger<AppointmentsController> logger)
        {
            _appointmentService = appointmentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _appointmentService.GetAppointmentsAsync();
            _logger.LogInformation("got all appointments");

            return Ok(appointments);
        }

        [HttpGet("{id}", Name = "GetAppointment")]
        public async Task<IActionResult> GetAppointment(Guid id)
        {
            var appointment = await _appointmentService.GetAppointmentAsync(id);
            _logger.LogInformation($"got appointment by id: {id}");

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentForManipulationDto appointmentDto)
        {
            var appointment = await _appointmentService.CreateAppointmentAsync(appointmentDto);
            _logger.LogInformation("appointment was created");

            return CreatedAtRoute("GetAppointment", new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] AppointmentForManipulationDto appointmentDto)
        {
            await _appointmentService.UpdateAppointmentAsync(id, appointmentDto);
            _logger.LogInformation($"appointment was updated, id: {id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);
            _logger.LogInformation($"appointment was deleted, id: {id}");

            return NoContent();
        }
    }
}
