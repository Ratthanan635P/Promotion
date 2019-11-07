using System;
using System.Collections.Generic;

namespace PromotionProduct.Api.Models
{
    public partial class TbUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
    }
}
