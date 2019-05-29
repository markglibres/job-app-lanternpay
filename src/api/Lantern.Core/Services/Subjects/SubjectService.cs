using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lantern.Core.Services.Subjects.Exceptions;
using Lantern.Domain.SeedWork;
using Lantern.Domain.Subjects;
using Lantern.Domain.Subjects.Services;

namespace Lantern.Core.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _repository;
        private readonly IDomainEventsService _domainEventsService;

        public SubjectService(
            IRepository<Subject> repository,
            IDomainEventsService domainEventsService)
        {
            _repository = repository;
            _domainEventsService = domainEventsService;
        }
        
        public async Task<Subject> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new SubjectNameRequiredException();

            if (await IsExists(name)) throw new SubjectAlreadyExistsException(name);
            
            var subject = new Subject(name);

            await _repository.SaveAsync(subject);

            return subject;
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await _repository
                .FindAll();
        }

        public async Task<bool> IsExists(string name)
        {
            return (await _repository
                    .FindByPredicate(_ => _.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
                .Any();

        }

        public async Task Save(Subject subject)
        {
            await _repository.SaveAsync(subject);
            
             _domainEventsService.Publish(subject.Events);
        }

        public async Task<bool> IsExists(Guid subjectId)
        {
            return await _repository.IsExists(subjectId);
        }

        public async Task<Subject> GetById(Guid subjectId)
        {
            return await _repository.FindByIdAsync(subjectId);
        }

        public async Task<IEnumerable<Subject>> GetAllByStudentId(Guid studentId)
        {
            return await _repository.FindByPredicate(subject =>
                subject.Students.Any(_ => _.Id == studentId));
        }

        public async Task<double> GetTotalHours(Guid subjectId)
        {
            var subject = await _repository.FindByIdAsync(subjectId);
            var lectureHours = subject
                .Lectures
                .Select(_ => (_.EndTime - _.StartTime).TotalHours)
                .Sum();

            return lectureHours;

        }
    }
}