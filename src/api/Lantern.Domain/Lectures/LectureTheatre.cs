using System;
using Lantern.Domain.SeedWork;
using Newtonsoft.Json;

namespace Lantern.Domain.Models
{
    public class LectureTheatre : Entity
    {
        [JsonConstructor]
        private LectureTheatre()
        {
        }

        public LectureTheatre(
            string name,
            int capacity)
        {
            Id = Guid.NewGuid();

            Name = name;
            Capacity = capacity;
        }

        public int Capacity { get; protected set; }
        public string Name { get; protected set; }
    }
}