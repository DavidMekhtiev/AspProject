using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly UsersContext _context;

        public UsersController(UsersContext usersContext)
        {
            _context = usersContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await Task.Run(() => _context.Users.ToArray()));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await Task.Run(() => _context.Users.Find(id)));
        }
        [HttpGet]
        [Route("roles/{role}")]
        public async Task<IActionResult> GetUsersByRole(int role)
        {
            return Ok(await Task.Run(() => _context.Users.Where(x => x.Role.Id == role).ToArray()));
        }
        [HttpPost]
        public async Task<IActionResult> PostUsers([FromBody] User model)
        {
            if (model.Password != null)
                model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            _context.Users.Add(model);

            await _context.SaveChangesAsync();

            return Ok(model);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUsers([FromBody] User model)
        {
            _context.Users.Update(model);

            await _context.SaveChangesAsync();

            return Ok(model);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User user = _context.Users.Find(id);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
