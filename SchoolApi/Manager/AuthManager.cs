using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolApi.Config;
using SchoolApi.Manager.Interface;
using SchoolApi.Models;
using SchoolApi.Result;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolApi.Manager
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthManager(UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }
        public async Task<AuthResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return new AuthResult
                {
                    Errors = new List<string>
                    {
                        "user does not exists"
                    }
                };
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!userHasValidPassword)
            {
                return new AuthResult
                {
                    Errors = new List<string>
                    {
                        "password is incorrect"
                    }
                };
            }

            if (!user.Status)
            {
                return new AuthResult
                {
                    Errors = new List<string>
                    {
                        "you are not active please contact admin"
                    }
                };
            }

            return new AuthResult
            {
                Success = true,
                Token = GenerateToken(user),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserId = user.Id,
                UserName = user.UserName,
            };

        }


        private string GenerateToken(ApplicationUser user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret!);
            var jwtDescreptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
                }),

                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var roles = _userManager.GetRolesAsync(user).Result;
            jwtDescreptor.Subject.AddClaims(roles.Select(x => new Claim(ClaimTypes.Role, x)));
            var token = jwtHandler.CreateToken(jwtDescreptor);
            var jwtToken = jwtHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
