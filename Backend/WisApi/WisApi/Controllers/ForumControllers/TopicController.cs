using Microsoft.AspNetCore.Mvc;
using WisApi.Models.DTO_s.ForumDTOs;
using WisApi.Repositories.Interfaces;

namespace WisApi.Controllers.ForumControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;
        public TopicController(ITopicRepository topicRepository) 
        {
            _topicRepository = topicRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TopicDTO>> GetTopics()
        {
            var topics = _topicRepository.GetAll();

            if (topics == null)
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

    }
}
