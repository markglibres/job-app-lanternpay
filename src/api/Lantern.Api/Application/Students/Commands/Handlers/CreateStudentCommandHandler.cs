using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Students.ResponseModels;
using Lantern.Core.Services.Students.Exceptions;
using Lantern.Domain.Students;
using Lantern.Domain.Students.Services;
using MediatR;

namespace Lantern.Api.Application.Students.Commands.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public CreateStudentCommandHandler(
            IMapper mapper,
            IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        public async Task<StudentResponseModel> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.Create(request.Name);

            await _studentService.Save(student);
            
            var model = _mapper.Map<StudentResponseModel>(student);

            return model;
        }
    }
}