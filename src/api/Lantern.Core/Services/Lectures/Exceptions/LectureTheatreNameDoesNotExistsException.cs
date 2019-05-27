using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.Lectures.Exceptions
{
    public class LectureTheatreNameDoesNotExistsException : BusinessException
    {
        public LectureTheatreNameDoesNotExistsException(string name) 
            : base($"Leacture Theatre name does not exist: {name}")
        {
        }
    }
}