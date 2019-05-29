using AutoMapper;
using Lantern.Api.Application.Enrollments.ResponseModels;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Api.Application.Mappers.Converters;
using Lantern.Api.Application.Students.ResponseModels;
using Lantern.Api.Application.Subjects.ResponseModels;
using Lantern.Domain.Enrollments;
using Lantern.Domain.Lectures;
using Lantern.Domain.Students;
using Lantern.Domain.Subjects;

namespace Lantern.Api.Application.Mappers
{
    public class ResponseModelMapperProfile : Profile
    {
        public ResponseModelMapperProfile()
        {
            CreateMap<Lecture, LectureResponseModel>()
                .ConvertUsing<LectureToResponseModelConverter>();
            CreateMap<LectureTheatre, LectureTheatreResponseModel>()
                .ConvertUsing<LectureTheatreToResponseModelConverter>();
            CreateMap<Subject, SubjectResponseModel>()
                .ConvertUsing<SubjectToResponseModelConverter>();
            CreateMap<Student, StudentResponseModel>();
            CreateMap<Student, EnrollmentStudentResponseModel>();
            CreateMap<Subject, EnrollmentSubjectResponseModel>();
            CreateMap<Enrollment, EnrollmentResponseModel>()
                .ConvertUsing<EnrollmentToResponseModelConverter>();
        }
    }
}