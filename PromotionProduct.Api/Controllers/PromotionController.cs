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
				var result = context.Tb_PromotionProduct.Where(pro => pro.Status == 1)
					.Select(pro => new PromotionProductViewModel()
					{
						Id = pro.Id,
						Expire = pro.Expire,
						Title=pro.Title,
						Image=pro.Image
					}).ToList();

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
		[HttpGet("DetailPromotion")]//Get Data Promotion
		public IActionResult DetailPromotion(int Promotionid)
		{
			try
			{
				var result = context.Tb_PromotionProduct.Where(pro => pro.Status == 1 && pro.Id== Promotionid)
					.Select(pro => new DetailPromotionViewModel()
					{
						Id = pro.Id,
						Expire = pro.Expire,
						Detail = pro.Detail,
						Image = pro.Image
					}).ToList();

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
		[HttpGet("MyPromotion")]//Get My Promotion
		public IActionResult MyPromotion(int id,bool history)
		{
			try
			{
				var result = context.Tb_UserPromotion.Where(upro => upro.UserId == id &&upro.History== history)
					.Join(context.Tb_PromotionProduct, up => up.PromotionId, pro => pro.Id, (up, pro) => new MyPromotionViewModel()
					{
						Id = pro.Id,
						Expire = pro.Expire,
						Title = pro.Title,
						Image = pro.Image,
						History= up.History
					})
					.ToList();
				
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
