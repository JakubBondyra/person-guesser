using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;

namespace Core
{
    public class UpdatingModule
    {
        private static UpdatingModule _instance = null;

        public static UpdatingModule Instance => _instance ?? (_instance = new UpdatingModule());

        public void UpdateStructures(GameSummary data)
        {
            using (var context = new PgContext())
            {
                context.Persons.Single(x => x.Name == data.GuessedPerson.Name).Count++;
                context.SaveChanges();
                foreach (var question in data.Entries)
                {
                    var dbQuestion = context.Questions.Single(x => x.Text == question.QuestionText);
                    var answer = context.Answers.Single(x => x.QuestionId == dbQuestion.QuestionId);
                    answer.NoCount = question.UserAnswer == AnswerType.No
                        ? answer.NoCount + 1
                        : answer.NoCount;

                    answer.YesCount = question.UserAnswer == AnswerType.Yes
                        ? answer.YesCount + 1
                        : answer.YesCount;
                    context.SaveChanges();
                }
            }
        }

        public void AddNewQuestion(string text)
        {
            using (var context = new PgContext())
            {
                context.Questions.Add(
                    new DataAccess.Entities.Question()
                    {
                        Text = text,
                        Unforgiveable = false
                    });
                context.SaveChanges();
                var questionAdded = context.Questions.Single(x => x.Text == text);
                foreach (var person in context.Persons)
                {
                    context.Answers.Add(
                        new Answer()
                        {
                            NoCount = 0,
                            PersonId = person.PersonId,
                            QuestionId = questionAdded.QuestionId,
                            YesCount = 0
                        });
                }
                context.SaveChanges();
            }
        }

        public void AddNewPerson(string name, GameSummary gameSummary)
        {
            using (var context = new PgContext())
            {
                context.Persons.Add(new DataAccess.Entities.Person()
                {
                    Name = name,
                    Count = 0
                });
                context.SaveChanges();
                var personAdded = context.Persons.Single(x => x.Name == name);
                var questions = context.Questions.ToList();
                foreach (var question in questions)
                {
                    if (gameSummary.Entries.Any(x => x.QuestionText == question.Text))
                    {
                        var summaryQuestion = gameSummary.Entries.Single(x => x.QuestionText == question.Text);
                        context.Answers.Add(new Answer()
                        {
                            NoCount = summaryQuestion.UserAnswer == AnswerType.No ? 1 : 0,
                            YesCount = summaryQuestion.UserAnswer == AnswerType.No ? 0 : 1,
                            PersonId = personAdded.PersonId,
                            QuestionId = question.QuestionId
                        });
                    }
                    else
                    {
                        context.Answers.Add(new Answer()
                        {
                            NoCount = 0,
                            YesCount = 0,
                            QuestionId = question.QuestionId,
                            PersonId = personAdded.PersonId
                        });
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
