using Core.Data;
using DataAccess;

namespace Core.Interfaces
{
    public interface IInteraction
    {
        void StartGame();
        Step GetStep();
        void SaveAnswer(AnswerType answer);
        GameSummary GetSummary();
        void EndGame();
        void AddNewQuestion(string text, int answer);
        void AddNewPerson(string name);
        string GetPhotoString();
    }
}
