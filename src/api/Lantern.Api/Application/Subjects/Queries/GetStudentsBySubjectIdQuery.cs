using System;
using System.Collections.Generic;
using Lantern.Domain.Students;
using MediatR;

namespace Lantern.Api.Application.Subjects.Queries
{
    public class GetStudentsBySubjectIdQuery : IRequest<GetStudentsBySubjectIdQueryModel>
    {
        public Guid SubjectId { get; set; }
    }

    
}