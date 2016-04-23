using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace Core.UserInterfaces
{
    public interface IGamePlugin
    {
        void Run();
        void Play();
        void Start();
        AnswerType ExtractAnswer();
        void HandleStep(Step s);
        void DisplaySummary();
    }
}
