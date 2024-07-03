using System.Linq.Expressions;
using WisApi.Data;
using WisApi.Models.DTO_s.ProfileDTOs;
using WisApi.Repositories.Interfaces;

namespace WisApi.Repositories.Services
{
    public class UserService : RepositoryBase<GetProfileDTO>, IUserRepository
    {
        public UserService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
