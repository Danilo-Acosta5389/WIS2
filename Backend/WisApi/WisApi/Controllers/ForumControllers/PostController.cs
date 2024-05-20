using Microsoft.AspNetCore.Mvc;
using WisApi.Models.DTO_s.ForumDTOs;
using WisApi.Repositories.Interfaces;

namespace WisApi.Controllers.ForumControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
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
    }
}
