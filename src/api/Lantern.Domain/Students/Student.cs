using System;
using Lantern.Domain.Models;
using Newtonsoft.Json;

namespace Lantern.Domain.Students
{
    public class Student : Entity
    {
        [JsonConstructor]
        private Student()
        {
            
        }
        
        public string Name { get; }

        public Student(
            string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}