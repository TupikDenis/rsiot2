namespace webapi.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
