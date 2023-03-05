using Microsoft.EntityFrameworkCore;
using webapi.Contracts.Repositories;
using webapi.Models;

namespace webapi.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateUser(User user) =>
            Create(user);

        public void DeleteUser(User user) =>
            Delete(user);

        public async Task<User> GetUserByIdAsync(Guid id) =>
            await GetByCondition(d => d.Id == id).SingleOrDefaultAsync();

        public async Task<IEnumerable<User>> GetUsersAsync() =>
            await GetAll().ToListAsync();

        public void UpdateUser(User user) =>
            Update(user);
    }
}
