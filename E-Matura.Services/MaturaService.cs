using System;
using System.Collections.Generic;
using System.Linq;
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

            for (int numberInTest = 1; numberInTest < 2; numberInTest++)
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
                Grade = questionAsQuestionClosedAnswer.Grade,
                Subject = questionAsQuestionClosedAnswer.Subject,
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
            var grade = questions[0].Grade;
            var subject = questions[0].Subject;
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

            return new MaturaResult()
            {
                DateOfTake = date,
                User = user,
                Grade = grade,
                Subject = subject,
                Rating = rating,
            };
        }

        private double CalculateRating(int questionsCount, int correctAnswers)
        {
            return correctAnswers * 6.0 / questionsCount;
        }

        private void AddQuestionToTakenQuestions(QuestionClosedAnswerTestVm question, bool isCorrect, User user, DateTime date)
        {
            List<ClosedAnswer> answers = new List<ClosedAnswer>();
            foreach (var answerVm in question.AnswerVms)
            {
                answers.Add(new ClosedAnswer()
                {
                    Id = answerVm.Id,
                    IsTrue = answerVm.IsTrue,
                    Question = answerVm.Question,
                    Text = answerVm.Text
                });
            }

            int choosenAnswerId = question.AnswerVms.FirstOrDefault(a => a.IsChecked).Id;

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
            bool flag = false;
            foreach (ClosedAnswerVm questionAnswerVm in question.AnswerVms)
            {
                if (questionAnswerVm.IsChecked && questionAnswerVm.IsTrue)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}
