namespace Core.Data
{
    public abstract class Step
    {
    }

    public class DefeatStep : Step
    {
        public string Text;

        public DefeatStep(string text)
        {
            Text = text;
        }
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
        public string PersonName;
        public string Image;

        public VictoryStep(string personName, string image)
        {
            Image = image;
            PersonName = personName;
        }
    }
}
