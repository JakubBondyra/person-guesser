﻿using System.Linq;

namespace Core.Data
{
    public class GameSummary
    {
        public GameQuestion[] Entries;
        public GamePerson GuessedGamePerson;
        public int QuestionsAsked = 0;
        public GameSummary(GameData gameData, GamePerson guessedGamePerson)
        {
            Entries = gameData.QuestionSet.ToArray();
            GuessedGamePerson = guessedGamePerson;
            QuestionsAsked = gameData.QuestionsAsked;
        }
    }
}
