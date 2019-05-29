using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Enrollments.ResponseModels;
using Lantern.Core.Services.Enrollments.Exceptions;
using Lantern.Domain.Enrollments.Services;
using Lantern.Domain.Students.Services;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Enrollments.Queries.Handlers
{
    public class GetEnrollmentByApplicationIdQueryHandler : IRequestHandler<GetEnrollmentByApplicationIdQuery, EnrollmentResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;

        public GetEnrollmentByApplicationIdQueryHandler(
            IMapper mapper,
            IEnrollmentService enrollmentService,
            IStudentService studentService,
            ISubjectService subjectService
            )
        {
            _mapper = mapper;
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _subjectService = subjectService;
        }
        
        public async Task<EnrollmentResponseModel> Handle(GetEnrollmentByApplicationIdQuery request, CancellationToken cancellationToken)
        {
            if(!await _enrollmentService.IsExists(request.ApplicationId)) 
                throw new EnrollmentApplicationIdDoesNotExistsException(request.ApplicationId.ToString());

            var enrollment = await _enrollmentService.GetByApplicationId(request.ApplicationId);
            var student = await _studentService.GetById(enrollment.StudentId);
            var subject = await _subjectService.GetById(enrollment.SubjectId);

            var model = _mapper.Map<EnrollmentResponseModel>(enrollment);
            model.Student = _mapper.Map<EnrollmentStudentResponseModel>(student);
            model.Subject = _mapper.Map<EnrollmentSubjectResponseModel>(subject);

            return model;
        }
    }
}