using WisApi.Data;
using WisApi.Models;
using WisApi.Repositories.Interfaces;

namespace WisApi.Repositories.Services
{
    public class TopicService : RepositoryBase<TopicModel>, ITopicRepository
    {
        public TopicService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
