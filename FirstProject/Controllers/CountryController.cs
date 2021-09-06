using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly UsersContext _context;

        public CountryController(UsersContext usersContext)
        {
            _context = usersContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(await Task.Run(() => _context.Country.ToArray()));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            return Ok(await Task.Run(() => _context.Country.Find(id)));
        }
        [HttpPost]
        public async Task<IActionResult> PostCountries([FromBody] Country country)
        {
            _context.Country.Add(country);

            await _context.SaveChangesAsync();

            return Ok(country);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCountries([FromBody] Country country)
        {
            _context.Country.Update(country);

            await _context.SaveChangesAsync();

            return Ok(country);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            Country country = _context.Country.Find(id);

            _context.Country.Remove(country);

            await _context.SaveChangesAsync();

            return Ok(country);
        }
    }
}
