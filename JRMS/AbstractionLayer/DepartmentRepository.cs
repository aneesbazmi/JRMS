using EntityFramework;
using JRMS.DAL;

namespace JRMS.AbstractionLayer
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(JMSDbContext dbContext) : base(dbContext)
        {

        }

    }
}
