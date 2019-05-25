using System.Collections.Generic;
using MediatR;

namespace Lantern.Api.Application.Subject.Queries
{
    public class GetSubjectsQuery : IRequest<IEnumerable<Domain.Subjects.Subject>>
    {
        
    }
}