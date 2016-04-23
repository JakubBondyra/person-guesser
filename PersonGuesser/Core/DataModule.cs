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
        Initialized, InProgress, Guessing, Finished    
    }

    public partial class DataModule : IDecisive
    {
        private GameData _gameData;
        private GameState _gameState;
        private Question _currentQuestion = null;
        private UnitOfWork _context;
        public Person GuessedPerson = null;

        public DataModule(GameData gameData, UnitOfWork context)
        {
            _gameData = gameData;
            _gameState = GameState.Initialized;
            _context = context;
        }

        public void ProcessAnswer(AnswerType answer)
        {
            if (_currentQuestion == null || _gameState == GameState.Initialized)
            {
                throw new Exception("UI error - processing answer with no questions asked");
            }
            if (_gameState == GameState.InProgress)
            {
                _currentQuestion.UserAnswer = answer;
                _gameData.QuestionSet.Add(_currentQuestion);
                _currentQuestion = null;
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
            updatePersonAnswers(GuessedPerson ?? (_gameData.PeopleSet.Count > 0 ?
                _gameData.PeopleSet.ElementAt(0) : null));
            return new GameSummary(_gameData, GuessedPerson);
        }
    }
}
