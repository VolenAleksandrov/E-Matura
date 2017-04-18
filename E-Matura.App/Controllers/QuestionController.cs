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
			return this.View(new QuestionClosedAnswerVm());
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
			return this.RedirectToAction("AddQuestionClosedAnswer");
		}
                       
		//public ActionResult AddQuestionOpenAnswer()
		//{
		//	throw new NotImplementedException();
		//}

        //[HttpGet]
        //[Route("{id:int}")]
        //public ActionResult ShowQuestion(int id)
        //{
        //    var questionVm = this.service.GetQuestionVm(id);
        //    return this.View(questionVm);
        //}
    }
}