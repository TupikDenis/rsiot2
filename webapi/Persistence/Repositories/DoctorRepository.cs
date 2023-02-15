using Microsoft.EntityFrameworkCore;
using webapi.Contracts.Repositories;
using webapi.Models;

namespace webapi.Persistence.Repositories
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateDoctor(Doctor doctor) =>
            Create(doctor);

        public void DeleteDoctor(Doctor doctor) =>
            Delete(doctor);

        public async Task<Doctor> GetDoctorByIdAsync(Guid id) =>
            await GetByCondition(d => d.Id == id).SingleOrDefaultAsync();

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync() =>
            await GetAll().ToListAsync();

        public void UpdateDoctor(Doctor doctor) =>
            Update(doctor);
    }
}
