namespace Core.Interfaces
{
    internal interface IDecisive
    {
        void ProcessAnswer(AnswerType answer);
        Step GetStep();
        void EndGame();
        GameSummary GetSummary();
    }
}
