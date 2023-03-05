using webapi.DataTransferObjects;
using webapi.Models;

namespace webapi.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid id);
        Task<User> CreateUserAsync(UserForManipulationDto userDto);
        Task UpdateUserAsync(Guid id, UserForManipulationDto userDto);
        Task DeleteUserAsync(Guid id);
    }
}