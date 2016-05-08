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
            try
            {
                if (_gameData.QuestionsAsked == 40)
                {
                    _gameState = GameState.Defeated;
                    return new DefeatStep("Przegrałem. Przekroczyłem limit pytań (40).");
                }

                if (_gameState == GameState.Initialized)
                {
                    var question = retrieveFirstQuestion();
                    _gameState = GameState.UninitializedPeopleSet;

                    if (question == null)
                    {
                        _gameState = GameState.Defeated;
                        return new DefeatStep("Przegrałem. Nie udało się mi wyznaczyć pierwszego pytania, wstyd.");
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
                            return new DefeatStep("Przegrałem. Nie ma już więcej pytań w bazie.");
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
                    if (--guessingLimit < 0)
                    {
                        _gameState = GameState.Defeated;
                        return new DefeatStep("Przegrałem. Próbowałem zgadywać zbyt dużo razy");
                    }

                    return computeNextStep();
                }
                else if (_gameState == GameState.Finished)
                {
                    //game finished. only occurs when system has guessed correctly
                    return new VictoryStep(GuessedGamePerson.Name, getImage(GuessedGamePerson.PersonId));
                }
                else if (_gameState == GameState.Defeated)
                {
                    return new DefeatStep("Przegrałem. Dla twoich odpowiedzi nie mogę wyznaczyć osoby.");
                }
                throw new Exception("compute next step: invalid something");
            }
            catch (Exception)
            {
                _gameState = GameState.Defeated;
                throw;
            }
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
                UserAnswer = AnswerType.Unknown,
                Unforgiveable = bestQuestion.Unforgiveable
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
                UserAnswer = AnswerType.Unknown,
                Unforgiveable = true
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

            var people = _gameData.PeopleSet.Where(x => x.DontKnowAnswers != _gameData.QuestionsAsked);
            var correctCounts = Enumerable.Select<GamePerson, double>(people, x => fuzzyCoeff(x));


            var midCount = correctCounts.Where(x=> x> 0f).Average();

            var consideredPeople = people.Where( x => fuzzyCoeff(x) >= midCount);
            if (!consideredPeople.Any())
                consideredPeople = people;

            var persons = _context.GetPersons(x => consideredPeople.Any(y => y.PersonId == x.PersonId));

            Random r = new Random();
            Question bestQuestion = null;
            var bestSum = int.MaxValue;
            var personCount = _context.GetAllPersons().Count;
            //wyznaczanie najlepszego pytania (wraz z pewną heurystyczną losowością)
            //możliwe też jest niewyznaczenie najlepszego pytania, ale takiego które ostatnio zostało
            //dodane do bazy danych (możliwość zadana przez ziarno losowości)
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
                if (Math.Abs(preciseAnswers) == bestSum && r.Next(0,1) == 0)
                {
                    bestSum = Math.Abs(preciseAnswers);
                    bestQuestion = question;
                }
                if (r.Next(1, 15) == 1)
                {
                    var unknownCount = _context.GetAnswers(x => x.QuestionId == question.QuestionId && 
                    x.NoCount == 0 && x.YesCount == 0).Count;
                    if (2*unknownCount > personCount)
                    {
                        bestQuestion = question;
                        break;
                    }
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
            var r = new Random();
            foreach (var question in questions)
            {
                var preciseAnswers = Enumerable.Select<Answer, int>(_context.GetAnswers
                    (x => x.QuestionId == question.QuestionId), x=> x.YesCount > x.NoCount ? 1 : -1).Sum();
                if (Math.Abs(preciseAnswers) < bestSum)
                {
                    bestSum = Math.Abs(preciseAnswers);
                    bestQuestion = question;
                }
                if (Math.Abs(preciseAnswers) == bestSum && r.Next(0, 1) == 0)
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
            foreach (var person in _gameData.PeopleSet.Where(x=> x.DontKnowAnswers != _gameData.QuestionsAsked))
            {
                double coeff = fuzzyCoeff(person);
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
            //if one of persons is very distinguishable from the others return true
            if (_gameData.QuestionsAsked < 4)
                return false;
            var people = _gameData.PeopleSet.Where(x => x.DontKnowAnswers != _gameData.QuestionsAsked);
            var correctCounts = Enumerable.Select<GamePerson, double>(people, x => fuzzyCoeff(x));
            var max = correctCounts.Max();
            var maxCount = correctCounts.Count(x => Math.Round(max, 2) == Math.Round(x, 2));
            if (_gameData.QuestionsAsked < 8 && maxCount == 1)
                return true;
            if (_gameData.QuestionsAsked > 7 && max > 0.79f && maxCount < 3)
                return true;
            if (_gameData.QuestionsAsked > 11 && max > 0.74f && maxCount < 3)
                return true;
            if (_gameData.QuestionsAsked > 15)
                return true;
            return false;
        }

        private void prepareSummaries(GamePerson gamePerson)
        {
            if (gamePerson == null)
                return;
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

        private double fuzzyCoeff(GamePerson x)
        {
            return (double)x.CorrectAnswers/(double)(_gameData.QuestionsAsked - x.DontKnowAnswers);
        }
    }
}
