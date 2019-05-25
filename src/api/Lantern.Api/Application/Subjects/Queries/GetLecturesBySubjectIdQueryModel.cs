using System;
using System.Collections.Generic;
using Lantern.Domain.Lectures;

namespace Lantern.Api.Application.Subjects.Queries
{
    public class GetLecturesBySubjectIdQueryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Lecture> Lectures { get; set; }
    }
}