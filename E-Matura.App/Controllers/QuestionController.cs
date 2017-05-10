using System.Collections.Generic;
using System.Web.Mvc;
using E_Matura.Models.BindingModels.Questions;
using E_Matura.Models.ViewModels.Questions;
using E_Matura.Services;
using Microsoft.AspNet.Identity;

namespace E_Matura.App.Controllers
{
	[RoutePrefix("questions")]
    [Authorize(Roles = "Admin, Teacher")]
    public class QuestionController : Controller
	{
		private QuestionService service;

		public QuestionController()
		{
			this.service = new QuestionService();
		}

		[HttpGet]
		[Route("add/closedAnswer")]
        [Authorize(Roles = "Admin, Teacher")]
        public ActionResult AddQuestionClosedAnswer()
		{
			return this.View(new AddQuestionClosedAnswerVm());
		}

		[HttpPost]
        [Route("add/closedAnswer")]
		public ActionResult AddQuestionClosedAnswer([Bind(Include = "Text, Grade, Subject, Points, numberInTest, Answer1Text, Answer1IsTrue, Answer2Text, Answer2IsTrue, Answer3Text, Answer3IsTrue, Answer4Text, Answer4IsTrue")] AddQuestionClosedAnswerBm bind)
		{
			if (this.ModelState.IsValid)
			{
				var userId = this.User.Identity.GetUserId();
				this.service.AddQuestionClosedAnswer(bind, userId);
				return this.RedirectToAction("Index", "Home");
			}
			return this.View();
		}

	    [HttpGet]
	    [Route("chooseSubject/{grade}")]
	    public ActionResult ChooseSubject(int grade)
	    {
	        var vm = this.service.GetSubjects(grade);
	        return this.PartialView("_ChooseSubjectPartial", vm);
	    }

	    [HttpGet]
	    [Route("all")]
	    public ActionResult AllQuestions()
	    {
	        var userId = this.User.Identity.GetUserId();
	        IEnumerable<QuestionClosedAnswerVm> questionsVm = this.service.GetAllQuestionsByAuthor(userId);
	        return this.View(questionsVm);
	    }

        //public ActionResult AddQuestionOpenAnswer()
        //{
        //	throw new NotImplementedException();
        //}

        [HttpGet]
        [Route("edit/{id:int}")]
        [Authorize(Roles = "Admin, Teacher")]
        public ActionResult EditQuestion(int id)
        {
            EditQuestionClosedAnswerVm questionVm = this.service.GetEditQuestionVm(id);
            return this.View(questionVm);
        }
        [HttpPost]
        [Route("edit/{id:int}")]
        [Authorize(Roles = "Admin, Teacher")]
        public ActionResult EditQuestion(EditQuestionClosedAnswerVm model)
        {

            return this.RedirectToAction("AddQuestionClosedAnswer");
        }
    }
}