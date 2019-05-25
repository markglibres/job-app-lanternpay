using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Enrollments.Exceptions;
using Lantern.Domain.Enrollments.Events;
using Lantern.Domain.Enrollments.Services;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.EventHandlers
{
    public class EnrollmentApprovedEventHandler : INotificationHandler<EnrollmentApprovedEvent>
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly ISubjectService _subjectService;

        public EnrollmentApprovedEventHandler(
            IEnrollmentService enrollmentService,
            ISubjectService subjectService)
        {
            _enrollmentService = enrollmentService;
            _subjectService = subjectService;
        }

        public async Task Handle(EnrollmentApprovedEvent notification, CancellationToken cancellationToken)
        {
            if (!await _enrollmentService.IsExists(notification.EnrollmentId))
                throw new EnrollmentIdDoesNotExistsException();

            var student = await _enrollmentService.GetStudent(notification.EnrollmentId);
            var subject = await _enrollmentService.GetSubject(notification.EnrollmentId);

            subject.AddStudent(student);

            await _subjectService.Save(subject);
        }
    }
}