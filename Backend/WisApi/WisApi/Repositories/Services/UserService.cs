using System.Linq.Expressions;
using WisApi.Data;
using WisApi.Models;
using WisApi.Repositories.Interfaces;

namespace WisApi.Repositories.Services
{
    public class UserService : RepositoryBase<ProfileModel>, IUserRepository
    {
        public UserService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
