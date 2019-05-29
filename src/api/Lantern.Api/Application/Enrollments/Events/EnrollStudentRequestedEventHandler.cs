using System.Threading;
using System.Threading.Tasks;
using Lantern.Domain.Enrollments;
using Lantern.Domain.Enrollments.Services;
using Lantern.Domain.SeedWork;
using Lantern.Domain.Subjects.Events;
using MediatR;

namespace Lantern.Api.Application.Enrollments.Events
{
    public class EnrollStudentRequestedEventHandler : INotificationHandler<EnrollStudentRequestedEvent>
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollStudentRequestedEventHandler(
            IEnrollmentService enrollmentService
            )
        {
            _enrollmentService = enrollmentService;
        }
        public async Task Handle(EnrollStudentRequestedEvent notification, CancellationToken cancellationToken)
        {
            var enrollment =  _enrollmentService.Create(
                notification.ApplicationId,
                notification.SubjectId,
                notification.StudentId);

            if (await _enrollmentService.ExceedsCapacity(notification.SubjectId))
            {
                enrollment.Reject(EnrollmentRejectReason.LectureCapacityExceeded);
                
            }
            else if (await _enrollmentService.ExceedsStudentHours(notification.SubjectId, notification.StudentId))
            {
                enrollment.Reject(EnrollmentRejectReason.StudentHoursExceeded);
            }
            else
            {
                enrollment.Approve();
            }

            await _enrollmentService.Save(enrollment);
            
            
            
        }
    }
}