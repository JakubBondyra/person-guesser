﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

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
                _gameState = GameState.UninitializedPeopleSet;

                if (question == null)
                {
                    _gameState = GameState.Finished;
                    return new DefeatStep();
                }

                _currentGameQuestion = question;
                return new QuestionStep(question.QuestionText);
            }
            else if (_gameState == GameState.InProgress)
            {
                if (canGuess(_gameData.PeopleSet))
                {
                    var guessFeature = retrieveGuessingQuestion();
                    GuessedGamePerson = guessFeature.Item1;
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
                    _currentGameQuestion = question;
                    return new QuestionStep(question.QuestionText);
                }
            }
            else if (_gameState == GameState.Guessing)
            {
                _gameData.PeopleSet.Remove(GuessedGamePerson);
                GuessedGamePerson = null;
                _gameState = GameState.InProgress;
                //TODO: introduce some guessing limit
                //some recursion should simplify everything
                return computeNextStep();
            }
            else if (_gameState == GameState.Finished)
            {
                //game finished. only occurs when system has guessed correctly
                return new VictoryStep();
            }
            throw new Exception("compute next step: invalid something");
        }

        private GameQuestion retrieveRegularQuestion()
        {
            //operate on database - get proper question in PeopleSet and QuestionSet context
            //update peopleset currentanswer field
            throw new NotImplementedException();
        }

        private GameQuestion retrieveFirstQuestion()
        {
            //operate on database - get proper question
            //update peopleset currentanswer field
            var unforgiveableQuestions = _context.GetQuestions(x => x.Unforgiveable);
            if (unforgiveableQuestions == null || unforgiveableQuestions?.Count == 0)
                unforgiveableQuestions = _context.GetAllQuestions();
            var bestQuestion = getBestPartition(unforgiveableQuestions);
            
            var gameQuestion = new GameQuestion()
            {
                QuestionId = bestQuestion.QuestionId,
                PersonAnswer = AnswerType.Unknown,
                QuestionText = bestQuestion.Text,
                UserAnswer = AnswerType.Unknown
            };
            _gameData.QuestionSet.Add(gameQuestion);
            return gameQuestion;
        }

        private Question getBestPartition(IList<Question> questions)
        {
            Question bestQuestion = null;
            var bestSum = int.MinValue;
            foreach (var question in questions)
            {
                var preciseAnswers = _context.GetAnswers(x => x.QuestionId == question.QuestionId)
                    .Select(x=> x.YesCount > x.NoCount ? 1 : -1).Sum();
                if (Math.Abs(preciseAnswers) < Math.Abs(bestSum))
                {
                    bestSum = preciseAnswers;
                    bestQuestion = question;
                }
            }
            return bestQuestion;
        }

        private Tuple<GamePerson,string> retrieveGuessingQuestion()
        {
            //take GamePerson and question for it
            throw new NotImplementedException();
        }

        private bool canGuess(ICollection<GamePerson> peopleSet)
        {
            //if one of persons is very distinguishable from the others return true
            throw new NotImplementedException();
        }

        private void updatePersonAnswers(GamePerson gamePerson)
        {
            //operate on database, take answers for this GamePerson and add them to QuestionSet
            throw new NotImplementedException();
        }
    }
}
