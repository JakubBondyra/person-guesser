using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Answer
    {
        [Key, Column(Order = 0), ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        [Key, Column(Order = 1), ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int YesCount { get; set; }
        public int NoCount { get; set; }
    }
}
