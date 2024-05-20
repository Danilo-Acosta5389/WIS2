using WisApi.Data;
using WisApi.Models;
using WisApi.Repositories.Interfaces;

namespace WisApi.Repositories.Services
{
    public class PostService : RepositoryBase<PostModel>, IPostRepository
    {
        public PostService(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
