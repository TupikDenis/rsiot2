using Microsoft.AspNetCore.Mvc;
using webapi.Contracts.Services;
using webapi.DataTransferObjects;

namespace webapi.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly ILogger _logger;
        public SubjectsController(ISubjectService subjectService, ILogger<SubjectsController> logger)
        {
            _subjectService = subjectService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            var subjects = await _subjectService.GetSubjectsAsync();
            _logger.LogInformation("got all subjects");

            return Ok(subjects);
        }

        [HttpGet("{id}", Name = "GetSubject")]
        public async Task<IActionResult> GetSubject(Guid id)
        {
            var subject = await _subjectService.GetSubjectAsync(id);
            _logger.LogInformation($"got subject by id: {id}");

            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] SubjectForManipulationDto subjectDto)
        {
            var subject = await _subjectService.CreateSubjectAsync(subjectDto);
            _logger.LogInformation("subject was created");

            return CreatedAtRoute("GetSubject", new { id = subject.Id }, subject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(Guid id, [FromBody] SubjectForManipulationDto subjectDto)
        {
            await _subjectService.UpdateSubjectAsync(id, subjectDto);
            _logger.LogInformation($"subject was updated, id: {id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            await _subjectService.DeleteSubjectAsync(id);
            _logger.LogInformation($"subject was deleted, id: {id}");

            return NoContent();
        }
    }
}
