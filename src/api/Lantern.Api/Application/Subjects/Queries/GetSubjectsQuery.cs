using System.Collections.Generic;
using Lantern.Api.Application.Subjects.ResponseModels;
using MediatR;

namespace Lantern.Api.Application.Subjects.Queries
{
    public class GetSubjectsQuery : IRequest<IEnumerable<SubjectResponseModel>>
    {
        
    }
}