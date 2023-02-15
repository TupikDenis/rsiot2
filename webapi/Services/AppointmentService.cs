using AutoMapper;
using webapi.Contracts.Repositories;
using webapi.Contracts.Services;
using webapi.DataTransferObjects;
using webapi.Exceptions;
using webapi.Models;

namespace webapi.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AppointmentService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Appointment> CreateAppointmentAsync(AppointmentForManipulationDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            _repositoryManager.AppointmentRepository.CreateAppointment(appointment);
            await _repositoryManager.SaveChangesAsync();

            return appointment;
        }

        public async Task DeleteAppointmentAsync(Guid id)
        {
            var appointment = await _repositoryManager.AppointmentRepository.GetAppointmentByIdAsync(id);
            if (appointment == null)
                throw new NotFoundException("appointment not found");

            _repositoryManager.AppointmentRepository.DeleteAppointment(appointment);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<Appointment> GetAppointmentAsync(Guid id)
        {
            var appointment = await _repositoryManager.AppointmentRepository.GetAppointmentByIdAsync(id);
            if (appointment == null)
                throw new NotFoundException("appointment not found");

            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync() =>
            await _repositoryManager.AppointmentRepository.GetAppointmentsAsync();

        public async Task UpdateAppointmentAsync(Guid id, AppointmentForManipulationDto appointmentDto)
        {
            var appointment = await _repositoryManager.AppointmentRepository.GetAppointmentByIdAsync(id);
            if (appointment == null)
                throw new NotFoundException("appointment not found");

            _mapper.Map(appointmentDto, appointment);

            _repositoryManager.AppointmentRepository.UpdateAppointment(appointment);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
