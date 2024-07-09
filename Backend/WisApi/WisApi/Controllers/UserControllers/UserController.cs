using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(UserManager<ExtendedIdentityUser> userManager, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        //Change GetUser to retrieve data from UserRepository instead of 
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

        //The following action updates users Bio and Image
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

        //SaveImage should be in a service
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


        //Don't forget to set authorized roles here
        //Blocking action 
        [HttpPut("block")]
        [Authorize(Roles = "Admin, Super")]
        public async Task<ActionResult> BlockUser([FromBody]string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user.UserName == userName)
            {
                user.IsBlocked = true;
                await _userManager!.UpdateAsync(user);
                return Ok("User blocked");
            }
            return BadRequest();
        }

        //Don't forget to set authorized roles here
        //Unblocking user
        [HttpPut("unblock")]
        [Authorize(Roles = "Admin, Super")]
        public async Task<ActionResult> UnBlockUser([FromBody] string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user.UserName == userName)
            {
                user.IsBlocked = false;
                await _userManager!.UpdateAsync(user);
                return Ok("User unblocked");
            }
            return BadRequest();
        }

        //UpgradeUserRole 
        [HttpPut("upgrade/user")]
        [Authorize(Roles = "Creator, Admin, Super")]
        public async Task<ActionResult> UpgradeUserRole([FromBody] UpgradeRoleDTO upgradeInfo)
        {

            //Make This Action less fat
            //Use repository/Services

            var upgradedByUser = _httpContextAccessor.HttpContext.User;
            var byUserName = upgradedByUser.FindFirstValue(ClaimTypes.Name);
            var byRole = upgradedByUser.FindFirstValue(ClaimTypes.Role);

            //Lookup target user, if not found, return NotFound()
            var user = await _userManager!.FindByNameAsync(upgradeInfo.TargetUser);
            if (user.UserName == upgradeInfo.TargetUser)
            {
                var currentRoleList = await _userManager.GetRolesAsync(user);
                var currentRole = currentRoleList.SingleOrDefault();

                if (byRole == "Creator") {

                    if (currentRole != "User") 
                        return BadRequest($"{upgradeInfo.TargetUser} is not upgradable by {byUserName}");

                    await _userManager.AddToRoleAsync(user, upgradeInfo.NewRole);
                    await _userManager.RemoveFromRoleAsync(user, currentRole);
                    return Ok($"Successfully changed {user.UserName}'s role from {currentRole} to {upgradeInfo.NewRole}");
                }

                if (byRole == "Admin")
                {
                    if (currentRole != "User" || currentRole != "Creator") 
                        return BadRequest($"{upgradeInfo.TargetUser} is not upgradable by {byUserName}");

                    await _userManager.AddToRoleAsync(user, upgradeInfo.NewRole);
                    await _userManager.RemoveFromRoleAsync(user, currentRole);
                    return Ok($"Successfully changed {user.UserName}'s role from {currentRole} to {upgradeInfo.NewRole}");

                }

                if (byRole == "Super")
                {
                    //What if it is another super user?

                    await _userManager.AddToRoleAsync(user, upgradeInfo.NewRole);
                    await _userManager.RemoveFromRoleAsync(user, currentRole);
                    return Ok($"Successfully changed {user.UserName}'s role from {currentRole} to {upgradeInfo.NewRole}");
                }
                return BadRequest("Something went wrong. Please try again.");
            }
            return NotFound();
        }


        //Report user action
    }
}
