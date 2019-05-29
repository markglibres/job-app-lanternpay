using System;
using System.Collections.Generic;
using Lantern.Api.Application.Subjects.ResponseModels;

namespace Lantern.Api.Application.Students.ResponseModels
{
    public class GetEnrollmentsByStudentIdQueryResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SubjectLecturesResponseModel> Subjects { get; set; }
    }
}