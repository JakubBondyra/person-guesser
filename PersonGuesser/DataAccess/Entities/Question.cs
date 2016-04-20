using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool Unforgiveable { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
