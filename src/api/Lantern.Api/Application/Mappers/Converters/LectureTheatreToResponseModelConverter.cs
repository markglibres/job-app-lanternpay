using AutoMapper;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;

namespace Lantern.Api.Application.Mappers.Converters
{
    public class LectureTheatreToResponseModelConverter : ITypeConverter<LectureTheatre, LectureTheatreResponseModel>
    {
        public LectureTheatreResponseModel Convert(LectureTheatre source, LectureTheatreResponseModel destination,
            ResolutionContext context)
        {
            var model = new LectureTheatreResponseModel()
            {
                Id = source.Id.ToString(),
                Capacity = source.Capacity,
                Name = source.Name
            };

            return model;
        }
    }
}