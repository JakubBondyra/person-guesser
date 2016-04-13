using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class InteractionModule : IInteraction
    {
        private DataModule _dataModule;

        public InteractionModule()
        {
        }

        public void StartGame()
        {
            _dataModule = new DataModule( new GameData() );
        }

        public Step GetStep()
        {
            return _dataModule.GetStep();
        }

        public void SaveAnswer(AnswerType answer)
        {
            _dataModule.ProcessAnswer(answer);
        }

        public GameSummary GetSummary()
        {
            return _dataModule.GetSummary();
        }

        public void EndGame()
        {
            _dataModule.EndGame();
        }

        public void AddNewQuestion(string text)
        {
            UpdatingModule.Instance.AddNewQuestion(text);
        }

        public void AddNewPerson(string name)
        {
            UpdatingModule.Instance.AddNewPerson(name);
        }
    }
}
