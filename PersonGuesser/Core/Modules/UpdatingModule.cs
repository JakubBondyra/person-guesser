using System;
using System.Linq;
using Core.Data;
using DataAccess;
using DataAccess.Entities;

namespace Core.Modules
{
    public class UpdatingModule
    {
        private static UpdatingModule _instance = null;

        public static UpdatingModule Instance => _instance ?? (_instance = new UpdatingModule());

        public void UpdateStructures(GameSummary data)
        {
            using (var context = new PgContext())
            {
                context.Persons.Single(x => x.Name == data.GuessedGamePerson.Name).Count++;
                context.SaveChanges();
                foreach (var question in data.Entries)
                {
                    var dbQuestion = context.Questions.Single(x => x.Text == question.QuestionText);
                    var answer = context.Answers.Single(x => x.QuestionId == dbQuestion.QuestionId
                     && x.PersonId == data.GuessedGamePerson.PersonId);
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

        public void SaveGameInfo(GameSummary data, bool won)
        {
            using (var context = new PgContext())
            {
                var newGame = new PastGame();
                newGame.QuestionsAsked = data.QuestionsAsked;
                newGame.Won = won;
                context.PastGames.Add(newGame);
                context.SaveChanges();
            }
        }

        public void AddNewQuestion(string text, int answer, int? guessedId)
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
                    if (person.PersonId != guessedId)
                    context.Answers.Add(
                        new Answer()
                        {
                            NoCount = 0,
                            PersonId = person.PersonId,
                            QuestionId = questionAdded.QuestionId,
                            YesCount = 0
                        });
                    else
                    {
                        context.Answers.Add(
                            new Answer()
                            {
                                NoCount = answer == 1 ? 0 : 1,
                                PersonId = person.PersonId,
                                QuestionId = questionAdded.QuestionId,
                                YesCount = answer == 1 ? 1 : 0
                            });
                    }
                }
                context.SaveChanges();
            }
        }

        public void AddNewPerson(string name, GameSummary gameSummary)
        {
            using (var context = new PgContext())
            {
                context.Persons.Add(new Person()
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

        public static Tuple<int, int, int, int> GetStats()
        {
            using (var context = new PgContext())
            {
                var gameCount = context.PastGames.Count();
                var wonCount = context.PastGames.Count(x => x.Won);
                var questionCount = context.Questions.Count();
                var personCount = context.Persons.Count();
                return new Tuple<int, int, int, int>(personCount, questionCount, gameCount, wonCount);
            }
        }
    }
}
