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
        public string AddPerson(string person, int token)
        {
            try
            {
                _modules[token]?.AddNewPerson(person);
                return person;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [OperationContract]
        [WebInvoke(Method = "POST",
    ResponseFormat = WebMessageFormat.Json)]
        public string AddQuestion(string question, int answer, int token)
        {
            try
            {
                _modules[token]?.AddNewQuestion(question, answer);
                return question;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        public GameStats GetStats()
        {
            var stats = UpdatingModule.GetStats();
            return new GameStats(stats);
        }

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json)]
        public StepData GetStep(string answer, int token)
        {
            try
            {
                switch (answer)
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
                        throw new Exception($"Wrong option -> {answer}");
                }

                var s = _modules[token]?.GetStep();
                return translateStep(s);
            }
            catch (Exception e)
            {
                return new StepData()
                {
                    StepType = "Defeat", DisplayText = "Przegrałem, bo nikt mi nie przychodzi na myśl, prawdopodobnie nie ma go w bazie."
                };
            }
        }

        private StepData translateStep(Step s)
        {
            if (s.GetType() == typeof (DefeatStep))
            {
                var s1 = (DefeatStep)s;
                return new StepData() {StepType = "Defeat", DisplayText = s1.Text};
            }
            else if (s.GetType() == typeof(VictoryStep))
            {
                var s1 = (VictoryStep) s;
                return new StepData() {StepType = "Victory", DisplayText = s1.PersonName, Image = s1.Image};
            }
            else if (s.GetType() == typeof(GuessingStep))
            {
                var s1 = (GuessingStep)s;
                return new StepData() { DisplayText = s1.GuessText, StepType = "Guessing" };
            }
            else
            {
                var s1 = (QuestionStep) s;
                return new StepData() {DisplayText = s1.QuestionText, StepType = "Question"};
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
        public string DisplayText { get; set; }
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
                var systemAnswer = entry.SystemAnswer.ToString().Split('.').Last();
                var userAnswer = entry.UserAnswer.ToString().Split('.').Last();
                entryList.Add(new EntryData()
                {
                    QuestionText = entry.QuestionText,
                    SystemAnswer = systemAnswer == "Yes" ? "Tak" : systemAnswer == "No" ? "Nie" : "Nieznane",
                    UserAnswer = userAnswer == "Yes" ? "Tak" : userAnswer == "No" ? "Nie" : "Nieznane",
                });
            }
            Entries = entryList.ToArray();
        }
    }

    [DataContract]
    public class GameStats
    {
        [DataMember]
        public int PersonCount { get; set; }
        [DataMember]
        public int QuestionCount { get; set; }
        [DataMember]
        public int GameCount { get; set; }
        [DataMember]
        public int WonCount { get; set; }
        [DataMember]
        public int AskCount { get; set; }

        public GameStats(Tuple<int,int,int,int, int> stats)
        {
            PersonCount = stats.Item1;
            QuestionCount = stats.Item2;
            GameCount = stats.Item3;
            WonCount = stats.Item4;
            AskCount = stats.Item5;
        }
    }
}
