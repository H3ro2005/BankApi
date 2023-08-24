using Azure.Core;
using BankApi.Data;
using BankApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Web.Http.Controllers;

namespace BankApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser User;

        public UserController(IUser user)
        {
            User = user;
        }


        [HttpPost("user")]
        public async Task<IActionResult> Post([FromBody] User player)
        {
            if (player.Name.IsNullOrEmpty())
            {
                var errorResponse = new { errorMessage = "forget to fill" };
                return BadRequest(errorResponse);
            }
           long id = await User.Add(player);
            object x = new { ids = id, hs = 0 };

            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ProtectedEndpoint(long id)
        {
           
            if (id == null || id == 0)
            {
               
                return Unauthorized();
            }

           
            

           User user = await User.Get(id);
            

            return Ok(user);
        }
        [HttpGet("{email},{password}")]
        public async Task<IActionResult> ProtectedEndpoint2(string email,string password)
        {

            if (email.IsNullOrEmpty() || password.IsNullOrEmpty() )
            {

                return Unauthorized();
            }




            long user = await User.Get(email,password);

            if(user == 0)
            {
                var errorResponse = new { errorMessage = "email" };
                return BadRequest(errorResponse);
            }
            else if(user == -1)
            {
                var errorResponse = new { errorMessage = "password" };
                return BadRequest(errorResponse);
            }
            object x = new { ids = user, hs = 0 };
            return Ok(x);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await User.Delete(id);

            return Ok(id);
        }
    }
}
