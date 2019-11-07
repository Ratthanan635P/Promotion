using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionProduct.Api.Models;
using PromotionProduct.Api.ViewModels;

namespace PromotionProduct.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
		private readonly Promotion_DBContext context = new Promotion_DBContext();
		[HttpGet]//Get Data Promotion
		public IActionResult Get()
		{
			try
			{
				var result = context.Tb_PromotionProduct.Where(pro => pro.Status==1).ToList();
				PromotionProductViewModel listPromotion = new PromotionProductViewModel() { 
	             };
				if (result == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(result);
				}
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}

//List<ProductViewModel> products = _context.Product
//				.Join(_context.Category,
//				pro => pro.CatId,
//				cat => cat.Id,
//				(pro, cat) => new ProductViewModel()
//				{
//					Id = pro.Id,
//					Name = pro.Name,
//					Price = pro.Price,
//					CategoryName = cat.Name
//				}).ToList();