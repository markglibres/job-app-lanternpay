using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.Students.Exceptions
{
    public class StudentIdDoesNotExistsException : BusinessException
    {
        public StudentIdDoesNotExistsException(string id) 
            : base($"Student id {id} does not exist.")
        {
        }
    }
}