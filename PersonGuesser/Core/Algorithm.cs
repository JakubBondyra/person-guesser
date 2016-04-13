using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public partial class DataModule
    {
        private Step computeNextStep()
        {
            //TODO, question limit must be done neatly:
            if (_gameData.QuestionsAsked == 40)
            {
                _gameState = GameState.Finished;
                return new DefeatStep();
            }

            if (_gameState == GameState.Initialized)
            {
                var question = retrieveFirstQuestion();
                _gameState = GameState.InProgress;

                if (question == null)
                {
                    _gameState = GameState.Finished;
                    return new DefeatStep();
                }

                _currentQuestion = question;
                return new QuestionStep(question.QuestionText);
            }
            else if (_gameState == GameState.InProgress)
            {
                if (canGuess(_gameData.PeopleSet))
                {
                    var guessFeature = retrieveGuessingQuestion();
                    GuessedPerson = guessFeature.Item1;
                    _gameState = GameState.Guessing;
                    return new GuessingStep(guessFeature.Item2);
                }
                else
                {
                    var question = retrieveRegularQuestion();
                    if (question == null)
                    {
                        _gameState = GameState.Finished;
                        return new DefeatStep();
                    }
                    _currentQuestion = question;
                    return new QuestionStep(question.QuestionText);
                }
            }
            else if (_gameState == GameState.Guessing)
            {
                _gameData.PeopleSet.Remove(GuessedPerson);
                GuessedPerson = null;
                _gameState = GameState.InProgress;
                //TODO: introduce some guessing limit
                //some recursion should simplify everything
                return computeNextStep();
            }
            else
            {
                //game finished. only occurs when system has guessed correctly
                return new VictoryStep();
            }
        }

        private Question retrieveRegularQuestion()
        {
            //operate on database - get proper question in PeopleSet and QuestionSet context
            //update peopleset currentanswer field
            throw new NotImplementedException();
        }

        private Question retrieveFirstQuestion()
        {
            //operate on database - get proper question
            //update peopleset currentanswer field
            throw new NotImplementedException();
        }

        private Tuple<Person,string> retrieveGuessingQuestion()
        {
            //take person and question for it
            throw new NotImplementedException();
        }

        private bool canGuess(ICollection<Person> peopleSet)
        {
            //if one of persons is very distinguishable from the others return true
            throw new NotImplementedException();
        }

        private void updatePersonAnswers(Person person)
        {
            //operate on database, take answers for this person and add them to QuestionSet
            throw new NotImplementedException();
        }
    }
}
