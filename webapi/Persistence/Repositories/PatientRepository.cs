using Microsoft.EntityFrameworkCore;
using webapi.Contracts.Repositories;
using webapi.Models;

namespace webapi.Persistence.Repositories
{
    public class PatientRepository : RepositoryBase<Patient>, IPatienRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {
        }

        public void CreatePatient(Patient patient) =>
            Create(patient);

        public void DeletePatient(Patient patient) =>
            Delete(patient);

        public async Task<Patient> GetPatientByIdAsync(Guid id) =>
            await GetByCondition(p => p.Id == id).SingleOrDefaultAsync();

        public async Task<IEnumerable<Patient>> GetPatientsAsync() =>
            await GetAll().ToListAsync();

        public void UpdatePatient(Patient patient) =>
            Update(patient);
    }
}
