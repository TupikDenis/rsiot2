using webapi.DataTransferObjects;
using webapi.Models;

namespace webapi.Contracts.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetSubjectsAsync();
        Task<Subject> GetSubjectAsync(Guid id);
        Task<Subject> CreateSubjectAsync(SubjectForManipulationDto subjectDto);
        Task UpdateSubjectAsync(Guid id, SubjectForManipulationDto subjectDto);
        Task DeleteSubjectAsync(Guid id);
    }
}
