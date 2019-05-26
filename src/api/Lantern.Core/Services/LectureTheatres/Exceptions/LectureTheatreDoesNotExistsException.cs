using System;
using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.LectureTheatres.Exceptions
{
    public class LectureTheatreDoesNotExistsException : BusinessException
    {
        public LectureTheatreDoesNotExistsException(string name) 
            : base($"Leacture Theatre name does not exist: {name}")
        {
        }
    }
}