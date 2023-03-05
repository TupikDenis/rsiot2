using Microsoft.AspNetCore.Mvc;
using webapi.Contracts.Services;
using webapi.DataTransferObjects;

namespace webapi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            _logger.LogInformation("got all users");

            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUserAsync(id);
            _logger.LogInformation($"got user by id: {id}");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserForManipulationDto userDto)
        {
            var user = await _userService.CreateUserAsync(userDto);
            _logger.LogInformation("user was created");

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserForManipulationDto userDto)
        {
            await _userService.UpdateUserAsync(id, userDto);
            _logger.LogInformation($"user was updated, id: {id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            _logger.LogInformation($"user was deleted, id: {id}");

            return NoContent();
        }
    }
}
