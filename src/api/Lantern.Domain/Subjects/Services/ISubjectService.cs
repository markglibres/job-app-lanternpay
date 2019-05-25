using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lantern.Domain.Subjects.Services
{
    public interface ISubjectService
    {
        Task<Subject> Create(string name);
        Task<IEnumerable<Subject>> GetAll();
        Task<bool> IsExists(string requestName);
        Task Save(Subject subject);
        Task<bool> IsExists(Guid requestSubjectId);
        Task<Subject> GetById(Guid requestSubjectId);
        Task<IEnumerable<Subject>> GetAllByStudentId(Guid requestStudentId);
    }
}