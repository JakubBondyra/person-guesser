using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Providers.Entities;
using Core.Data;
using Core.Interfaces;
using Core.Modules;

namespace Website
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class GameService
    {
        private IInteraction _module;
        public GameService()
        {
            _module = new InteractionModule();
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json)]
        public void StartGame ()
        {
            _module.StartGame();
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json)]
        public void EndGame()
        {
            _module.EndGame();
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json)]
        public SummaryData GetSummary()
        {
            var s = _module.GetSummary();
            return new SummaryData(s);
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json)]
        public StepData GetStep(AnswerData answer)
        {
            switch (answer.AnswerType)
            {
                case "Yes":
                    _module.SaveAnswer(AnswerType.Yes);
                    break;
                case "No":
                    _module.SaveAnswer(AnswerType.No);
                    break;
                case "Unknown":
                    _module.SaveAnswer(AnswerType.Unknown);
                    break;
                default:
                    break;
            }
            var s = _module.GetStep();
            return translateStep(s);
        }

        private StepData translateStep(Step s)
        {
            if (s.GetType() == typeof (DefeatStep))
            {
                return new StepData() {StepType = "Defeat"};
            }
            else if (s.GetType() == typeof(VictoryStep))
            {
                return new StepData() {StepType = "Victory"};
            }
            else if (s.GetType() == typeof(GuessingStep))
            {
                var s1 = (GuessingStep)s;
                return new StepData() { Question = s1.GuessText, StepType = "Guessing" };
            }
            else
            {
                var s1 = (QuestionStep) s;
                return new StepData() {Question = s1.QuestionText, StepType = "Question"};
            }
        }
    }
    [DataContract]
    public class AnswerData
    {
        [DataMember]
        public string AnswerType { get; set; }
    }

    [DataContract]
    public class StepData
    {
        [DataMember]
        public string StepType { get; set; }
        [DataMember]
        public string Question { get; set; }
    }

    [DataContract]
    public class EntryData
    {
        [DataMember]
        public string QuestionText { get; set; }
        [DataMember]
        public string UserAnswer { get; set; }
        [DataMember]
        public string SystemAnswer { get; set; }
    }

    [DataContract]
    public class SummaryData
    {
        [DataMember]
        public string GuessedName { get; set; }
        [DataMember]
        public EntryData[] Entries { get; set; }

        public SummaryData(GameSummary summary)
        {
            GuessedName = summary.GuessedGamePerson.Name;

            var entryList = new List<EntryData>();
            foreach (var entry in summary?.Entries)
            {
                entryList.Add(new EntryData()
                {
                    QuestionText = entry.QuestionText,
                    SystemAnswer = entry.PersonAnswer.ToString().Split('.').Last(),
                    UserAnswer = entry.UserAnswer.ToString().Split('.').Last()
                });
            }
            Entries = entryList.ToArray();
        }
    }
}
