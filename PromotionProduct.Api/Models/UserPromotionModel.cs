using System;
using System.Collections.Generic;

namespace PromotionProduct.Api.Models
{
    public partial class UserPromotionModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
		public int PromotionId { get; set; }
        public bool History { get; set; }
        public int Status { get; set; }
		//public int IsUsed { get; set; }
	}
}
