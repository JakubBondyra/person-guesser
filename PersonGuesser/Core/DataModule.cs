using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Core
{
    public enum GameState
    {
        Initialized, UninitializedPeopleSet, InProgress, Guessing, Finished    
    }

    public partial class DataModule : IDecisive
    {
        private GameData _gameData;
        private GameState _gameState;
        private GameQuestion _currentGameQuestion = null;
        private UnitOfWork _context;
        public GamePerson GuessedGamePerson = null;

        public DataModule(GameData gameData, UnitOfWork context)
        {
            _gameData = gameData;
            _gameState = GameState.Initialized;
            _context = context;
        }

        public void ProcessAnswer(AnswerType answer)
        {
            if (_currentGameQuestion == null || _gameState == GameState.Initialized)
            {
                throw new Exception("UI error - processing answer with no questions asked");
            }
            if (_gameState == GameState.UninitializedPeopleSet)
            {
                //there was first question, now its time to fill it
                var answers = _context.GetAnswers(x => x.QuestionId == _currentGameQuestion.QuestionId);
                var personsToAdd = _context.GetPersons(x => answers.Any(y => y.PersonId == x.PersonId));
                foreach (var person in personsToAdd)
                {
                    var a = answers.Single(x => x.PersonId == person.PersonId);
                    AnswerType dataAnswer = a.YesCount > a.NoCount ? AnswerType.Yes : AnswerType.No;
                    if (a.YesCount == a.NoCount && a.YesCount == 0)
                        dataAnswer = AnswerType.Unknown;
                    if (dataAnswer == answer)
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
                _currentGameQuestion = null;
                _gameData.QuestionsAsked++;
                foreach (var person in _gameData.PeopleSet)
                {
                    if (person.CurrentAnswer == AnswerType.Unknown || answer == AnswerType.Unknown)
                        continue;
                    if (person.CurrentAnswer == answer)
                    {
                        person.CorrectAnswers++;
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

        public Step GetStep()
        {
            return computeNextStep();
        }

        public void EndGame()
        {
            _gameState = GameState.Finished;
        }

        public GameSummary GetSummary()
        {
            updatePersonAnswers(GuessedGamePerson ?? (_gameData.PeopleSet.Count > 0 ?
                _gameData.PeopleSet.ElementAt(0) : null));
            return new GameSummary(_gameData, GuessedGamePerson);
        }
    }
}
