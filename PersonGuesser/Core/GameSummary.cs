using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class GameSummary
    {
        public Question[] Entries;
        public Person GuessedPerson;
        public GameSummary(GameData gameData, Person guessedPerson)
        {
            Entries = gameData.QuestionSet.ToArray();
            GuessedPerson = guessedPerson;
        }
    }
}
