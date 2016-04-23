using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class Step
    {
    }

    public class DefeatStep : Step
    {
        
    }

    public class QuestionStep : Step
    {
        public string QuestionText;

        public QuestionStep(string questionText)
        {
            QuestionText = questionText;
        }
    }

    public class GuessingStep : Step
    {
        public string GuessText;

        public GuessingStep(string guessText)
        {
            GuessText = guessText;
        }
    }

    public class VictoryStep : Step
    {
        
    }
}
