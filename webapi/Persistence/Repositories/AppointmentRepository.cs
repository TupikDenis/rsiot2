using Microsoft.EntityFrameworkCore;
using webapi.Contracts.Repositories;
using webapi.Models;

namespace webapi.Persistence.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateAppointment(Appointment appointment) =>
            Create(appointment);

        public void DeleteAppointment(Appointment appointment) =>
            Delete(appointment);

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync() =>
            await GetAll().ToListAsync();

        public async Task<Appointment> GetAppointmentByIdAsync(Guid id) =>
            await GetByCondition(a => a.Id == id)
            .SingleOrDefaultAsync();

        public void UpdateAppointment(Appointment appointment) =>
            Update(appointment);
    }
}
