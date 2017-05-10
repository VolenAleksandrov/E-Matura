using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using E_Matura.Models.BindingModels.Questions;
using E_Matura.Models.EntityModels;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.BaseModels;
using E_Matura.Models.EntityModels.Questions;
using E_Matura.Models.Enums;
using E_Matura.Models.ViewModels.Answers;
using E_Matura.Models.ViewModels.Questions;

namespace E_Matura.Services
{
    public class QuestionService : Service
    {
	    public void AddQuestionClosedAnswer(AddQuestionClosedAnswerBm bind, string userId)
	    {
		    List<ClosedAnswer> answers = new List<ClosedAnswer>();
			answers.AddRange(new List<ClosedAnswer>()
			{
				new ClosedAnswer(bind.Answer1Text, bind.Answer1IsTrue),
				new ClosedAnswer(bind.Answer2Text, bind.Answer2IsTrue),
				new ClosedAnswer(bind.Answer3Text, bind.Answer3IsTrue),
				new ClosedAnswer(bind.Answer4Text, bind.Answer4IsTrue),
			});

		    if (answers.Count(x => x.IsTrue) > 1)
		    {
			    throw new ArgumentOutOfRangeException("True answer must be only one!");
		    }

		    User user = this.Context.Users.Entities.FirstOrDefault(c => c.Id == userId);
			QuestionClosedAnswer question = new QuestionClosedAnswer(bind.Text, bind.Points, bind.Grade, bind.Subject, bind.NumberInTest, user, answers);

		    this.Context.ClosedAnswers.AddRange(answers);
		    this.Context.Questions.Add(question);
		    this.Context.SaveChanges();
	    }

        //public IQuestionVm GetQuestionVm(int id)
        //{
        //    var model = this.Context.Questions.Find(id);
            
        //    if (model.GetType() == typeof(QuestionClosedAnswer))
        //    {
        //        IQuestionVm question = this.MapModelToQuestionClosedAnswer(model);
        //    }
        //}

        //private IQuestionVm MapModelToQuestionClosedAnswer(QuestionBase model)
        //{
        //    IQuestionVm mappedQuestion = new QuestionClosedAnswerVm()
        //    {
        //        Text = model.Text,
        //        Points = model.Points,
        //        NumberInTest = model.NumberInTest,
        //        Subject = model.Subject,
        //        Grade = model.Grade,
        //        Author = model.Author,
                
        //    };
        //}
        public List<Subject> GetSubjects(int grade)
        {
            if (grade == 0)
            {
                return new List<Subject>()
                {
                    Subject.HumanAndNature,
                    Subject.HumanAndSociety,
                    Subject.BG,
                    Subject.Math
                };
            }
            else if (grade == 1)
            {
                return new List<Subject>()
                {
                    Subject.NaturalScienceAndNature,
                    Subject.SocialSciencesCivicEducationReligion,
                    Subject.BG,
                    Subject.Math
                };
            }
            else if (grade == 2)
            {
                return new List<Subject>()
                {
                    Subject.BG,
                    Subject.RU,
                    Subject.EN,
                    Subject.Biology,
                    Subject.Chemistry,
                    Subject.Geography,
                    Subject.History,
                    Subject.Math,
                    Subject.Phisics
                };
            }
            return null;
        }

        public IEnumerable<QuestionClosedAnswerVm> GetAllQuestionsByAuthor(string userId)
        {
            var user = this.Context.Users.Entities.First(c => c.Id == userId);
            var questions = this.Context.Questions.Entities.Where(q => q.Author == user);
            List<QuestionClosedAnswerVm> mappedQuestionVm = new List<QuestionClosedAnswerVm>();
            foreach (var question in questions)
            {
                mappedQuestionVm.Add(this.MapModelToQuestion(question));
            }
            return mappedQuestionVm;
        }

        private QuestionClosedAnswerVm MapModelToQuestion(QuestionBase question)
        {
            if (question is QuestionClosedAnswer)
            {
               return this.MapModelToQuestionClosedAnswer((QuestionClosedAnswer)question);
            }
            return null;
        }

        private QuestionClosedAnswerVm MapModelToQuestionClosedAnswer(QuestionClosedAnswer model)
        {
            var answers = this.Context.ClosedAnswers.Entities.Where(a => a.Question == model);
            //modelAsQClosedAnswer.Answers.AddRange(this.Context.ClosedAnswers.Entities.Where(a => a.Question.Id == model.Id));

            var mappedAnswers = this.MapClosedAnswersToView(model.Answers.ToList());

            QuestionClosedAnswerVm mappedAddQuestion = new QuestionClosedAnswerVm()
            {
                Id = model.Id,
                Text = model.Text,
                Points = model.Points,
                NumberInTest = model.NumberInTest,
                Subject = model.Subject,
                Grade = model.Grade,
                Author = model.Author,
                AnswerVms = mappedAnswers
            };
            return mappedAddQuestion;
        }
        private EditQuestionClosedAnswerVm MapModelToEditQuestionClosedAnswerVm(QuestionClosedAnswer model)
        {
            var questionAsQuestionClosedAnswer = (QuestionClosedAnswer)model;
            IEnumerable<ClosedAnswer> answersEntity =
                this.Context.ClosedAnswers.Entities.Where(a => a.Question == model);
            questionAsQuestionClosedAnswer.Answers.AddRange(answersEntity);

            var mappedAnswers = this.MapClosedAnswersToView(questionAsQuestionClosedAnswer.Answers.ToList());

            EditQuestionClosedAnswerVm mappedEditQuestion = new EditQuestionClosedAnswerVm()
            {
                Text = model.Text,
                Points = model.Points,
                NumberInTest = model.NumberInTest,
                Subject = model.Subject,
                Grade = model.Grade,
                Author = model.Author,
                AnswerVms = mappedAnswers
            };
            return mappedEditQuestion;
        }
        private List<ClosedAnswerVm> MapClosedAnswersToView(List<ClosedAnswer> answers)
        {
            List<ClosedAnswerVm> result = new List<ClosedAnswerVm>();
            foreach (var answer in answers)
            {
                result.Add(new ClosedAnswerVm()
                {
                    Id = answer.Id,
                    Text = answer.Text,
                    IsTrue = answer.IsTrue
                });
            }
            return result;
        }
      
        public EditQuestionClosedAnswerVm GetEditQuestionVm(int id)
        {
            var question = this.Context.Questions.Find(id);
            QuestionClosedAnswer questionLikeQuestionClosedAnswer = (QuestionClosedAnswer) question;
            EditQuestionClosedAnswerVm result = this.MapModelToEditQuestionClosedAnswerVm(questionLikeQuestionClosedAnswer);
            return result;
        }
    }
}
