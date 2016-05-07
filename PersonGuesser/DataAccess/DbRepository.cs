using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess
{
    public class DbRepository
    {
        private readonly IList<Person> _persons;
        private readonly IList<Question> _questions;
        private readonly IList<Answer> _answers;   

        public DbRepository()
        {
            var context = new PgContext();
            _persons = context.Persons.ToList();
            _questions = context.Questions.ToList();
            _answers = context.Answers.ToList();
        }

        public IList<Person> GetAllPersons()
        {
            return _persons;
        }

        public IList<Question> GetAllQuestions()
        {
            return _questions;
        }

        public IList<Answer> GetAllAnswers()
        {
            return _answers;
        }

        public IList<Answer> GetAnswersForQuestion(int id)
        {
            return _answers.Where(x => x.QuestionId == id).ToList();
        }

        public IList<Answer> GetAnswersForPerson(int id)
        {
            return _answers.Where(x => x.PersonId == id).ToList();
        }

        public IList<Question> GetQuestions(Func<Question, bool> pred)
        {
            return _questions.Where(pred).ToList();
        }

        public IList<Person> GetPersons(Func<Person, bool> pred)
        {
            return _persons.Where(pred).ToList();
        }

        public IList<Answer> GetAnswers(Func<Answer, bool> pred)
        {
            return _answers.Where(pred).ToList();
        } 
    }
}
