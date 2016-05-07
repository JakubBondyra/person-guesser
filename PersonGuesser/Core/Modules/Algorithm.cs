using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;
using DataAccess.Entities;

namespace Core.Modules
{
    public partial class DataModule
    {
        private Step computeNextStep()
        {
            //TODO, question limit must be done neatly:
            if (_gameData.QuestionsAsked == 40)
            {
                _gameState = GameState.Finished;
                return new DefeatStep();
            }

            if (_gameState == GameState.Initialized)
            {
                var question = retrieveFirstQuestion();
                _gameState = GameState.UninitializedPeopleSet;

                if (question == null)
                {
                    _gameState = GameState.Finished;
                    return new DefeatStep();
                }

                _currentGameQuestion = question;
                return new QuestionStep(question.QuestionText);
            }
            else if (_gameState == GameState.InProgress)
            {
                if (canGuess(_gameData.PeopleSet))
                {
                    var guessFeature = retrieveGuessingQuestion();
                    GuessedGamePerson = guessFeature.Item1;
                    _gameState = GameState.Guessing;
                    return new GuessingStep(guessFeature.Item2);
                }
                else
                {
                    var question = retrieveRegularQuestion();
                    if (question == null)
                    {
                        _gameState = GameState.Defeated;
                        return new DefeatStep();
                    }
                    _currentGameQuestion = question;
                    return new QuestionStep(question.QuestionText);
                }
            }
            else if (_gameState == GameState.Guessing)
            {
                _gameData.PeopleSet.Remove(GuessedGamePerson);
                GuessedGamePerson = null;
                _gameState = GameState.InProgress;
                return --guessingLimit < 0 ? new DefeatStep() : computeNextStep();
            }
            else if (_gameState == GameState.Finished)
            {
                //game finished. only occurs when system has guessed correctly
                return new VictoryStep(GuessedGamePerson.Name, getImage(GuessedGamePerson.PersonId));
            }
            else if (_gameState == GameState.Defeated)
            {
                return new DefeatStep();
            }
            throw new Exception("compute next step: invalid something");
        }

        private string getImage(int personId)
        {
            return _context.GetPersons(x => x.PersonId == personId).Single().Image;
        }

        private GameQuestion retrieveRegularQuestion()
        {
            //operate on database - get proper question in PeopleSet and QuestionSet context
            //update peopleset currentanswer field
            var bestQuestion = getDivideQuestion();

            if (bestQuestion == null)
                throw new Exception("partitioning error");

            var gameQuestion = new GameQuestion()
            {
                QuestionId = bestQuestion.QuestionId,
                SystemAnswer = AnswerType.Unknown,
                QuestionText = bestQuestion.Text,
                UserAnswer = AnswerType.Unknown
            };
            _currentGameQuestion = gameQuestion;
            return gameQuestion;
        }

        private GameQuestion retrieveFirstQuestion()
        {
            //operate on database - get proper question
            //update peopleset currentanswer field
            var unforgiveableQuestions = _context.GetQuestions(x => x.Unforgiveable);
            if (unforgiveableQuestions == null || unforgiveableQuestions?.Count == 0)
                unforgiveableQuestions = _context.GetAllQuestions();
            var bestQuestion = getInitialPartition(unforgiveableQuestions);
            
            var gameQuestion = new GameQuestion()
            {
                QuestionId = bestQuestion.QuestionId,
                SystemAnswer = AnswerType.Unknown,
                QuestionText = bestQuestion.Text,
                UserAnswer = AnswerType.Unknown
            };
            _currentGameQuestion = gameQuestion;
            return gameQuestion;
        }

        private Question getDivideQuestion()
        {
            //all possible questions left
            var questions = _context.GetQuestions
                (x => Enumerable.All<GameQuestion>(_gameData.QuestionSet, y => y.QuestionId != x.QuestionId));
            //all persons considered in game
            var persons = _context.GetPersons(
                (x => Enumerable.Any<GamePerson>(_gameData.PeopleSet, y => y.PersonId == x.PersonId)));

            Question bestQuestion = null;
            var bestSum = int.MaxValue;
            foreach (var question in questions)
            {
                var preciseAnswers = _context.GetAnswers(x => x.QuestionId == question.QuestionId)
                    .Where(x => persons.Any(y => y.PersonId == x.PersonId))
                    .Select(x => x.YesCount > x.NoCount ? 1 : -1).Sum();
                if (Math.Abs(preciseAnswers) < bestSum)
                {
                    bestSum = Math.Abs(preciseAnswers);
                    bestQuestion = question;
                }
            }
            foreach (var person in _gameData.PeopleSet)
            {
                var answer = _context.GetAnswers(x => x.PersonId == person.PersonId 
                && x.QuestionId == bestQuestion?.QuestionId).Single();
                person.CurrentAnswer = calculateDominatingAnswer(answer.YesCount, answer.NoCount);
            }
            return bestQuestion;
        }

        private Question getInitialPartition(IList<Question> questions)
        {
            Question bestQuestion = null;
            var bestSum = int.MaxValue;
            foreach (var question in questions)
            {
                var preciseAnswers = Enumerable.Select<Answer, int>(_context.GetAnswers(x => x.QuestionId == question.QuestionId), x=> x.YesCount > x.NoCount ? 1 : -1).Sum();
                if (Math.Abs(preciseAnswers) < bestSum)
                {
                    bestSum = Math.Abs(preciseAnswers);
                    bestQuestion = question;
                }
            }
            return bestQuestion;
        }

        private Tuple<GamePerson,string> retrieveGuessingQuestion()
        {
            GamePerson bestMatch = null;
            double maxCoeff = double.MinValue;
            foreach (var person in _gameData.PeopleSet)
            {
                double coeff = person.CorrectAnswers/(double)_gameData.QuestionsAsked;
                if (coeff > maxCoeff)
                {
                    bestMatch = person;
                    maxCoeff = coeff;
                }
            }
            if (bestMatch == null)
                throw new Exception("Something wrong in getting guessing question");

            return new Tuple<GamePerson, string>(bestMatch, $"Zgadywanie: czy to {bestMatch.Name}?");
        }

        private bool canGuess(ICollection<GamePerson> peopleSet)
        {
            Random r = new Random();
            if (r.Next(10) < 6)
                return false;
            //if one of persons is very distinguishable from the others return true
            if (_gameData.QuestionsAsked < 4)
                return false;

            var correctCounts = Enumerable.Select<GamePerson, double>(_gameData.PeopleSet, x => (double)x.CorrectAnswers/(double)x.OccurenceCount);
            var max = correctCounts.Max();
            if (_gameData.QuestionsAsked < 10 && max > 0.89f)
                return true;
            else if (_gameData.QuestionsAsked < 20 && max > 0.79f)
                return true;
            else if (_gameData.QuestionsAsked < 30 && max > 0.74f)
                return true;
            else if (_gameData.QuestionsAsked >= 30 && max > 0.72f)
                return true;

            return false;
        }

        private void prepareSummaries(GamePerson gamePerson)
        {
            //operate on database, take answers for this GamePerson and add them to QuestionSet
            var answers = _context.GetAnswers(x => x.PersonId == gamePerson.PersonId);
            foreach (var question in _gameData.QuestionSet)
            {
                var answer = Enumerable.Single<Answer>(answers, x => x.QuestionId == question.QuestionId);
                question.SystemAnswer = calculateDominatingAnswer(answer.YesCount, answer.NoCount);
            }
        }

        private static AnswerType calculateDominatingAnswer(int yesCount, int noCount)
        {
            AnswerType dataAnswer = yesCount > noCount ? AnswerType.Yes : AnswerType.No;
            if (yesCount == noCount && yesCount == 0)
                dataAnswer = AnswerType.Unknown;
            return dataAnswer;
        }
    }
}
