using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionProduct.Api
{
	public class LoginCommand
	{
		[EmailAddress]
		[Required]
		public string Email { get; set; }
		[Required]
		[StringLength(255, MinimumLength = 2)]
		public string Password { get; set; }
	}
}
