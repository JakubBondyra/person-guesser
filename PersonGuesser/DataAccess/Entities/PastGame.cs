using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class PastGame
    {
        [Key]
        public int PastGameId { get; set; }
        public int QuestionsAsked { get; set; }
        public bool Won { get; set; }
    }
}
