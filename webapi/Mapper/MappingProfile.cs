using AutoMapper;
using webapi.DataTransferObjects;
using webapi.Models;

namespace webapi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientForManipulationDto, Patient>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Appointments, opt => opt.Ignore());
            CreateMap<DoctorForManipulationDto, Doctor>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Appointments, opt => opt.Ignore());
            CreateMap<AppointmentForManipulationDto, Appointment>()
                .ForMember(a => a.Patient, opt => opt.Ignore())
                .ForMember(a => a.Doctor, opt => opt.Ignore());
        }
    }
}
