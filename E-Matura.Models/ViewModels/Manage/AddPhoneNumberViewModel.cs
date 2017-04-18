using System.ComponentModel.DataAnnotations;

namespace E_Matura.Models.ViewModels.Manage
{
	public class AddPhoneNumberViewModel
	{
		[Required]
		[Phone]
		[Display(Name = "Phone Number")]
		public string Number { get; set; }
	}
}