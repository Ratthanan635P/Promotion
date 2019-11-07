using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionProduct.Api.Commands
{
	public class RegisterCommand
	{
		[EmailAddress]
		[Required]
		public string Email { get; set; }
		[Required]
		[StringLength(255, MinimumLength = 6)]
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
	}
}
