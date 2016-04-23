namespace Core.Interfaces
{
    internal interface IInteraction
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
