using WisApi.Data;
using WisApi.Models;
using WisApi.Repositories.Interfaces;

namespace WisApi.Repositories.Services
{
    public class CommentService : RepositoryBase<CommentModel>, ICommentRepository
    {
        public CommentService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
