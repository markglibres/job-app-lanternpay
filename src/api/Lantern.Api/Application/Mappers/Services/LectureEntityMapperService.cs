using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;

namespace Lantern.Api.Application.Mappers.Services
{
    public class LectureEntityMapperService : IEntityMapperService<LectureResponseModel>
    {
        private readonly ILectureTheatreService _lectureTheatreService;
        private readonly IMapper _mapper;

        public LectureEntityMapperService(
            IMapper mapper,
            ILectureTheatreService lectureTheatreService)
        {
            _mapper = mapper;
            _lectureTheatreService = lectureTheatreService;
        }

        public async Task<LectureResponseModel> Map(LectureResponseModel lecture)
        {
            var lectureTheatre = await _lectureTheatreService.GetById(Guid.Parse(lecture.LectureTheatre.Id));
            lecture.LectureTheatre = _mapper.Map<LectureTheatre, LectureTheatreResponseModel>(lectureTheatre);

            return lecture;
        }

        public async Task<IEnumerable<LectureResponseModel>> Map(IEnumerable<LectureResponseModel> lectures)
        {
            var mappedLectures = lectures.ToList();
            
            var theatreIds = mappedLectures
                .ToList()
                .Select(_ => Guid.Parse(_.LectureTheatre.Id))
                .ToList();

            var theatres = (await _lectureTheatreService
                    .GetById(theatreIds))
                .ToList();

            foreach (var responseModel in mappedLectures)
            {
                var theatreId = responseModel.LectureTheatre.Id;
                var theatre = theatres.FirstOrDefault(_ => _.Id.ToString() == theatreId);
                responseModel.LectureTheatre = _mapper.Map<LectureTheatreResponseModel>(theatre);
            }

            return mappedLectures;
        }
    }
}