using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Enrollments.Commands.Handlers;
using Lantern.Api.Application.Students.ResponseModels;
using Lantern.Api.Application.Subjects.ResponseModels;
using Lantern.Core.Services.Students.Exceptions;
using Lantern.Domain.Students.Services;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Students.Queries.Handlers
{
    public class
        GetEnrollmentsByStudentIdQueryHandler : IRequestHandler<GetEnrollmentsByStudentIdQuery,
            GetEnrollmentsByStudentIdQueryResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;

        public GetEnrollmentsByStudentIdQueryHandler(
            IMapper mapper,
            IStudentService studentService,
            ISubjectService subjectService)
        {
            _mapper = mapper;
            _studentService = studentService;
            _subjectService = subjectService;
        }

        public async Task<GetEnrollmentsByStudentIdQueryResponseModel> Handle(GetEnrollmentsByStudentIdQuery request,
            CancellationToken cancellationToken)
        {
            if (!await _studentService.IsExists(request.Id)) 
                throw new StudentIdDoesNotExistsException(request.Id.ToString());

            var subjects = await _subjectService.GetAllByStudentId(request.Id);
            var student = await _studentService.GetById(request.Id);

            var response = new GetEnrollmentsByStudentIdQueryResponseModel
            {
                Id = student.Id,
                Name = student.Name,
                Subjects = _mapper.Map<IEnumerable<SubjectLecturesResponseModel>>(subjects)
            };

            return response;
        }
    }
}