namespace webapi.Models
{
    public class Mark
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public Guid UserId { get; set; }
        public Guid AppointmentDate { get; set; }

        public Subject Subject { get; set; }
        public User User { get; set; }
    }
}
