using System.Collections.Generic;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Api.Application.Students.ResponseModels;

namespace Lantern.Api.Application.Subjects.ResponseModels
{
    public class SubjectResponseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<LectureResponseModel> Lectures { get; set; }
        public IEnumerable<StudentResponseModel> Students { get; set; }
        
    }
}