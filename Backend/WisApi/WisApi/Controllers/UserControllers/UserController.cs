using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WisApi.Models;

namespace WisApi.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ExtendedIdentityUser> _userManager;

        public UserController(UserManager<ExtendedIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{userName}")]
        public ActionResult<ProfileModel> GetUser(string userName) 
        {
            var user = _userManager.Users.Where(x => x.UserName == userName).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            var result = new ProfileModel()
            {
                UserName = user.UserName,
                Bio = user.Bio,
                Image = user.Image,
            };


            return Ok(result);
        }
    }
}
