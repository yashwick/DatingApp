using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers 
{ 
    [Authorize]
    // [ApiController]
    // [Route("api/[controller]")]
    //When derivd,inherited from BaseApiController No longer need to add the above
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
       
        // public UsersController(DataContext context)Instead of this we used the line below 
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        //[AllowAnonymous]//this will make all the records accessible
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>>GetUsers()//Could use lists instead but lists offer too many features so let's just go with IEnumarable
        {
            var users = await _userRepository.GetUsersAsync();
            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(usersToReturn);
        }
        //api/users/3
        //[Authorize]//when this is put you can't access the records without the token
        [HttpGet("{username}")] 
        public async Task<ActionResult<MemberDto>>GetUser(string username)//Could use lists instead but lists offer too many features so let's just go with IEnumarable
        {
             var user = await _userRepository.GetUserByUsernameAsync(username);
            // return  _mapper.Map<MemberDto>(user);
        }
    }
}