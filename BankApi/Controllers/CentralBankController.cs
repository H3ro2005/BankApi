using BankApi.Data;
using BankApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CentralBankController : ControllerBase
    {

   

        private readonly IBank Bank;

        public CentralBankController(IBank bank) 
        {
            Bank = bank;
        }

        [HttpGet]
        public async Task<IActionResult> Gets()
        { 
            
          var bank = await Bank.GetAll();
          if(bank.Count == 0)
            {
                return NotFound("Empty List");
            }
          return Ok(bank);
        }
     
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BankId player)
        {
            if (player.Name.IsNullOrEmpty())
            {
                var errorResponse = new { errorMessage = "forget to fill" };
                return BadRequest(errorResponse);
            }
            await Bank.Add(player);
           
            return Ok(player);
        }
        [HttpDelete("{id},{s}")]
        public async Task<IActionResult> Delete(long id,string s)
        {
            await Bank.Delete(id);

            return Ok(id);
        }
        [HttpPost("Login")]
        public IActionResult Login(string player)
        {
            string token = GenerateJwtToken(player);
            if (token == null)
            {
                return NotFound("Empty List");
            }
            return Ok(token);
        }
        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6344gfgsfgs6f6sf"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, username)
    };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Set the token expiration time
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}