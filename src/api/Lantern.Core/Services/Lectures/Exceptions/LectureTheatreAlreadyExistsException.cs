using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.Lectures.Exceptions
{
    public class LectureTheatreAlreadyExistsException : BusinessException
    {
        public LectureTheatreAlreadyExistsException(string name) 
            : base($"Lecture Theatre name already exists: {name}")
        {
        }
    }
}