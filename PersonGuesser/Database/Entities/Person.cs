using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Answer> Answers { get; set; } 
    }
}
