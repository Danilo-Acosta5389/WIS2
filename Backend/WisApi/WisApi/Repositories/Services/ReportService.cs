using WisApi.Data;
using WisApi.Models;
using WisApi.Repositories.Interfaces;

namespace WisApi.Repositories.Services
{
    public class ReportService : RepositoryBase<ReportModel>, IReportRepository
    {
        public ReportService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
