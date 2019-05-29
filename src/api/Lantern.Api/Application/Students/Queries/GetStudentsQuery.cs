using System.Collections.Generic;
using Lantern.Api.Application.Students.ResponseModels;
using Lantern.Domain.Students;
using MediatR;

namespace Lantern.Api.Application.Students.Queries
{
    public class GetStudentsQuery: IRequest<IEnumerable<StudentResponseModel>>
    {
        
    }
}