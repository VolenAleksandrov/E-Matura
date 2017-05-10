using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using E_Matura.Models.BindingModels.Questions;
using E_Matura.Models.EntityModels;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.BaseModels;
using E_Matura.Models.EntityModels.Matura;
using E_Matura.Models.EntityModels.Questions;
using E_Matura.Models.Enums;
using E_Matura.Models.ViewModels.Answers;
using E_Matura.Models.ViewModels.Matura;
using E_Matura.Models.ViewModels.Questions;

namespace E_Matura.Services
{
    public class MaturaService : Service
    {
        public MaturaVm GenerateMatura(int grade, string subject)
        {
            MaturaVm vm = new MaturaVm();
            if (grade == 12)
            {
                switch (subject)
                {
                    case "bg":
                        vm = this.GenerateMaturaVm(Grade.ТwelfthGrade, Subject.BG);
                        break;
                }
            }
            return vm;
        }

        private MaturaVm GenerateMaturaVm(Grade grade, Subject subject)
        {
            MaturaVm matura = new MaturaVm();
            List<QuestionClosedAnswerTestVm> questions = new List<QuestionClosedAnswerTestVm>();

            for (int numberInTest = 1; numberInTest < 22; numberInTest++)
            {
                questions.Add(this.GetRandomQuestion(grade, subject, numberInTest));
            }
            matura.Questions = questions;
            return matura;
        }

        private QuestionClosedAnswerTestVm GetRandomQuestion(Grade grade, Subject subject, int numberInTest)
        {
            IEnumerable<QuestionBase> questions =
                this.Context.Questions.Entities.Where(
                    q => q.Subject == subject && q.Grade == grade && q.NumberInTest == numberInTest);
                
            Random rand = new Random();

            int index = rand.Next(0, questions.Count());

            var questionEntity = questions.ToList().ElementAt(index);
            if (questionEntity != null && questionEntity is QuestionClosedAnswer)
            {
                var questionAsQuestionClosedAnswer = (QuestionClosedAnswer)questionEntity;
                IEnumerable<ClosedAnswer> answersEntity =
                    this.Context.ClosedAnswers.Entities.Where(a => a.Question == questionEntity);
                questionAsQuestionClosedAnswer.Answers.AddRange(answersEntity);
                
                List<ClosedAnswerVm> answers = new List<ClosedAnswerVm>();
                
                for (int i = 0; i < questionAsQuestionClosedAnswer.Answers.Count; i++)
                {
                    answers.Add(this.MapClosedAnswerToVm(questionAsQuestionClosedAnswer.Answers[i]));
                }

                return this.MapQuestionClosedAnsToVm(questionAsQuestionClosedAnswer, answers);
            }
            return null;
        }

        private QuestionClosedAnswerTestVm MapQuestionClosedAnsToVm(QuestionClosedAnswer questionAsQuestionClosedAnswer, List<ClosedAnswerVm> answers)
        {
            return new QuestionClosedAnswerTestVm()
            {
                Text = questionAsQuestionClosedAnswer.Text,
                NumberInTest = questionAsQuestionClosedAnswer.NumberInTest,
                Points = questionAsQuestionClosedAnswer.Points,
                AnswerVms = answers,
                Id = questionAsQuestionClosedAnswer.Id
            };
        }

        private ClosedAnswerVm MapClosedAnswerToVm(ClosedAnswer closedAnswer)
        {
            return new ClosedAnswerVm
            {
                Id = closedAnswer.Id,
                IsTrue = closedAnswer.IsTrue,
                Text = closedAnswer.Text,
                Question = (QuestionBase)closedAnswer.Question,
            };
        }

        public MaturaResult VerificateMatura(List<QuestionClosedAnswerTestVm> questions, string userId)
        {
            var user = this.Context.Users.Entities.First(c => c.Id == userId);
            DateTime date = DateTime.Today;
            int correctAnswers = 0;

            foreach (var question in questions)
            {
                bool isCorrect = this.IsCorrectQuestionClsAns(question);
                this.AddQuestionToTakenQuestions(question, isCorrect, user, date);
                if (isCorrect)
                {
                    correctAnswers++;
                }
            }

            double rating = this.CalculateRating(questions.Count, correctAnswers);

            var result = new MaturaResult()
            {
                DateOfTake = date,
                User = user,
                Rating = rating,
            };
            this.Context.MaturaResults.Add(result);
            this.Context.SaveChanges();
            return result;
        }

        private double CalculateRating(int questionsCount, int correctAnswers)
        {
            return (correctAnswers * 6.0 / questionsCount)+2;
        }

        private void AddQuestionToTakenQuestions(QuestionClosedAnswerTestVm question, bool isCorrect, User user, DateTime date)
        {
            List<ClosedAnswer> answers = new List<ClosedAnswer>();
            var questionEntity = (QuestionClosedAnswer)this.Context.Questions.Find(question.Id);
            for (int i = 0; i < questionEntity.Answers.Count; i++)
            {

                answers.Add(new ClosedAnswer()
                {
                    Id = question.AnswerVms[i].Id,
                    IsTrue = questionEntity.Answers[i].IsTrue,
                    Question = question.AnswerVms[i].Question,
                    Text = question.AnswerVms[i].Text
                });
            }
            int? choosenAnswerId = null;
            if (question.AnswerVms.Any(a=>a.IsChecked))
            {
                choosenAnswerId = question.AnswerVms.FirstOrDefault(a => a.IsChecked).Id;
            }

            TakenQuestion takenQuestion = new TakenQuestion()
            {
                Question = this.Context.Questions.FirstOrDefault(q => q.Id == question.Id),
                DateOfTake = date,
                IsCorrect = isCorrect,
                ChoosenAnswer = this.Context.ClosedAnswers.FirstOrDefault(a=>a.Id == choosenAnswerId),
            };
            this.Context.TakenQuestions.Add(takenQuestion);
            this.Context.SaveChanges();
        }

        private bool IsCorrectQuestionClsAns(QuestionClosedAnswerTestVm question)
        {
            var questionEntity = (QuestionClosedAnswer)this.Context.Questions.Find(question.Id);
            bool flag = false;
            for (int i = 0; i < questionEntity.Answers.Count; i++)
            {
                if (question.AnswerVms[i].IsChecked && questionEntity.Answers[i].IsTrue)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public MaturaResultVm GetMaturaResult(int id)
        {
            var maturaResEntity = this.Context.MaturaResults.Find(id);
            MaturaResultVm maturaResult = Mapper.Map<MaturaResult, MaturaResultVm>(maturaResEntity);
            return maturaResult;
        }
    }
}
