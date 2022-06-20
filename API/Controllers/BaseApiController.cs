using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]//Automatically validates the parameters that we pass in to the APiI end point based on the validation that we set
    [Route("api/[controller]")]
    public class BaseApiController:ControllerBase
    {
        
    }
}