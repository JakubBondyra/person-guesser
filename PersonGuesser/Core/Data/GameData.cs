using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Data
{
    public class GameData
    {
        public int QuestionsAsked = 0;
        public ICollection<GamePerson> PeopleSet;
        public ICollection<GameQuestion> QuestionSet;

        public GameData()
        {
            PeopleSet = new Collection<GamePerson>();
            QuestionSet = new Collection<GameQuestion>();
        }
    }

    public class GameQuestion
    {
        public int QuestionId;
        public string QuestionText;
        public AnswerType SystemAnswer;
        public AnswerType UserAnswer;
    }

    public class GamePerson
    {
        public int PersonId;
        public string Name;
        public int CorrectAnswers;
        public int OccurenceCount;
        public AnswerType CurrentAnswer;
    }

    public enum AnswerType
    {
        Yes,
        No,
        Unknown
    }
}
