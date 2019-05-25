using System;
using System.Collections.Generic;
using System.Linq;
using Lantern.Domain.Lectures;
using Lantern.Domain.SeedWork;
using Lantern.Domain.Students;
using Lantern.Domain.Subjects.Events;
using Newtonsoft.Json;

namespace Lantern.Domain.Subjects
{
    public class Subject : AggregateRoot
    {
        [JsonConstructor]
        private Subject()
        {
        }

        public Subject(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            Lectures = new List<Lecture>();
        }

        public string Name { get; }
        public List<Lecture> Lectures { get; }
        public List<Student> Students { get; private set; }

        public Lecture AddLecture(
            DayOfWeek dayOfWeek,
            DateTime startTime,
            DateTime endTime,
            LectureTheatre theatre)
        {
            var lecture = new Lecture(
                Id,
                theatre.Id,
                dayOfWeek,
                startTime,
                endTime);

            Lectures.Add(lecture);

            return lecture;
        }

        public Guid Enroll(Student student)
        {
            var enrollmentRequest = new EnrollStudentRequestedEvent(
                Id,
                student.Id);

            Emit(enrollmentRequest);

            return enrollmentRequest.Id;
        }

        public void AddStudent(Student student)
        {
            if (Students.Any(_ => _.Id.Equals(student.Id))) return;

            Students.Add(student);
        }
    }
}