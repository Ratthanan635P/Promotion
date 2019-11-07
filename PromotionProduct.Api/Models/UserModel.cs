using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PromotionProduct.Api.Models
{
    public partial class UserModel
    {
        public int Id { get; set; }
		[EmailAddress]
		[Required]
        public string Email { get; set; }
		[Required]
		[StringLength(255,MinimumLength=6)]
        public string Password { get; set; }
        public int Status { get; set; }
    }
}
