using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class GameSummary
    {
        public GameQuestion[] Entries;
        public GamePerson GuessedGamePerson;
        public GameSummary(GameData gameData, GamePerson guessedGamePerson)
        {
            Entries = gameData.QuestionSet.ToArray();
            GuessedGamePerson = guessedGamePerson;
        }
    }
}
