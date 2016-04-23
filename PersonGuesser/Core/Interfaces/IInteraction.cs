using Core.Data;
using DataAccess;

namespace Core.Interfaces
{
    public interface IInteraction
    {
        void StartGame(UnitOfWork u);
        Step GetStep();
        void SaveAnswer(AnswerType answer);
        GameSummary GetSummary();
        void EndGame();
        void AddNewQuestion(string text);
        void AddNewPerson(string name);
    }
}
