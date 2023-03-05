namespace webapi.Models
{
    public class Mark
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public Guid UserId { get; set; }
        public int Marks { get; set; }

        public Subject Subject { get; set; }
        public User User { get; set; }
    }
}
