using System;
using Lantern.Domain.SeedWork;
using Newtonsoft.Json;

namespace Lantern.Domain.Lectures
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

        public int Capacity { get; private set; }
        public string Name { get; private set; }
    }
}