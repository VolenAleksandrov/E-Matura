using System.Collections.Generic;
using E_Matura.Models.EntityModels;
using E_Matura.Models.Enums;
using E_Matura.Models.ViewModels.Answers;

namespace E_Matura.Models.ViewModels.Questions
{
	public class QuestionClosedAnswerVm : IQuestionVm
	{
		public string Text { get; set; }
		public int Points { get; set; }
		public Grade Grade { get; set; }
		public Subject Subject { get; set; }
		public int NumberInTest { get; set; }
	    public List<ClosedAnswerVm> AnswerVms { get; set; }
	    public User Author { get; set; }
	}
}
