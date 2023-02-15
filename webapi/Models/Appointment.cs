namespace webapi.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatiendId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
