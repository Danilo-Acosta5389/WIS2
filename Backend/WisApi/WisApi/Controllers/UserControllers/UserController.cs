using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WisApi.Migrations.ApplicationDb;
using WisApi.Models;
using WisApi.Models.DTO_s.ProfileDTOs;
using WisApi.Repositories.Interfaces;

namespace WisApi.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ExtendedIdentityUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(UserManager<ExtendedIdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;

        }

        [HttpGet("{userName}")]
        public ActionResult<GetProfileDTO> GetUser(string userName) 
        {
            var user = _userManager.Users.Where(x => x.UserName == userName).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            var result = new GetProfileDTO()
            {
                UserName = user.UserName,
                Bio = user.Bio,
                ImageName = user.ImageName,
                ImageSrc = string.Format("{0}://{1}{2}/Images/{3}",Request.Scheme,Request.Host,Request.PathBase,user.ImageName)
            };

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUserDetails([FromForm] EditProfileDTO model)
        {
            var user = _userManager.Users.Where(x => x.UserName == model.UserName).SingleOrDefault();
            if (user == null)
            {
                return BadRequest();
            }

            if (model.Bio != null) { user.Bio = model.Bio; }
            if (model.ImageFile != null)
            {
                string imageName = await SaveImage(model.ImageFile);
                user.ImageName = imageName;
            }

            await _userManager!.UpdateAsync(user);
            return Ok();
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yyyymmdd") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
