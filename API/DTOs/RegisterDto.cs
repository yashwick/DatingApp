using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        //we are recieving these as the body of the request
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        //AppUser is an Entity so we declared user name as UserName with a capital N coz otherwise mapping is a bit hard
        //But here where we have Dtos we can easily map so let's just declare user name as Username as mapping is really easy with DTOs
    }
}