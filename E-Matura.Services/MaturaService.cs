using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Matura.Models.EntityModels.BaseModels;
using E_Matura.Models.EntityModels.Interfaces;
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
                        vm = this.Generate12BgMatura(Grade.ТwelfthGrade, Subject.BG);
                        break;
                }
            }

            return vm;
        }

        private MaturaVm Generate12BgMatura(Grade grade, Subject subject)
        {
            MaturaVm matura = new MaturaVm();
            matura.Time = 60;
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
            IQueryable<QuestionClosedAnswer> questions =
                this.Context.Questions.OfType<QuestionClosedAnswer>().Where(
                    q => q.Subject == subject && q.Grade == grade && q.NumberInTest == numberInTest);
            Random rand = new Random();
            int index = rand.Next(questions.Count());

            var questionEntity = questions.ToList()[index];

            var questionType = questionEntity.GetType();
            QuestionClosedAnswerTestVm question = new QuestionClosedAnswerTestVm()
            {
                Text = questionEntity.Text,
                Answers = new List<ClosedAnswerVm>()
                {
                    questionEntity.Answers.
                }

            };

        }
    }
}
