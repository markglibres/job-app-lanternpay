using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lantern.Domain.Students.Services
{
    public interface IStudentService
    {
        Task<Student> Create(string name);
        Task Save(Student student);
        Task<IEnumerable<Student>> GetAll();
        Task<bool> IsExists(Guid studentId);
        Task<Student> GetById(Guid requestStudentId);
    }
}