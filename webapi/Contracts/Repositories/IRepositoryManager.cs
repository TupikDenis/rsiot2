namespace webapi.Contracts.Repositories
{
    public interface IRepositoryManager
    {
        IDoctorRepository DoctorRepository { get; }
        IPatienRepository PatienRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        Task SaveChangesAsync();
    }
}
