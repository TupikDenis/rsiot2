namespace webapi.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Mark> Marks { get; set; }
    }
}
