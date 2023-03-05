using webapi.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using webapi.Contracts.Services;

namespace webapi.Controllers
{
    [Route("api/marks")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IMarkService _markService;
        private readonly ILogger _logger;
        private readonly IPubService _pubService;
        private readonly ISubService _subService;
        public MarksController(IMarkService markService, ILogger<MarksController> logger,
            IPubService pubService, ISubService subService)
        {
            _markService = markService;
            _logger = logger;
            _pubService = pubService;
            _subService = subService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMarks()
        {
            var Marks = await _markService.GetMarksAsync();
            _logger.LogInformation("got all Marks");

            return Ok(Marks);
        }

        [HttpGet("{id}", Name = "GetMark")]
        public async Task<IActionResult> GetMark(Guid id)
        {
            var Mark = await _markService.GetMarkAsync(id);
            _logger.LogInformation($"got Mark by id: {id}");

            return Ok(Mark);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMark([FromBody] MarkForManipulationDto MarkDto)
        {
            await _pubService.Publish("test message from webapi");
            _logger.LogInformation("message was send to topic");

            var message = await _subService.Receive();

            if(message == "false")
                return BadRequest(message);

            var Mark = await _markService.CreateMarkAsync(MarkDto);
            _logger.LogInformation("Mark was created");

            return CreatedAtRoute("GetMark", new { id = Mark.Id }, Mark);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMark(Guid id, [FromBody] MarkForManipulationDto markDto)
        {
            await _markService.UpdateMarkAsync(id, markDto);
            _logger.LogInformation($"Mark was updated, id: {id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMark(Guid id)
        {
            await _markService.DeleteMarkAsync(id);
            _logger.LogInformation($"Mark was deleted, id: {id}");

            return NoContent();
        }
    }
}
