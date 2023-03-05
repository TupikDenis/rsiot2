using webapi.Models;

namespace webapi.Contracts.Repositories
{
    public interface IMarkRepository
    {
        Task<IEnumerable<Mark>> GetMarksAsync();
        Task<Mark> GetMarkByIdAsync(Guid id);
        void CreateMark(Mark mark);
        void UpdateMark(Mark mark);
        void DeleteMark(Mark mark);
    }
}
