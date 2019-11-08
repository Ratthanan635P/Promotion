using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionProduct.Api.Commands;
using PromotionProduct.Api.Models;

namespace PromotionProduct.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPromotionController : ControllerBase
    {
		private readonly Promotion_DBContext context = new Promotion_DBContext();
		private static Random random = new Random();
		[HttpPost("GetCode")]
		public IActionResult GetCodePromotion([FromBody] UpdateCommand command)
		{
			try
			{
				var result = context.Tb_UserPromotion.FirstOrDefault(up => up.UserId == command.UserId && up.PromotionId == command.PromotionId);
				if (result == null)
				{
					return BadRequest();
				}
				else
				{
					result.History = true;
					context.SaveChanges();
					return Ok(RandomCode());
				}
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpPost("AddMyPromotion")]
		public IActionResult AddMyPromotion([FromBody] UpdateCommand command)
		{
			try
			{
				UserPromotionModel userModel = new UserPromotionModel()
				{
					History = false,
					Status = 1,
					UserId = command.UserId,
					PromotionId = command.PromotionId
				};

				var result = context.Tb_UserPromotion.Add(userModel);
				if(result==null)
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
		public string RandomCode()
		{
			const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, random.Next(8,10))
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}

	}
}