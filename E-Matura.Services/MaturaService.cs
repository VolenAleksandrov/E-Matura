using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.BaseModels;
using E_Matura.Models.EntityModels.Interfaces;
using E_Matura.Models.EntityModels.Questions;
using E_Matura.Models.Enums;
using E_Matura.Models.Utils;
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
                        vm = this.Generate12BgMatura(Grade.ТwelfthGrade, Subject.BG);
                        break;
                }
            }
            return vm;
        }

        private MaturaVm Generate12BgMatura(Grade grade, Subject subject)
        {
            MaturaVm matura = new MaturaVm();
            matura.Time = Constants.Bb12MaturaTime;
            List<IQuestionVm> questions = new List<IQuestionVm>();

            for (int numberInTest = 1; numberInTest < 30; numberInTest++)
            {
                questions.Add(this.GetQuestion(grade, subject, numberInTest));
            }
            matura.Questions = questions;
            return matura;
        }

        private IQuestionVm GetQuestion(Grade grade, Subject subject, int numberInTest)
        {
            IQueryable<QuestionBase> questions =
                this.Context.Questions.Where(
                    q => q.Subject == subject && q.Grade == grade && q.NumberInTest == numberInTest);
                //this.Context.Questions.Where(
                //    q => q.Subject == subject && q.Grade == grade && q.NumberInTest == numberInTest);
            Random rand = new Random();
            int index = rand.Next(0, questions.Count());

            var questionEntity = questions.ElementAt(index);
            if (questionEntity != null && questionEntity is QuestionClosedAnswer)
            {
                int answersCount = 4;
                List<ClosedAnswerVm> answers = new List<ClosedAnswerVm>();
                if (questionEntity.Subject == Subject.EN)
                {
                    answersCount = 3;
                }
                for (int i = 0; i < answersCount; i++)
                {
                    var questionAsQuestionClosedAnswer = questionEntity as QuestionClosedAnswer;
                    var answer = new ClosedAnswerVm
                    {
                        IsTrue = questionAsQuestionClosedAnswer.Answers[i].IsTrue,
                        Text = questionAsQuestionClosedAnswer.Answers[i].Text
                    };
                    answers.Add(answer);
                }
                return new QuestionClosedAnswerTestVm()
                {
                    Text = questionEntity.Text,
                    AnswerVms = answers,
                    NumberInTest = questionEntity.NumberInTest,
                    Points = questionEntity.Points
                };
            }
            return null;
        }
    }
}
