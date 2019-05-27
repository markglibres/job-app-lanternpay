using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;

namespace Lantern.Api.Application.Mappers.Converters
{
    public class LectureToResponseModelConverter: ITypeConverter<Lecture, LectureResponseModel>
    {
        public LectureResponseModel Convert(Lecture source, LectureResponseModel destination, ResolutionContext context)
        {
            var model = new LectureResponseModel
            {
                Id = source.Id.ToString(),
                EndTime = source.EndTime.ToString("h:mm:ss tt"),
                StartTime = source.StartTime.ToString("h:mm:ss tt"),
                DayOfWeek = source.DayOfWeek.ToString(),
                LectureTheatre = new LectureTheatreResponseModel
                {
                    Id = source.LectureTheatreId.ToString()
                }
            };


            return model;
        }
    }
}