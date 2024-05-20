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
        public IActionResult Post(CreatePostDTO post) 
        {
            try
            {
                if (post is null) return BadRequest("Post is empty.");

                HttpContext.Request.Cookies.TryGetValue("publicId", out var publicId);
                HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

                if (publicId is null && refreshToken is null) return BadRequest("Credentials not found.");

                var user = _userManager.Users.Where(x => x.PublicId == publicId && x.RefreshToken == refreshToken).SingleOrDefault();


                var newPost = new PostModel(post.Title, post.SubTitle, post.Text, post.CreatedAt, post.UserName, user.Id, ip, post.IsAnonymous, post.TopicId);

                _postRepository.Create(newPost);
                _postRepository.Save();
                
                return Created(HttpContext.Request.GetDisplayUrl(), post);

            }
            catch (Exception e)
            {

                return Conflict("Error: " + e.Message);
            }

            
        }
    }
}
