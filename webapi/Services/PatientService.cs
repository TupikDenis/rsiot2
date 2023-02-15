using AutoMapper;
using webapi.Contracts.Repositories;
using webapi.Contracts.Services;
using webapi.DataTransferObjects;
using webapi.Exceptions;
using webapi.Models;

namespace webapi.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public PatientService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Patient> CreatePatientAsync(PatientForManipulationDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            _repositoryManager.PatienRepository.CreatePatient(patient);
            await _repositoryManager.SaveChangesAsync();

            return patient;
        }

        public async Task DeletePatientAsync(Guid id)
        {
            var patient = await _repositoryManager.PatienRepository.GetPatientByIdAsync(id);
            if (patient == null)
                throw new NotFoundException("patient not found");
            _repositoryManager.PatienRepository.DeletePatient(patient);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<Patient> GetPatientAsync(Guid id)
        {
            var patient = await _repositoryManager.PatienRepository.GetPatientByIdAsync(id);
            if(patient == null)
                throw new NotFoundException("patient not found");
            return patient;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync() =>
            await _repositoryManager.PatienRepository.GetPatientsAsync();

        public async Task UpdatePatientAsync(Guid id, PatientForManipulationDto patientDto)
        {
            var patient = await _repositoryManager.PatienRepository.GetPatientByIdAsync(id);
            if (patient == null)
                throw new NotFoundException("patient not found");

            _mapper.Map(patientDto, patient);

            _repositoryManager.PatienRepository.UpdatePatient(patient);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
