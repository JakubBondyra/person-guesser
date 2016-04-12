using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DataModule : IDecisive
    {
        private GameData _gameData;

        public DataModule(GameData gameData)
        {
            _gameData = gameData;
        }

        public void ProcessAnswer(AnswerType type)
        {
            throw new NotImplementedException();
        }

        public Step GetStep()
        {
            throw new NotImplementedException();
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }

        public GameSummary GetSummary()
        {
            throw new NotImplementedException();
        }
    }
}
