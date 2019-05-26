using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lantern.Domain.Lectures.Services
{
    public interface ILectureTheatreService
    {
        Task<bool> IsExists(string name);
        Task<LectureTheatre> Create(string name, int capacity);
        Task<IEnumerable<LectureTheatre>> GetAll();
        Task Save(LectureTheatre lectureTheatre);
        Task<LectureTheatre> GetById(Guid requestLectureTheatreId);
    }
}