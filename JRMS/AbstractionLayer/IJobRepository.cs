using EntityFramework;

namespace JRMS.AbstractionLayer
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Job BringJobDepartment(int? id);
        IEnumerable<Job> GetAllJobs();


    }
}
