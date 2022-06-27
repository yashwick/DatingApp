using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext  _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }


        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }


        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.Users.Find(-1);
            if (thing == null) return NotFound();
            return Ok(thing);
        }


        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            // try{
            //     var thing = _context.Users.Find(-1);
            //     var ThingToReturn = thing.ToString();
            //     return ThingToReturn;
            // }catch(Exception ex){
            //     return StatusCode(500, "Yashhhhhhhhhhhhhhh");//setting status code to 500
            // }
            // If we don't have app.UseDeveloperExceptionPage() in startup.cs we need add try catch for all the end points;
            var thing = _context.Users.Find(-1);
            var thingToReturn = thing.ToString();//Null referance exception is generated
            return thingToReturn;
        }


        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Yo this is no good request");
        }
    }
}