using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Person GuessedPerson = null;

        public DataModule(GameData gameData)
        {
            _gameData = gameData;
            _gameState = GameState.Initialized;
        }

        public void ProcessAnswer(AnswerType type)
        {
            if (_currentQuestion == null || _gameState == GameState.Initialized)
            {
                throw new Exception("UI error - processing answer with no questions asked");
            }
            if (_gameState == GameState.InProgress)
            {
                _currentQuestion.UserAnswer = type;
                _gameData.QuestionSet.Add(_currentQuestion);
                _currentQuestion = null;
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
            return new GameSummary(_gameData);
        }
    }
}
