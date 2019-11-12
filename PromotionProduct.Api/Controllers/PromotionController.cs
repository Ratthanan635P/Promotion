using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionProduct.Api.Commands;
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
		public IActionResult Get(int userId)
		{
			try
			{
				var result = context.Tb_PromotionProduct.Where(pro => pro.Status == 1 && pro.Expire >= DateTime.Today)
					.Select(pro => new PromotionProductViewModel()
					{
						Id = pro.Id,
						Expire = pro.Expire,
						Title = pro.Title,
						Image = pro.Image
					}).ToList();
				var myPromotion = context.Tb_UserPromotion.Where(upro => upro.UserId == userId && upro.History == false)				
					.ToList();

				for (int i = 0; i < result.Count; i++)
				{								
					foreach (var myPro in myPromotion)
					{
						if (myPro.PromotionId == result[i].Id)
						{
								result[i].Like = true;
	                    }
					}
				}
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
		[HttpPost("DetailPromotion")]//Get Data Promotion
		public IActionResult DetailPromotion([FromBody] UpdateCommand command)
		{
			try
			{
				var result = context.Tb_PromotionProduct.Where(pro => pro.Status == 1 && pro.Id == command.PromotionId)
					.Select(pro => new DetailPromotionViewModel()
					{
						Id = pro.Id,
						Expire = pro.Expire,
						Title=pro.Title,
						Detail = pro.Detail,
						Image = pro.Image,
					}).FirstOrDefault();
				var myPromotion = context.Tb_UserPromotion.Where(up => up.Status == 1 && up.PromotionId == command.PromotionId && up.UserId==command.UserId).FirstOrDefault();
				if (myPromotion == null)
				{
					result.History = false;
				}
				else
				{
					result.History = myPromotion.History;
				}

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
				var result = context.Tb_UserPromotion.Where(up=>up.UserId==id&&up.History==history)
					.Join(context.Tb_PromotionProduct, up => up.PromotionId, pro => pro.Id, (up, pro) => new MyPromotionViewModel()
					{
						Id = pro.Id,
						Expire = pro.Expire,
						Title = pro.Title,
						Image = pro.Image,
						Detail=pro.Detail,
						History= up.History
					})
					.ToList();
				//.Where(upro => upro.UserId == id && upro.History == history)
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
		[HttpPost("AddPromotion")]
		public IActionResult AddPromotion([FromBody] PromotionProductModel command)
		{
			try
			{
				var result = context.Tb_PromotionProduct.Add(command);
				if (result == null)
				{
					return BadRequest();
				}
				else
				{
					context.SaveChanges();
					return Ok("Success");
				}
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
