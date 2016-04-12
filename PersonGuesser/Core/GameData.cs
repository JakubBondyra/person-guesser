using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class GameData
    {
        public IEnumerable<Person> PeopleSet;
        public IEnumerable<Question> QuestionSet;
    }

    public class Question
    {
        public string QuestionText;
        public AnswerType CorrectAnswer;
    }

    public class Person
    {
        public string Name;
        public int CorrectAnswers;
        public int OccurenceCount;
    }

    public enum AnswerType
    {
        Yes,
        No,
        Unknown
    }
}
