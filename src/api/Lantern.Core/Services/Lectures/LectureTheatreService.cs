using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lantern.Core.Services.Lectures.Exceptions;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;
using Lantern.Domain.SeedWork;

namespace Lantern.Core.Services.Lectures
{
    public class LectureTheatreService : ILectureTheatreService
    {
        private readonly IRepository<LectureTheatre> _repository;

        public LectureTheatreService(IRepository<LectureTheatre> repository)
        {
            _repository = repository;
        }
        
        public async Task<bool> IsExists(string name)
        {
            var result = await _repository
                .FindByPredicate(_ =>
                    _.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            return result.Any();

        }

        public async Task<bool> IsExists(Guid id)
        {
            return await _repository.IsExists(id);
        }

        public async Task<LectureTheatre> Create(string name, int capacity)
        {
            if (await IsExists(name)) throw new LectureTheatreAlreadyExistsException(name);
            
            var theatre = new LectureTheatre(name, capacity);

            return theatre;
        }

        public async Task<IEnumerable<LectureTheatre>> GetAll()
        {
            return await _repository.FindAll();
        }

        public async Task Save(LectureTheatre lectureTheatre)
        {
            await _repository.SaveAsync(lectureTheatre);
        }

        public Task<LectureTheatre> GetById(Guid requestLectureTheatreId)
        {
            return _repository.FindByIdAsync(requestLectureTheatreId);
        }

        public async Task<IEnumerable<LectureTheatre>> GetById(IEnumerable<Guid> theatreIds)
        {
            return await _repository.FindByIdAsync(theatreIds);

        }
    }
}