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
        public GameSummary(GameData gameData)
        {
            Entries = gameData.QuestionSet.ToArray();
        }
    }
}
