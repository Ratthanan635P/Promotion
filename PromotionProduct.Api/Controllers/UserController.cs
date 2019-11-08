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
    public class UserController : ControllerBase
    {
		private readonly Promotion_DBContext context =new Promotion_DBContext();
        //// GET: api/User/5
        [HttpGet]//Get Password
        public IActionResult Get(string email)
        {
			try
			{
				var result = context.Tb_User.FirstOrDefault(u => u.Email == email);
				if (result == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(result.Password);
				}
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
        }
		// POST: api/User
		[HttpPost("Login")]
		public IActionResult LogIn([FromBody]LoginCommand user)
		{
			try
			{
				var result = context.Tb_User.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
				if (result == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(result.Id);
				}
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
            }
		}
		// POST: api/User
		[HttpPost("Register")]
		public IActionResult Register([FromBody] RegisterCommand command)
		{
			if (command.Password != command.ConfirmPassword)
			{
				return BadRequest("Confirm password is wrong!!");
			}
			try
			{
				UserModel user = new UserModel()
				{
					Email = command.Email,
					Password=command.Password,
					Status=1
				};
				var result = context.Tb_User.Add(user);
				if (result == null)
				{
					return BadRequest();
				}
				else
				{
					context.SaveChanges();
					return Ok();
				}
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

    }
}
