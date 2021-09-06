using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly UsersContext _context;

        public RoleController(UsersContext usersContext)
        {
            _context = usersContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await Task.Run(() => _context.Role.ToArray()));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            return Ok(await Task.Run(() => _context.Role.Find(id)));
        }
        [HttpPost]
        public async Task<IActionResult> PostRoles([FromBody] Role role)
        {
            _context.Role.Add(role);

            await _context.SaveChangesAsync();

            return Ok(role);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRoles([FromBody] Role role)
        {
            _context.Role.Update(role);

            await _context.SaveChangesAsync();

            return Ok(role);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            Role role = _context.Role.Find(id);

            _context.Role.Remove(role);

            await _context.SaveChangesAsync();

            return Ok(role);
        }
    }
}
