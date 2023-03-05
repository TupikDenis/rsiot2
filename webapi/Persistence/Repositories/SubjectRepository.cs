using Microsoft.EntityFrameworkCore;
using webapi.Contracts.Repositories;
using webapi.Models;

namespace webapi.Persistence.Repositories
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateSubject(Subject subject) =>
            Create(subject);

        public void DeleteSubject(Subject subject) =>
            Delete(subject);

        public async Task<Subject> GetSubjectByIdAsync(Guid id) =>
            await GetByCondition(p => p.Id == id).SingleOrDefaultAsync();

        public async Task<IEnumerable<Subject>> GetSubjectsAsync() =>
            await GetAll().ToListAsync();

        public void UpdateSubject(Subject subject) =>
            Update(subject);
    }
}
