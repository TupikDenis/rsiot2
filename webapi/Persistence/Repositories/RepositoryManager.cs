using webapi.Contracts.Repositories;

namespace webapi.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private AppDbContext _context;
        private IPatienRepository _patienRepository;
        private IAppointmentRepository _appointmentRepository;
        private IDoctorRepository _doctorRepository;

        public RepositoryManager(AppDbContext context)
        {
            _context = context;
        }

        public IDoctorRepository DoctorRepository
        {
            get
            {
                if (_doctorRepository == null)
                    _doctorRepository = new DoctorRepository(_context);
                return _doctorRepository;
            }
        }

        public IPatienRepository PatienRepository
        {
            get
            {
                if (_patienRepository == null)
                    _patienRepository = new PatientRepository(_context);
                return _patienRepository;
            }
        }

        public IAppointmentRepository AppointmentRepository
        {
            get
            {
                if (_appointmentRepository == null)
                    _appointmentRepository = new AppointmentRepository(_context);
                return _appointmentRepository;
            }
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
