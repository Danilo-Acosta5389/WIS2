using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WisApi.Models;

namespace WisApi.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ProfileModel> GetUser() 
        {
            return Ok(new ProfileModel());
        }
    }
}
