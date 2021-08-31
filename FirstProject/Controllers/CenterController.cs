using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;

namespace FirstProject.Controllers
{
    [Route("[controller]")]
    public class CenterController : Controller
    {
        private readonly UsersContext _context;
        public CenterController(UsersContext usersContext)
        {
            _context = usersContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetCenters()
        {
            return Ok(await Task.Run(() => _context.Center.ToArray()));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCenterById(int id)
        {
            return Ok(await Task.Run(() => _context.Center.Find(id)));
        }
        [HttpPost]
        public async Task<IActionResult> PostCenter([FromBody] Center center)
        {
            _context.Center.Add(center);

            await _context.SaveChangesAsync();

            return Ok(center);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCenters([FromBody] Center center)
        {
            _context.Center.Update(center);

            await _context.SaveChangesAsync();

            return Ok(center);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCenter(int id)
        {
            Center center = _context.Center.Find(id);

            _context.Center.Remove(center);

            await _context.SaveChangesAsync();

            return Ok(center);
        }
    }
}
