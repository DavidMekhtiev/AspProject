using FirstProject.Helper;
using FirstProject.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FirstProject.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UsersContext _context;
        public AccountsController(UsersContext usersContext)
        {
            _context = usersContext;
        }

        [EnableCors()]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (user == null)
                return BadRequest(new { errorText = "Invalid Email or Password!" });

            var identity = GetIdentity(user.Email, user.Password);
            if (identity == null)
                return null;

            var now = DateTime.UtcNow;
            // Создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            object response = await Task.Run(() => new
            {
                Token = encodedJwt,
                UserId = _context.Users.FirstOrDefault(x => x.Email == user.Email).Id,
                Email = identity.Name,
                Role = _context.Users.FirstOrDefault(x => x.Email == user.Email).Role.Name,
                //Centers = _context.Center.
                //    Where(x => _context.CenterUsers.
                //    Where(x => x.UserId == _context.Users.
                //    FirstOrDefault(x => x.Email == user.Email).Id).
                //    Select(x => x.CenterId).
                //    Contains(x.Id)).
                //    Select(x => new { x.Id, x.Name })
            });

            await _context.SaveChangesAsync();

            return Ok(response);
        }

        private ClaimsIdentity GetIdentity(string email, string password)
        {
            // Выборка пользователей из БД
            User user = _context.Users.FirstOrDefault(x => x.Email == email);

            bool _validPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (user != null && _validPassword)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, _context.Role.FirstOrDefault(x => x.Id == user.RoleId).Name)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
