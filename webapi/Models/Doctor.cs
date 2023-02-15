namespace webapi.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
