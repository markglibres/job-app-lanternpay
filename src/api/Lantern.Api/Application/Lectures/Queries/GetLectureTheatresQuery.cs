using System.Collections.Generic;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;
using MediatR;

namespace Lantern.Api.Application.Lectures.Queries
{
    public class GetLectureTheatresQuery : IRequest<IEnumerable<LectureTheatreResponseModel>>
    {
        
    }
}