using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Lantern.Core.Services.Students.Exceptions;
using Lantern.Domain.SeedWork;
using Lantern.Domain.Students;
using Lantern.Domain.Students.Services;

namespace Lantern.Core.Services.Students
{
    public class StudentService: IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentService(
            IRepository<Student> repository)
        {
            _repository = repository;
        }
        
        public async Task<Student> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new StudentMissingNameException();
            
            var student = new Student(name);

            return student;
        }

        public async Task Save(Student student)
        {
            await _repository.SaveAsync(student);
        }

        public Task<IEnumerable<Student>> GetAll()
        {
            return _repository.FindAll();
        }

        public Task<bool> IsExists(Guid studentId)
        {
            return _repository.IsExists(studentId);
        }

        public Task<Student> GetById(Guid studentId)
        {
            return _repository.FindByIdAsync(studentId);
        }
    }
}