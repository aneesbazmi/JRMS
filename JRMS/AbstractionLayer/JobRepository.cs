using EntityFramework;
using JRMS.DAL;
using Microsoft.EntityFrameworkCore;

namespace JRMS.AbstractionLayer
{
    public class JobRepository :GenericRepository<Job>, IJobRepository
    {
        private readonly JMSDbContext _context;
        public JobRepository(JMSDbContext context) : base(context) { _context = context; }

        public Job BringJobDepartment(int? id)
        {

            if (id == null)
                return null;
            return _context.jobs.Include("Department").SingleOrDefault(x => x.Job_Id == id);

        }

        public IEnumerable<Job> GetAllJobs()
        {
            return this._context.jobs.Include("Department");
        }
    }
}
