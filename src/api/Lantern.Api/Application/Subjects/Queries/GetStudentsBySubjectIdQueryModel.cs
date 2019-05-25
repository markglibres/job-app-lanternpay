using System;
using System.Collections.Generic;
using Lantern.Domain.Students;

namespace Lantern.Api.Application.Subjects.Queries
{
    public class GetStudentsBySubjectIdQueryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}