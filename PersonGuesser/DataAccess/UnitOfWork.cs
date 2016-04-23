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
    public class UnitOfWork
    {
        private PgContext _context;

        public UnitOfWork(PgContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context?.SaveChanges();
        }

        public IList<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public IList<Question> GetAllQuestions()
        {
            return _context.Questions.ToList();
        }

        public IList<Answer> GetAllAnswers()
        {
            return _context.Answers.ToList();
        }

        public IList<Answer> GetAnswersForQuestion(int id)
        {
            return _context.Answers.Where(x => x.QuestionId == id).ToList();
        }

        public IList<Answer> GetAnswersForPerson(int id)
        {
            return _context.Answers.Where(x => x.PersonId == id).ToList();
        }

        public IList<Question> GetQuestions(Func<Question, bool> pred)
        {
            return _context.Questions.Where(pred).ToList();
        }

        public IList<Person> GetPersons(Func<Person, bool> pred)
        {
            return _context.Persons.Where(pred).ToList();
        }

        public IList<Answer> GetAnswers(Func<Answer, bool> pred)
        {
            return _context.Answers.Where(pred).ToList();
        } 
    }
}
