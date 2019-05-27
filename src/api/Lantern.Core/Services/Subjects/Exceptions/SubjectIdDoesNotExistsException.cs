using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.Subjects.Exceptions
{
    public class SubjectIdDoesNotExistsException : BusinessException
    {
        public SubjectIdDoesNotExistsException(string id) 
            : base($"Subject id {id} does not exist.")
        {
        }
    }
}