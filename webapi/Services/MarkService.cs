using AutoMapper;
using webapi.Contracts.Repositories;
using webapi.Contracts.Services;
using webapi.DataTransferObjects;
using webapi.Exceptions;
using webapi.Models;

namespace webapi.Services
{
    public class MarkService : IMarkService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public MarkService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Mark> CreateMarkAsync(MarkForManipulationDto markDto)
        {
            var mark = _mapper.Map<Mark>(markDto);

            _repositoryManager.MarkRepository.CreateMark(mark);
            await _repositoryManager.SaveChangesAsync();

            return mark;
        }

        public async Task DeleteMarkAsync(Guid id)
        {
            var mark = await _repositoryManager.MarkRepository.GetMarkByIdAsync(id);
            if (mark == null)
                throw new NotFoundException("mark not found");

            _repositoryManager.MarkRepository.DeleteMark(mark);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<Mark> GetMarkAsync(Guid id)
        {
            var mark = await _repositoryManager.MarkRepository.GetMarkByIdAsync(id);
            if (mark == null)
                throw new NotFoundException("mark not found");

            return mark;
        }

        public async Task<IEnumerable<Mark>> GetMarksAsync() =>
            await _repositoryManager.MarkRepository.GetMarksAsync();

        public async Task UpdateMarkAsync(Guid id, MarkForManipulationDto markDto)
        {
            var mark = await _repositoryManager.MarkRepository.GetMarkByIdAsync(id);
            if (mark == null)
                throw new NotFoundException("mark not found");

            _mapper.Map(markDto, mark);

            _repositoryManager.MarkRepository.UpdateMark(mark);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
