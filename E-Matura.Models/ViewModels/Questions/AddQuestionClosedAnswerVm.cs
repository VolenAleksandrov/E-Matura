using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using E_Matura.Models.EntityModels;
using E_Matura.Models.Enums;
using E_Matura.Models.ViewModels.Answers;

namespace E_Matura.Models.ViewModels.Questions
{
	public class AddQuestionClosedAnswerVm : IQuestionVm
	{
        public string Text { get; set; }
        [Required]
        public int Points { get; set; }
        public Grade Grade { get; set; }
        public Subject Subject { get; set; }
        public int NumberInTest { get; set; }
	    public List<ClosedAnswerVm> AnswerVms { get; set; }
	    public User Author { get; set; }
	}
}
