using System.Collections.Generic;
using AutoMapper;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Api.Application.Subjects.ResponseModels;
using Lantern.Domain.Subjects;

namespace Lantern.Api.Application.Mappers.Converters
{
    public class SubjectToSubjectLectureResponseModel : ITypeConverter<Subject, SubjectLecturesResponseModel>
    {
        public SubjectLecturesResponseModel Convert(Subject source, SubjectLecturesResponseModel destination,
            ResolutionContext context)
        {
            var model = new SubjectLecturesResponseModel
            {
                Id = source.Id.ToString(),
                Name = source.Name,
                Lectures = context.Mapper.Map<IEnumerable<LectureResponseModel>>(source.Lectures)
            };

            return model;
        }
    }
}