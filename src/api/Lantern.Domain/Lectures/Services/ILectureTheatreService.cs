using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lantern.Domain.Lectures.Services
{
    public interface ILectureTheatreService
    {
        Task<bool> IsExists(string name);
        Task<bool> IsExists(Guid id);
        Task<LectureTheatre> Create(string name, int capacity);
        Task<IEnumerable<LectureTheatre>> GetAll();
        Task Save(LectureTheatre lectureTheatre);
        Task<LectureTheatre> GetById(Guid requestLectureTheatreId);
        Task<IEnumerable<LectureTheatre>> GetById(IEnumerable<Guid> theatreIds);
        Task<bool> IsValidLectureTime(Guid requestLectureTheatreId, DateTime start, DateTime end);
    }
}