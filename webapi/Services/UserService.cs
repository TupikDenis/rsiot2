using AutoMapper;
using webapi.Contracts.Repositories;
using webapi.Contracts.Services;
using webapi.DataTransferObjects;
using webapi.Exceptions;
using webapi.Models;

namespace webapi.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<User> CreateUserAsync(UserForManipulationDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            _repositoryManager.UserRepository.CreateUser(user);
            await _repositoryManager.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _repositoryManager.UserRepository.GetUserByIdAsync(id);
            if (user == null)
                throw new NotFoundException("user not found");

            _repositoryManager.UserRepository.DeleteUser(user);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await _repositoryManager.UserRepository.GetUserByIdAsync(id);
            if (user == null)
                throw new NotFoundException("user not found");

            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync() =>
            await _repositoryManager.UserRepository.GetUsersAsync();

        public async Task UpdateUserAsync(Guid id, UserForManipulationDto userDto)
        {
            var user = await _repositoryManager.UserRepository.GetUserByIdAsync(id);
            if (user == null)
                throw new NotFoundException("user not found");

            _mapper.Map(userDto, user);

            _repositoryManager.UserRepository.UpdateUser(user);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
