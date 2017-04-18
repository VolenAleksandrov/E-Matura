using E_Matura.Models.Enums;

namespace E_Matura.Models.BindingModels.Questions
{
	public class AddQuestionClosedAnswerBm
	{
		public string Text { get; set; }
		public int Points { get; set; }
		public Grade Grade { get; set; }
		public Subject Subject { get; set; }
		public int NumberInTest { get; set; }
		public string Answer1Text { get; set; }
        public bool Answer1IsTrue { get; set; }
        public string Answer2Text { get; set; }
        public bool Answer2IsTrue { get; set; }
        public string Answer3Text { get; set; }
        public bool Answer3IsTrue { get; set; }
        public string Answer4Text { get; set; }
		public bool Answer4IsTrue { get; set; }
	}
}
