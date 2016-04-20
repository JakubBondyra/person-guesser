namespace DataAccess.Entities
{
    public class Answer
    {
        public virtual Person Person { get; set; }
        public virtual Question Question { get; set; }
        public int YesCount { get; set; }
        public int NoCount { get; set; }
    }
}
