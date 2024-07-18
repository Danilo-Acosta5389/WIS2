using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WisApi.Models;
using WisApi.Models.DTO_s.ForumDTOs;
using WisApi.Repositories.Interfaces;

namespace WisApi.Controllers.ForumControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;
        private readonly UserManager<ExtendedIdentityUser> _userManager;
        public TopicController(ITopicRepository topicRepository, UserManager<ExtendedIdentityUser> userManager)
        {
            _topicRepository = topicRepository;
            _userManager = userManager;
        }

        [HttpGet("Topics")]
        public ActionResult<IEnumerable<TopicDTO>> GetTopics()
        {
            var topics = _topicRepository.GetByCondition(x => x.IsInvisible == false);

            if (topics is null)
            {
                return NotFound();
            }

            var response = topics.Select(x =>
                new TopicDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    UserName = x.UserName
                });

            return Ok(response);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Creator, Admin, Super")]
        public IActionResult CreateTopic(CreateTopicDTO topic)
        {
            HttpContext.Request.Cookies.TryGetValue("publicId", out var publicId);
            HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (refreshToken is null && publicId is null)
                return BadRequest("User credentials not found.");

            if (topic is null)
                return BadRequest("Something went wrong, topic content not found.");

            //Add more validation parameters in the futurre, for now this is ok
            var user = _userManager.Users.Where(x => x.PublicId == publicId && x.RefreshToken == refreshToken).SingleOrDefault();

            if (user is null)
                return NotFound("User not found");

            var newTopic = new TopicModel()
            {
                Title = topic.Title,
                Description = topic.Description,
                CreatedAt = topic.CreatedAt,
                UserName = topic.UserName,
                UserId = user.Id,
                IpAdress = ip,
                IsAnonymous = topic.IsAnonymous
            };

            _topicRepository.Create(newTopic);
            _topicRepository.Save();


            return Ok();

        }

        [HttpPut("invisible")]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult MakeInvisible([FromBody] string title)
        {

            var topic = _topicRepository.GetByCondition(x => x.Title == title).SingleOrDefault();

            if (topic == null) return NotFound();

            topic.IsInvisible = true;

            _topicRepository.Update(topic);
            _topicRepository.Save();

            return Ok();
        }

        [HttpPut("visible")]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult MakeVisible([FromBody] int topicId)
        {

            var topic = _topicRepository.GetByCondition(x => x.Id == topicId).SingleOrDefault();

            if (topic == null) return NotFound();

            topic.IsInvisible = false;

            _topicRepository.Update(topic);
            _topicRepository.Save();

            return Ok();
        }

    }
}
