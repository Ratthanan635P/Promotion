using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionProduct.Api.Commands
{
	public class UpdateCommand
	{
		public int UserId { get; set; }
		public int PromotionId { get; set; }
	}
}
