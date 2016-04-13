using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class GameData
    {
        public int QuestionsAsked = 0;
        public ICollection<Person> PeopleSet;
        public ICollection<Question> QuestionSet;

        public GameData()
        {
            PeopleSet = new Collection<Person>();
            QuestionSet = new Collection<Question>();
        }
    }

    public class Question
    {
        public string QuestionText;
        public AnswerType PersonAnswer;
        public AnswerType UserAnswer;
    }

    public class Person
    {
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
