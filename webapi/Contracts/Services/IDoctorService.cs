using webapi.DataTransferObjects;
using webapi.Models;

namespace webapi.Contracts.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<Doctor> GetDoctorAsync(Guid id);
        Task<Doctor> CreateDoctorAsync(DoctorForManipulationDto doctorDto);
        Task UpdateDoctorAsync(Guid id, DoctorForManipulationDto doctorDto);
        Task DeleteDoctorAsync(Guid id);
    }
}