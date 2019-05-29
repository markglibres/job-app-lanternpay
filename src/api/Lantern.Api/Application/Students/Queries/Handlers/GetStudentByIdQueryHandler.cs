using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Enrollments.Commands.Handlers;
using Lantern.Api.Application.Students.ResponseModels;
using Lantern.Core.Services.Students.Exceptions;
using Lantern.Domain.Students;
using Lantern.Domain.Students.Services;
using MediatR;

namespace Lantern.Api.Application.Students.Queries.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public GetStudentByIdQueryHandler(
            IMapper mapper,
            IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }
        
        public async Task<StudentResponseModel> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            if(!await _studentService.IsExists(request.Id)) 
                throw new StudentIdDoesNotExistsException(request.Id.ToString());

            var student = await _studentService.GetById(request.Id);

            var model = _mapper.Map<StudentResponseModel>(student);
            
            return model;
        }
    }
}