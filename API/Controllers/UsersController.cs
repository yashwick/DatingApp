using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers()//Could use lists instead but lists offer too many features so let's just go with IEnumarable
        {
             return await _context.Users.ToListAsync();
        }
        //api/user/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>>GetUsers(int id)//Could use lists instead but lists offer too many features so let's just go with IEnumarable
        {
             var user =_context.Users.FindAsync(id);
             return await user;
        }
    }
}