using System.ComponentModel.DataAnnotations;
using E_Matura.Models.EntityModels.BaseModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_Matura.Models.ViewModels.Answers
{
	public class ClosedAnswerVm
	{
	    public int Id { get; set; }
        [Required, MinLength(5)]
        public string Text { get; set; }
		public bool IsTrue { get; set; }
	    public bool IsChecked { get; set; }
        public QuestionBase Question { get; set; }
	}
}
