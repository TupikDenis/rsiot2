namespace webapi.Contracts.Repositories
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        IMarkRepository MarkRepository { get; }
        Task SaveChangesAsync();
    }
}
