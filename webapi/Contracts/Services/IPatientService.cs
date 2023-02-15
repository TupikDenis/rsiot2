using webapi.DataTransferObjects;
using webapi.Models;

namespace webapi.Contracts.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientAsync(Guid id);
        Task<Patient> CreatePatientAsync(PatientForManipulationDto patientDto);
        Task UpdatePatientAsync(Guid id, PatientForManipulationDto patientDto);
        Task DeletePatientAsync(Guid id);
    }
}
