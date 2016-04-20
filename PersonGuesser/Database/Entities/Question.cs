using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
