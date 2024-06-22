using System.Linq.Expressions;
using WisApi.Data;
using WisApi.Models;
using WisApi.Repositories.Interfaces;

namespace WisApi.Repositories.Services
{
    public class ProfileService : RepositoryBase<ProfileModel>, IProfileRepository
    {
        public ProfileService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
