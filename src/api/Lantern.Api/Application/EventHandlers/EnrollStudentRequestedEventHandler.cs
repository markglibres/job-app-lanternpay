using System;
using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Enrollments.Exceptions;
using Lantern.Domain.Enrollments;
using Lantern.Domain.Enrollments.Services;
using Lantern.Domain.Subjects.Events;
using MediatR;

namespace Lantern.Api.Application.EventHandlers
{
    public class EnrollStudentRequestedEventHandler: INotificationHandler<EnrollStudentRequestedEvent>
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollStudentRequestedEventHandler(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        public async Task Handle(EnrollStudentRequestedEvent notification, CancellationToken cancellationToken)
        {
            var enrollment = await _enrollmentService.Create(
                notification.EnrollmentId,
                notification.SubjectId,
                notification.StudentId);

            if (await _enrollmentService.ExceedsCapacity(notification.SubjectId))
            {
                enrollment.Reject(EnrollmentRejectReason.LectureCapacityExceeded);
                await _enrollmentService.Save(enrollment);
                throw new EnrollmentExceedsCapacityException();
            }

            if (await _enrollmentService.ExceedsStudentHours(notification.SubjectId, notification.StudentId))
            {
                enrollment.Reject(EnrollmentRejectReason.StudentHoursExceeded);
                await _enrollmentService.Save(enrollment);
                throw new EnrollmentStudentExceedsHoursException();
            }
            
            enrollment.Approve();
            await _enrollmentService.Save(enrollment);
            
        }
    }

}