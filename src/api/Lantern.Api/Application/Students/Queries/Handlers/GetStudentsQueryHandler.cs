using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Students.ResponseModels;
using Lantern.Domain.Students;
using Lantern.Domain.Students.Services;
using MediatR;

namespace Lantern.Api.Application.Students.Queries.Handlers
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<StudentResponseModel>>
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public GetStudentsQueryHandler(
            IMapper mapper,
            IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }
        public async Task<IEnumerable<StudentResponseModel>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetAll();

            var model = _mapper.Map<IEnumerable<StudentResponseModel>>(students);
            
            return model;
        }
    }
}