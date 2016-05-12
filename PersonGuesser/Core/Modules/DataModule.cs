using System;
using System.Linq;
using Core.Data;
using Core.Interfaces;
using DataAccess;

namespace Core.Modules
{
    public enum GameState
    {
        Initialized, UninitializedPeopleSet, InProgress, Guessing, Finished, Defeated   
    }

    public partial class DataModule : IDecisive
    {
        private GameData _gameData;
        private GameState _gameState;
        private GameQuestion _currentGameQuestion;
        private DbRepository _context;
        public GamePerson GuessedGamePerson = null;
        private int guessingLimit = 3;

        public DataModule(GameData gameData, DbRepository context)
        {
            _gameData = gameData;
            _gameState = GameState.Initialized;
            _currentGameQuestion = null;
            _context = context;
            GuessedGamePerson = null;
        }

        public void ProcessAnswer(AnswerType answer)
        {
            try
            {
                if (_gameState == GameState.Initialized)
                {
                    throw new Exception("UI error - processing answer with no questions asked");
                }
                if (_gameState == GameState.UninitializedPeopleSet)
                {
                    //there was first question, now its time to fill it
                    var answers = _context.GetAnswers(x => x.QuestionId == _currentGameQuestion.QuestionId);
                    var personsToAdd = _context.GetPersons(x => answers.Any(y => y.PersonId == x.PersonId));
                    _currentGameQuestion.UserAnswer = answer;
                    _gameData.QuestionSet.Add(_currentGameQuestion);
                    _currentGameQuestion = null;
                    _gameData.QuestionsAsked++;
                    foreach (var person in personsToAdd)
                    {
                        var a = answers.Single(x => x.PersonId == person.PersonId);
                        var dataAnswer = calculateDominatingAnswer(a.YesCount, a.NoCount);
                        if (dataAnswer == answer || answer == AnswerType.Unknown)
                        {
                            //unforgiveable question, add to set only in this case
                            _gameData.PeopleSet.Add(new GamePerson()
                            {
                                CorrectAnswers = 1,
                                CurrentAnswer = dataAnswer,
                                Name = person.Name,
                                OccurenceCount = person.Count,
                                PersonId = person.PersonId
                            });
                        }
                    }
                    _gameState = GameState.InProgress;
                }
                else if (_gameState == GameState.InProgress)
                {
                    _currentGameQuestion.UserAnswer = answer;
                    _gameData.QuestionSet.Add(_currentGameQuestion);
                    if (_currentGameQuestion.Unforgiveable)
                        _gameData.PeopleSet = _gameData.PeopleSet.Where(x => x.CurrentAnswer == answer).ToList();

                    _currentGameQuestion = null;
                    _gameData.QuestionsAsked++;

                    if (_gameData.PeopleSet.Count == 0)
                    {
                        _gameState = GameState.Defeated;
                    }
                    else
                    {
                        foreach (var person in _gameData.PeopleSet)
                        {
                            if (person.CurrentAnswer == AnswerType.Unknown)
                                person.DontKnowAnswers ++;
                            if (person.CurrentAnswer == AnswerType.Unknown || answer == AnswerType.Unknown)
                                continue;
                            if (person.CurrentAnswer == answer)
                            {
                                person.CorrectAnswers++;
                            }
                        }
                    }
                }
                else if (_gameState == GameState.Guessing)
                {
                    if (answer == AnswerType.No)
                    {
                        _gameData.QuestionsAsked ++;
                    }
                    else if (answer == AnswerType.Yes)
                    {
                        _gameState = GameState.Finished;
                    }
                    else
                    {
                        throw new Exception("Fuck you");
                    }
                }
            }
            catch (Exception)
            {
                _gameState = GameState.Defeated;
                throw;
            }
        }

        public Step GetStep()
        {
            return computeNextStep();
        }

        public void EndGame()
        {
            if (_gameState != GameState.Finished && _gameState != GameState.Defeated) return;
            var summary = new GameSummary(_gameData, GuessedGamePerson);
            UpdatingModule.Instance.SaveGameInfo(summary, _gameState == GameState.Finished);
            if (_gameState == GameState.Finished)
                UpdatingModule.Instance.UpdateStructures(summary);
        }

        public GameSummary GetSummary()
        {
            prepareSummaries(GuessedGamePerson, _gameData);
            return new GameSummary(_gameData, GuessedGamePerson);
        }

        public string GetPhotoString()
        {
            return _context.GetPersons(x => x.PersonId == GuessedGamePerson.PersonId).Single().Image;
        }
    }
}
