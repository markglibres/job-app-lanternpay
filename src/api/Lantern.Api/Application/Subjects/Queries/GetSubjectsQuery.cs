using System.Collections.Generic;
using MediatR;

namespace Lantern.Api.Application.Subjects.Queries
{
    public class GetSubjectsQuery : IRequest<IEnumerable<Domain.Subjects.Subject>>
    {
        
    }
}