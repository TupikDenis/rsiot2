namespace webapi.DataTransferObjects
{
    public class AppointmentForManipulationDto
    {
        public Guid PatiendId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
