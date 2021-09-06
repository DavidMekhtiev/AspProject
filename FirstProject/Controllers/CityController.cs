using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly UsersContext _context;

        public CityController(UsersContext usersContext)
        {
            _context = usersContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await Task.Run(() => _context.City.ToArray()));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            return Ok(await Task.Run(() => _context.City.Find(id)));
        }
        [HttpPost]
        public async Task<IActionResult> PostCities([FromBody] City city)
        {
            _context.City.Add(city);

            await _context.SaveChangesAsync();

            return Ok(city);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCities([FromBody] City city)
        {
            _context.City.Update(city);

            await _context.SaveChangesAsync();

            return Ok(city);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            City city = _context.City.Find(id);

            _context.City.Remove(city);

            await _context.SaveChangesAsync();

            return Ok(city);
        }
    }
}
