using Lantern.Domain.Lectures;
using MediatR;

namespace Lantern.Api.Application.Lectures.Commands
{
    public class CreateLectureTheatreCommand : IRequest<LectureTheatre>
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}