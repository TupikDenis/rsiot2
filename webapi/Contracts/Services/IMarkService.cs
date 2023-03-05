using webapi.DataTransferObjects;
using webapi.Models;

namespace webapi.Contracts.Services
{
    public interface IMarkService
    {
        Task<IEnumerable<Mark>> GetMarksAsync();
        Task<Mark> GetMarkAsync(Guid id);
        Task<Mark> CreateMarkAsync(MarkForManipulationDto markDto);
        Task UpdateMarkAsync(Guid id, MarkForManipulationDto markDto);
        Task DeleteMarkAsync(Guid id);
    }
}
