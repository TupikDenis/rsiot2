using Microsoft.EntityFrameworkCore;
using webapi.Contracts.Repositories;
using webapi.Models;

namespace webapi.Persistence.Repositories
{
    public class MarkRepository : RepositoryBase<Mark>, IMarkRepository
    {
        public MarkRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateMark(Mark mark) =>
            Create(mark);

        public void DeleteMark(Mark mark) =>
            Delete(mark);

        public async Task<IEnumerable<Mark>> GetMarksAsync() =>
            await GetAll().ToListAsync();

        public async Task<Mark> GetMarkByIdAsync(Guid id) =>
            await GetByCondition(a => a.Id == id)
            .SingleOrDefaultAsync();

        public void UpdateMark(Mark mark) =>
            Update(mark);
    }
}
