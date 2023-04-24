using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Seeder.Interface;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IUserSeeder _userSeeder;

        public SeedController(IUserSeeder userSeeder)
        {
            _userSeeder = userSeeder;
        }

        [HttpPost]
        public async Task<IActionResult> SeedAdminUser() 
        {
            try 
            {
                await _userSeeder.SeedAdminuser();
                return Ok("Admin user seeded successfully. ");
            } 
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
