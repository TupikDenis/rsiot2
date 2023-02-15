using webapi.DataTransferObjects;
using webapi.Models;

namespace webapi.Contracts.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task<Appointment> GetAppointmentAsync(Guid id);
        Task<Appointment> CreateAppointmentAsync(AppointmentForManipulationDto appointmentDto);
        Task UpdateAppointmentAsync(Guid id, AppointmentForManipulationDto appointmentDto);
        Task DeleteAppointmentAsync(Guid id);
    }
}
