using COeX_India.Data;
using COeX_India.Helper;
using COeX_India.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace COeX_India.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController:Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _dbContext;

        public UsersController(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _dbContext = context;
        }

        private string GenerateToken(RailwayStations user)
        {
           

            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                 {
                    new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("StationId", user.Id.ToString()),
                    new Claim("StationCode", user.StationCode.ToString()),                    
                 };

                var token = new JwtSecurityToken
                    (
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: credentials

                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                //ProblemDetails problem = await CommonHelper.TakeReqActionOnException(ex, Request.Path.Value);
                //return Problem(title: problem.Title, detail: problem.Detail);
                return string.Empty;
            }

        }

        [AllowAnonymous]
        [HttpPost("RailwayLogin")]
        public async Task<ActionResult> RailwayLogin(RailwayLogInRequest loginModel)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(loginModel.StationNo))
                {
                    return BadRequest(new Response(false, "Please enter a valid Station No/Station Admin Id/ PassKey"));
                }

                if (string.IsNullOrWhiteSpace(loginModel.StationAdminId))
                {
                    return BadRequest(new Response(false, "Please enter a valid Station No/Station Admin Id/ PassKey"));
                }

                if(string.IsNullOrWhiteSpace(loginModel.PassKey))
                {
                    return BadRequest(new Response(false, "Please enter a valid Station No/Station Admin Id/ PassKey"));
                }

                RailwayStations station = await _dbContext.RailwayStations.AsNoTracking().Where(r => r.StationCode.ToLower() == loginModel.StationNo.ToLower() && r.StationAdminId.ToLower() == loginModel.StationAdminId.ToLower() && r.PassKey.ToLower() == loginModel.PassKey.ToLower()).FirstOrDefaultAsync();

                if (station == null)
                {
                    return BadRequest(new Response(false, "Authetication Failed"));
                }
                // if (user == null) { return BadRequest(new Response(false, "User is null")); }

                station.PassKey = "";
                var token = GenerateToken(station);

                if (token == string.Empty) { return BadRequest(new Response(false, "Please Try Again In a While")); }

                return Ok(new RailwayLogInResponse(token, station));
            }
            catch (Exception ex)
            {
                //ProblemDetails problem = await CommonHelper.TakeReqActionOnException(ex, Request.Path.Value);
                return Problem(ex.Message);
            }
        }
      

        [HttpGet("Edit")]
        [Authorize]

        public async Task<ActionResult> EditUser()
        {

            try
            {
                return Ok("hello");
            }
            catch (Exception ex)
            {
                //ProblemDetails problem = await CommonHelper.TakeReqActionOnException(ex, Request.Path.Value);
                //return Problem(title: problem.Title, detail: problem.Detail);
                return Problem(ex.Message);
            }
        }
    }
}
