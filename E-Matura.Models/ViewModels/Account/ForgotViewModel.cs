using System.ComponentModel.DataAnnotations;

namespace E_Matura.Models.ViewModels.Account
{
	public class ForgotViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}