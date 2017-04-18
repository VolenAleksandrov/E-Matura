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
		public ClosedAnswerVm Answer1 { get; set; }
		public ClosedAnswerVm Answer2 { get; set; }
		public ClosedAnswerVm Answer3 { get; set; }
		public ClosedAnswerVm Answer4 { get; set; }
	    public User Author { get; set; }
	}
}
