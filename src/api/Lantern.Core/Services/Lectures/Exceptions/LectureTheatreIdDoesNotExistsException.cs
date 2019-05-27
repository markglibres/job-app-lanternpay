using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.Lectures.Exceptions
{
    public class LectureTheatreIdDoesNotExistsException : BusinessException
    {
        public LectureTheatreIdDoesNotExistsException(string id) 
            : base($"Leacture Theatre id {id} does not exist")
        {
        }
    }
}