using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WisApi.Models;
using WisApi.Models.DTO_s.ForumDTOs;
using WisApi.Repositories.Interfaces;

namespace WisApi.Controllers.ForumControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<ExtendedIdentityUser> _userManager;
        private readonly IPostRepository _postRepository;
        public CommentController(IPostRepository postRepository ,ICommentRepository commentRepository, UserManager<ExtendedIdentityUser> userManager)
        {
            _commentRepository = commentRepository;
            _userManager = userManager;
            _postRepository = postRepository;
        }

        [HttpGet("{postId}")]
        public ActionResult<IEnumerable<CommentDTO>> GetComments(int postId)
        {
            try
            {
                var post = _postRepository.GetByCondition(x => x.Id == postId);
                if (post.IsNullOrEmpty()) return NotFound("Could find post of the given id.");

                var comments = _commentRepository.GetByCondition(x => x.PostId == postId);
                if (comments.IsNullOrEmpty()) return NotFound("Could not fin any comments associated with post.");

                var response = comments.Select(x => new CommentDTO
                {
                    UserName = x.UserName,
                    Comment = x.Comment,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    IsAnonymous = x.IsAnonymous,
                    PostId = x.PostId,

                });

                return Ok(response);
            }
            catch (Exception e)
            {
                return Conflict("An error occured: " + e.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult CreateComment(CreateCommentDTO comment)
        {
            try
            {
                if (comment is null) return BadRequest("No content found.");

                HttpContext.Request.Cookies.TryGetValue("publicId", out var publicId);
                HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

                if (publicId.IsNullOrEmpty() && refreshToken.IsNullOrEmpty()) return Unauthorized("No credentials found.");

                var user = _userManager.Users.Where(x => x.PublicId == publicId && x.RefreshToken == refreshToken).SingleOrDefault();

                if (user == null) return NotFound("No user found.");

                var postExist = _postRepository.GetByCondition(x => x.Id == comment.PostId);

                if (postExist.IsNullOrEmpty()) return NotFound("Post was not found.");

                var newComment = new CommentModel
                {
                    UserId = user.Id,
                    UserName = comment.UserName,
                    Comment = comment.Comment,
                    CreatedAt = comment.CreatedAt,
                    IpAdress = ip,
                    IsAnonymous = comment.IsAnonymous,
                    PostId = comment.PostId
                };

                _commentRepository.Create(newComment);
                _commentRepository.Save();

                return Ok();

            }
            catch (Exception e)
            {
                return Conflict("An error occurred: " + e.Message);
            }
        }

    }
}
