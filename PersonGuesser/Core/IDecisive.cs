using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    interface IDecisive
    {
        void ProcessAnswer(AnswerType answer);
        Step GetStep();
        void EndGame();
        GameSummary GetSummary();
    }
}
