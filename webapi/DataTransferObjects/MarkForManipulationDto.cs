namespace webapi.DataTransferObjects
{
    public class MarkForManipulationDto
    {
        public Guid subjectId { get; set; }
        public Guid userId { get; set; }
        public Guid mark { get; set; }
    }
}
