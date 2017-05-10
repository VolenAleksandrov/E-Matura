using System.ComponentModel.DataAnnotations;
using E_Matura.Models.Enums;

namespace E_Matura.Models.BindingModels.Questions
{
	public class AddQuestionClosedAnswerBm
	{
        [MinLength(3)]
		public string Text { get; set; }
        [Required]
		public int Points { get; set; }
        [Required]
		public Grade Grade { get; set; }
        [Required]
		public Subject Subject { get; set; }
        [Required]
		public int NumberInTest { get; set; }
        [Required, MinLength(5)]
		public string Answer1Text { get; set; }
        public bool Answer1IsTrue { get; set; }
        [Required, MinLength(5)]
        public string Answer2Text { get; set; }
        public bool Answer2IsTrue { get; set; }
        [Required, MinLength(5)]
        public string Answer3Text { get; set; }
        public bool Answer3IsTrue { get; set; }
        [MinLength(5)]
        public string Answer4Text { get; set; }
		public bool Answer4IsTrue { get; set; }
	}
}
