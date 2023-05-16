using EntityFramework;
using JRMS.DAL;

namespace JRMS.AbstractionLayer
{
    public class JobApplicationRepository:  GenericRepository<Job_Application>, IJobApplicationRepository
    {

        private readonly JMSDbContext _context;
        public JobApplicationRepository(JMSDbContext context) : base(context) { _context = context; }
    }
}
