using System;
using System.Collections.Generic;

namespace PromotionProduct.Api.Models
{
    public partial class TbPromotionProduct
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime Expire { get; set; }
        public int Status { get; set; }
    }
}
