using AutoMapper;
using webapi.Contracts.Repositories;
using webapi.Contracts.Services;
using webapi.DataTransferObjects;
using webapi.Exceptions;
using webapi.Models;

namespace webapi.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public DoctorService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Doctor> CreateDoctorAsync(DoctorForManipulationDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);

            _repositoryManager.DoctorRepository.CreateDoctor(doctor);
            await _repositoryManager.SaveChangesAsync();

            return doctor;
        }

        public async Task DeleteDoctorAsync(Guid id)
        {
            var doctor = await _repositoryManager.DoctorRepository.GetDoctorByIdAsync(id);
            if (doctor == null)
                throw new NotFoundException("doctor not found");

            _repositoryManager.DoctorRepository.DeleteDoctor(doctor);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<Doctor> GetDoctorAsync(Guid id)
        {
            var doctor = await _repositoryManager.DoctorRepository.GetDoctorByIdAsync(id);
            if (doctor == null)
                throw new NotFoundException("doctor not found");

            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync() =>
            await _repositoryManager.DoctorRepository.GetDoctorsAsync();

        public async Task UpdateDoctorAsync(Guid id, DoctorForManipulationDto doctorDto)
        {
            var doctor = await _repositoryManager.DoctorRepository.GetDoctorByIdAsync(id);
            if (doctor == null)
                throw new NotFoundException("doctor not found");

            _mapper.Map(doctorDto, doctor);

            _repositoryManager.DoctorRepository.UpdateDoctor(doctor);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
