﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionProduct.Api.ViewModels
{
	public class MyPromotionViewModel
	{
		public int Id { get; set; }
		public string Image { get; set; }
		public string Title { get; set; }
		public DateTime Expire { get; set; }
		public bool History { get; set; }
	}
}