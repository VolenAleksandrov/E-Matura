using System.ComponentModel.DataAnnotations;

namespace E_Matura.Models.ViewModels.Account
{
	public class ForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}