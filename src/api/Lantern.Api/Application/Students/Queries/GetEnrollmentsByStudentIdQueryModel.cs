using System;
using System.Collections.Generic;

namespace Lantern.Api.Application.Students.Queries
{
    public class GetEnrollmentsByStudentIdQueryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Domain.Subjects.Subject> Subjects { get; set; }
    }
}