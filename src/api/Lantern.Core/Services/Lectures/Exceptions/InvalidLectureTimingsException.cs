using System;
using Baseline;
using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.Lectures.Exceptions
{
    public class InvalidLectureTimingsException : BusinessException
    {
        public InvalidLectureTimingsException(
            string lectureTheatreId,
            DateTime start, DateTime end) 
            : base($"Invalid lecture time for theatre {lectureTheatreId} from {start:h:mm:ss tt} to  {end:h:mm:ss tt}")
        {
        }
    }
}