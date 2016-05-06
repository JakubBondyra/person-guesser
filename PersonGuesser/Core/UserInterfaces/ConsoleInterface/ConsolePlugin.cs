using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using Core.Interfaces;
using Core.Modules;
using DataAccess;

namespace Core.UserInterfaces.ConsoleInterface
{
    public class ConsolePlugin: IGamePlugin
    {
        private IInteraction _module;


        public ConsolePlugin(IInteraction module)
        {
            _module = module;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("[y] - start new game, [n] - exit");
                var input = Console.ReadLine();
                switch (input[0])
                {
                    case 'y':
                        Start();
                        break;
                    case 'n':
                        throw new Exception("exit");
                    default:
                        continue;
                }
                break;
            }
        }

        public void Start()
        {
            _module.StartGame();
            Play();
        }

        public void Play()
        {
            while (true)
            {
                var step = _module.GetStep();
                HandleStep(step);
            }
        }

        public void HandleStep(Step s)
        {
            Type t = s.GetType();
            if (t == typeof (VictoryStep))
            {
                Console.WriteLine("I guessed right. Do you want to see results?");
                var a = ExtractAnswer();
                if (a == AnswerType.Yes)
                    DisplaySummary();
                Console.WriteLine("Saving answers to database...");
                _module.EndGame();
                Run();
            }
            else if (t == typeof (DefeatStep))
            {
                Console.WriteLine("I have lost.");
                _module.EndGame();
                Run();
            }
            else if (t == typeof (GuessingStep))
            {
                Console.WriteLine((s as GuessingStep)?.GuessText);
                var a = ExtractAnswer();
                _module.SaveAnswer(a);
            }
            else if (t == typeof (QuestionStep))
            {
                Console.WriteLine((s as QuestionStep)?.QuestionText);
                var a = ExtractAnswer();
                _module.SaveAnswer(a);
            }
        }

        public void DisplaySummary()
        {
            var summary = _module.GetSummary();
            Console.WriteLine("Guessed person: {0}", summary.GuessedGamePerson.Name);
            Console.WriteLine("Questions:");
            int i = 1;
            foreach (var entry in summary.Entries)
            {
                Console.WriteLine("{0}: {1} - database: {2}, user: {3}",i++, entry.QuestionText, 
                    entry.SystemAnswer, entry.UserAnswer);
            }
        }

        public AnswerType ExtractAnswer()
        {
            Console.WriteLine("Provide answer: [y] - yes, [n] - no, [d] - don't know");
            while (true)
            {
                var input = Console.ReadLine();
                switch (input[0])
                {
                    case 'y':
                        return AnswerType.Yes;
                    case 'n':
                        return AnswerType.No;
                    case 'd':
                        return AnswerType.Unknown;
                }
            }
        }
    }
}
