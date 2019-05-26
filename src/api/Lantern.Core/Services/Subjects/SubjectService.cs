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

        public SubjectService(IRepository<Subject> repository)
        {
            _repository = repository;
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
        }

        public async Task<bool> IsExists(Guid subjectId)
        {
            return await _repository.IsExists(subjectId);
        }

        public async Task<Subject> GetById(Guid subjectId)
        {
            return await _repository.FindByIdAsync(subjectId);
        }

        public Task<IEnumerable<Subject>> GetAllByStudentId(Guid requestStudentId)
        {
            throw new NotImplementedException();
        }
    }
}