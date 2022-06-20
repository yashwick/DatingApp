using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    //When derivd,inherited from BaseApiController No longer need to add the above
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        [AllowAnonymous]//this will make all the records accessible
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers()//Could use lists instead but lists offer too many features so let's just go with IEnumarable
        {
             return await _context.Users.ToListAsync();
        }
        //api/users/3
        [Authorize]//when this is put you can't access the records without the token
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>>GetUsers(int id)//Could use lists instead but lists offer too many features so let's just go with IEnumarable
        {
             var user =_context.Users.FindAsync(id);
             return await user;
        }
    }
}