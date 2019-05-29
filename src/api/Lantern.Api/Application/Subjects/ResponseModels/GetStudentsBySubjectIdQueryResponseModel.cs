using System;
using System.Collections.Generic;
using Lantern.Api.Application.Students.ResponseModels;
using Lantern.Domain.Students;

namespace Lantern.Api.Application.Subjects.ResponseModels
{
    public class GetStudentsBySubjectIdQueryResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StudentResponseModel> Students { get; set; }
    }
}