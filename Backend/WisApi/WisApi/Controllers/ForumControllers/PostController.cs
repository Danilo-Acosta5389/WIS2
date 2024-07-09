using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WisApi.Models;
using WisApi.Models.DTO_s.ForumDTOs;
using WisApi.Repositories.Interfaces;

namespace WisApi.Controllers.ForumControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly UserManager<ExtendedIdentityUser> _userManager;
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository, UserManager<ExtendedIdentityUser> userManager)
        {
            _postRepository = postRepository;
            _userManager = userManager;
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PostDTO>> GetSinglePost(int id)
        {
            var posts = _postRepository.GetByCondition(x => x.Id == id);

            if (posts is null)
                return NotFound();

            var response = posts.Select(x =>
            new PostDTO
            {
                Id = x.Id,
                Title = x.Title,
                SubTitle = x.SubTitle,
                Text = x.Text,
                UserName = x.UserName,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            });

            return Ok(response);
        }

        [HttpGet("byTopic/{id}")]
        public ActionResult<IEnumerable<PostDTO>> GetPosts(int id)
        {
            var posts = _postRepository.GetByCondition(x => x.TopicId == id);

            if (posts is null)
                return NotFound();

            var response = posts.Select(x => new PostDTO
            {
                Id = x.Id,
                Title = x.Title,
                SubTitle= x.SubTitle,
                Text = x.Text,
                UserName = x.UserName,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            });

            return Ok(response);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "User, Creator, Admin, Super")]
        public IActionResult Post(CreatePostDTO post) 
        {
            try
            {
                if (post is null) return BadRequest("Post is empty.");

                HttpContext.Request.Cookies.TryGetValue("publicId", out var publicId);
                HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

                if (publicId is null && refreshToken is null) return Unauthorized("Credentials not found.");

                var user = _userManager.Users.Where(x => x.PublicId == publicId && x.RefreshToken == refreshToken).SingleOrDefault();

                if (user == null) return BadRequest("User not found");

                var newPost = new PostModel()
                {
                    Title = post.Title,
                    SubTitle = post.SubTitle,
                    Text = post.Text,
                    UserName = post.IsAnonymous ? "Anonymous" : post.UserName,
                    CreatedAt = post.CreatedAt,
                    UserId = user?.Id,
                    IpAdress = ip,
                    IsAnonymous = post.IsAnonymous,
                    TopicId = post.TopicId,
                };

                _postRepository.Create(newPost);
                _postRepository.Save();
                
                return Created(HttpContext.Request.GetDisplayUrl(), post);

            }
            catch (Exception e)
            {

                return Conflict("Error: " + e.Message);
            }

            
        }

        [HttpPut("invisible")]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult MakeInvisible([FromBody] int postId)
        {

            var post = _postRepository.GetByCondition(x => x.Id == postId).SingleOrDefault();

            if (post == null) return NotFound();

            post.IsInvisible = true;

            _postRepository.Update(post);
            _postRepository.Save();

            return Ok();
        }

        [HttpPut("visible")]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult MakeVisible([FromBody] int postId)
        {

            var post = _postRepository.GetByCondition(x => x.Id == postId).SingleOrDefault();

            if (post == null) return NotFound();

            post.IsInvisible = false;

            _postRepository.Update(post);
            _postRepository.Save();

            return Ok();
        }
    }
}
