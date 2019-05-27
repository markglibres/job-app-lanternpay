using System;
using System.Collections.Generic;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;

namespace Lantern.Api.Application.Subjects.ResponseModels
{
    public class SubjectLecturesResponseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<LectureResponseModel> Lectures { get; set; }
    }
}