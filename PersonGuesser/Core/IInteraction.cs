using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    interface IInteraction
    {
        void StartGame();
        Step GetStep();
        void SaveAnswer(AnswerType answer);
        GameSummary GetSummary();
        void EndGame();
        void AddNewQuestion(string text);
        void AddNewPerson(string name);
    }
}
