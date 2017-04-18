using System;
using System.Collections.Generic;
using System.Linq;
using E_Matura.Models.BindingModels.Questions;
using E_Matura.Models.EntityModels;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.Questions;

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

		    User user = this.Context.Users.FirstOrDefault(c => c.Id == userId);
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
    }
}
