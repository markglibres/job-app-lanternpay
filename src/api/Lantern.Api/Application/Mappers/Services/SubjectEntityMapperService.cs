using System.Collections.Generic;
using System.Threading.Tasks;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Api.Application.Subjects.ResponseModels;

namespace Lantern.Api.Application.Mappers.Services
{
    public class SubjectEntityMapperService : IEntityMapperService<SubjectResponseModel>
    {
        private readonly IEntityMapperService<LectureResponseModel> _lectureMapperService;

        public SubjectEntityMapperService(
            IEntityMapperService<LectureResponseModel> lectureMapperService)
        {
            _lectureMapperService = lectureMapperService;
        }
        
        public async Task<SubjectResponseModel> Map(SubjectResponseModel entity)
        {
            var lectures = await _lectureMapperService.Map(entity.Lectures);

            entity.Lectures = lectures;

            return entity;
        }

        public async Task<IEnumerable<SubjectResponseModel>> Map(IEnumerable<SubjectResponseModel> entities)
        {
            var model = new List<SubjectResponseModel>();

            foreach (var responseModel in entities)
            {
                model.Add(await Map(responseModel));
            }

            return model;

        }
    }
}