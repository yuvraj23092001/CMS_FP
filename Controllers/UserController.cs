using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmsBackend.Models;

namespace SmsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly FinalSmsContext _context;

        public UserController(FinalSmsContext context) {
            /*_smsContext = smsContext;*/
            _context = context;
        }

        [HttpPost("authenticate")]
        /*[HttpPost]
        [Route("login")]*/
        // we need to check if the email and password are valid or not . 
        public async Task<IActionResult> login([FromBody] string Email) // 
        {
            if(Email == null)
            {
                return BadRequest();
            }

            User? userobj = await _context.Users.Where(x => x.EmailId == Email ).FirstOrDefaultAsync();

            if(userobj == null)
            {
                return NotFound();
            }

            return Ok(userobj);
        }

        [HttpPost("Register")]

        public async Task<IActionResult> register([FromBody] User usr)
        {
            if (usr == null)
            {
                return BadRequest();
            }

           await _context.Users.AddAsync(usr);
           await _context.SaveChangesAsync();

            return Ok(new
            {
                Message ="User Registered"
            });
        }

        // add class teachers to the classes so we are able to get students based on their class id 


    }
}
