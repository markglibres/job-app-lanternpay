using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;
using MediatR;

namespace Lantern.Api.Application.Lectures.Commands
{
    public class CreateLectureTheatreCommand : IRequest<LectureTheatreResponseModel>
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}