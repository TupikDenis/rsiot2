using AutoMapper;
using webapi.Contracts.Repositories;
using webapi.Contracts.Services;
using webapi.DataTransferObjects;
using webapi.Exceptions;
using webapi.Models;

namespace webapi.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public SubjectService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Subject> CreateSubjectAsync(SubjectForManipulationDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            _repositoryManager.SubjectRepository.CreateSubject(subject);
            await _repositoryManager.SaveChangesAsync();

            return subject;
        }

        public async Task DeleteSubjectAsync(Guid id)
        {
            var subject = await _repositoryManager.SubjectRepository.GetSubjectByIdAsync(id);
            if (subject == null)
                throw new NotFoundException("subject not found");
            _repositoryManager.SubjectRepository.DeleteSubject(subject);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<Subject> GetSubjectAsync(Guid id)
        {
            var subject = await _repositoryManager.SubjectRepository.GetSubjectByIdAsync(id);
            if(subject == null)
                throw new NotFoundException("subject not found");
            return subject;
        }

        public async Task<IEnumerable<Subject>> GetSubjectsAsync() =>
            await _repositoryManager.SubjectRepository.GetSubjectsAsync();

        public async Task UpdateSubjectAsync(Guid id, SubjectForManipulationDto subjectDto)
        {
            var subject = await _repositoryManager.SubjectRepository.GetSubjectByIdAsync(id);
            if (subject == null)
                throw new NotFoundException("subject not found");

            _mapper.Map(subjectDto, subject);

            _repositoryManager.SubjectRepository.UpdateSubject(subject);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
