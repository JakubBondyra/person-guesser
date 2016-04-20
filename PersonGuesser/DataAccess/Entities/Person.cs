using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DataAccess.Entities
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public ICollection<Answer> Answers { get; set; } 
    }
}
