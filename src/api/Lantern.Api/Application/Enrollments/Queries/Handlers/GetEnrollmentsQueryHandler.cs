using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Enrollments.ResponseModels;
using Lantern.Domain.Enrollments;
using Lantern.Domain.Enrollments.Services;
using Lantern.Domain.Students;
using Lantern.Domain.Students.Services;
using Lantern.Domain.Subjects;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Enrollments.Queries.Handlers
{
    public class GetEnrollmentsQueryHandler : IRequestHandler<GetEnrollmentsQuery, IEnumerable<EnrollmentResponseModel>>
    {
        private readonly IMapper _mapper;
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;

        public GetEnrollmentsQueryHandler(
            IMapper mapper,
            IEnrollmentService enrollmentService,
            IStudentService studentService,
            ISubjectService subjectService)
        {
            _mapper = mapper;
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _subjectService = subjectService;
        }
        
        public async Task<IEnumerable<EnrollmentResponseModel>> Handle(GetEnrollmentsQuery request, CancellationToken cancellationToken)
        {
            var enrollments = await _enrollmentService.GetAll();
            
            var tasks = new List<Task<EnrollmentResponseModel>>();
            
            enrollments.ToList().ForEach(_ =>
            {
                tasks.Add(GetModel(_));
            });

            var response = await Task.WhenAll(tasks);

            return response;

        }

        private async Task<EnrollmentResponseModel> GetModel(Enrollment enrollment)
        {
            var student = await _studentService.GetById(enrollment.StudentId);
            var subject = await _subjectService.GetById(enrollment.SubjectId);

            var model = _mapper.Map<EnrollmentResponseModel>(enrollment);
            model.Student = _mapper.Map<EnrollmentStudentResponseModel>(student);
            model.Subject = _mapper.Map<EnrollmentSubjectResponseModel>(subject);

            return model;
        }
    }
}