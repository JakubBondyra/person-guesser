using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class InteractionModule : IInteraction
    {
        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public Step GetStep()
        {
            throw new NotImplementedException();
        }

        public void SaveAnswer(AnswerType answer)
        {
            throw new NotImplementedException();
        }

        public void GetSummary()
        {
            throw new NotImplementedException();
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }

        public void AddNewQuestion(string text)
        {
            throw new NotImplementedException();
        }

        public void AddNewPerson(string name)
        {
            throw new NotImplementedException();
        }
    }
}
