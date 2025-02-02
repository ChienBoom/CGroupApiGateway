﻿using CIdentity.Auth;
using CIdentity.Models;
using CIdentity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CIdentity.Controllers
{
    [Route("~/auth-api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _appDbContext;
        private readonly RedisService _redisService;

        public AuthController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            AppDbContext appDbContext,
            RedisService redisService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _appDbContext = appDbContext;
            _redisService = redisService;
        }

        [HttpGet]
        [Route("testredis")]
        public IActionResult TestRedis()
        {
            try
            {
                _redisService.SetDataAsync("Test", "Minh");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet]
        [Route("testgetredis")]
        public IActionResult TestGetRedis()
        {
            try
            {
                var rs = _redisService.GetDataAsync("Test");
                return Ok(rs.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("testgetallredis")]
        public IActionResult TestGetAllRedis()
        {
            try
            {
                var rs = _redisService.GetAllKey();
                return Ok(rs.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var refreshToken = GetRefreshToken(authClaims);
                var accessToken = GetAccessToken(authClaims);

                return Ok(new
                {
                    refreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken),
                    accessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                    expirationRefreshToken = refreshToken.ValidTo,
                    expirationAccessToken = accessToken.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserLogin model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            IdentityUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            await _userManager.AddToRoleAsync(user, UserRole.User);
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserLogin model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            IdentityUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            if (!await _roleManager.RoleExistsAsync(UserRole.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRole.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRole.User));
            await _userManager.AddToRoleAsync(user, UserRole.Admin);
            await _userManager.AddToRoleAsync(user, UserRole.User);
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }


        [HttpPost]
        [Route("getAccessToken")]
        public async Task<IActionResult> GetAccessToken([FromBody] Token value)
        {
            var refreshToken = value.RefreshToken;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(refreshToken) as JwtSecurityToken;
            if (jsonToken != null)
            {
                var userName = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;

                if (userName != null)
                {
                    var user = await _userManager.FindByNameAsync(userName);

                    if (user != null)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);

                        var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                        foreach (var userRole in userRoles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                        }
                        var accessToken = GetAccessToken(authClaims);

                        return Ok(new
                        {
                            accessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                            expirationAccessToken = accessToken.ValidTo
                        });
                    }
                    return Unauthorized();
                }
            }
            return Unauthorized();
        }

        private JwtSecurityToken GetRefreshToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMonths(6),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private JwtSecurityToken GetAccessToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                 expires: DateTime.Now.AddDays(5),
                //expires: DateTime.Now.AddMinutes(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
