using webapi.Contracts.Repositories;

namespace webapi.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private AppDbContext _context;
        private ISubjectRepository _subjectRepository;
        private IMarkRepository _markRepository;
        private IUserRepository _userRepository;

        public RepositoryManager(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public ISubjectRepository SubjectRepository
        {
            get
            {
                if (_subjectRepository == null)
                    _subjectRepository = new SubjectRepository(_context);
                return _subjectRepository;
            }
        }

        public IMarkRepository MarkRepository
        {
            get
            {
                if (_markRepository == null)
                    _markRepository = new MarkRepository(_context);
                return _markRepository;
            }
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
