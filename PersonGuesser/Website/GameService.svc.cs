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
        private IDictionary<int, IInteraction> _modules;
        private int _maxToken;
        public GameService()
        {
            _modules = new Dictionary<int, IInteraction>();
        }

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        public int StartGame ()
        {
            var token = _maxToken++;
            _modules.Add(token, new InteractionModule());
            _modules[token].StartGame();
            return token;
        }

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        public void EndGame(int token)
        {
            _modules[token]?.EndGame();
        }

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        public SummaryData GetSummary(int token)
        {
            var s = _modules[token]?.GetSummary();
            return new SummaryData(s);
        }

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        public string AddPerson(string person)
        {
            try
            {
                return person + "SERVICE";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [OperationContract]
        [WebInvoke(Method = "POST",
    ResponseFormat = WebMessageFormat.Json)]
        public string AddQuestion(string question)
        {
            try
            {
                return question + "SERVICE";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json)]
        public StepData GetStep(string answer)
        {
            try
            {
                var ind = 0;
                while (answer[ind] >= '0' && answer[ind] <= '9') ind++;
                var tokenString = answer.Substring(0, ind);
                var token = int.Parse(tokenString);
                var txt = answer.Substring(ind, answer.Length-ind);
                switch (txt)
                {
                    case "Yes":
                        _modules[token]?.SaveAnswer(AnswerType.Yes);
                        break;
                    case "No":
                        _modules[token]?.SaveAnswer(AnswerType.No);
                        break;
                    case "Unknown":
                        _modules[token]?.SaveAnswer(AnswerType.Unknown);
                        break;
                    case "Init":
                        break;
                    default:
                        throw new Exception($"Wrong option -> {txt}");
                }

                var s = _modules[token]?.GetStep();
                return translateStep(s);
            }
            catch (Exception e)
            {
                return new StepData() { StepType = "Question", Question = e.Message+e.StackTrace};
            }
        }

        private StepData translateStep(Step s)
        {
            if (s.GetType() == typeof (DefeatStep))
            {
                return new StepData() {StepType = "Defeat"};
            }
            else if (s.GetType() == typeof(VictoryStep))
            {
                var s1 = (VictoryStep) s;
                return new StepData() {StepType = "Victory", Question = s1.PersonName, Image = s1.Image};
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
        [DataMember]
        public string Image { get; set; }
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
                    SystemAnswer = entry.SystemAnswer.ToString().Split('.').Last(),
                    UserAnswer = entry.UserAnswer.ToString().Split('.').Last()
                });
            }
            Entries = entryList.ToArray();
        }
    }
}
