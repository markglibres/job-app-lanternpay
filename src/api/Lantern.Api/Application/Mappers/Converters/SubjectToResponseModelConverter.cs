using System.Collections.Generic;
using AutoMapper;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Api.Application.Students.ResponseModels;
using Lantern.Api.Application.Subjects.ResponseModels;
using Lantern.Domain.Subjects;

namespace Lantern.Api.Application.Mappers.Converters
{
    public class SubjectToResponseModelConverter : ITypeConverter<Subject, SubjectResponseModel>
    {
        public SubjectResponseModel Convert(Subject source, SubjectResponseModel destination, ResolutionContext context)
        {
            var model = new SubjectResponseModel
            {
                Id = source.Id.ToString(),
                Lectures = context.Mapper.Map<IEnumerable<LectureResponseModel>>(source.Lectures),
                Name = source.Name,
                Students = source.Students == null ? null : context.Mapper.Map<IEnumerable<StudentResponseModel>>(source.Students)
            };

            return model;
        }
    }
}