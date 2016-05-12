using Core.Data;
using Core.Interfaces;
using DataAccess;

namespace Core.Modules
{
    public class InteractionModule : IInteraction
    {
        private Modules.DataModule _dataModule;

        public InteractionModule()
        {
        }

        public void StartGame()
        {
            var unit = new DbRepository();
            _dataModule = new Modules.DataModule( new GameData(), unit );
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

        public void AddNewQuestion(string text, int answer)
        {
            UpdatingModule.Instance.AddNewQuestion(text, answer, _dataModule.GuessedGamePerson?.PersonId);
        }

        public void AddNewPerson(string name)
        {
            var person = UpdatingModule.Instance.AddNewPerson(name, _dataModule.GetSummary());
            _dataModule.GuessedGamePerson = new GamePerson()
            {
                CorrectAnswers = 0,
                CurrentAnswer = AnswerType.Unknown,
                Name = person.Name,
                OccurenceCount = person.Count, 
                PersonId = person.PersonId
            };
        }

        public bool SendPhotoString(string base64String)
        {
            return UpdatingModule.Instance.UpdatePhoto(_dataModule.GuessedGamePerson.PersonId, base64String);
        }

        public string GetPhotoString()
        {
            return _dataModule.GetPhotoString();
        }
    }
}
