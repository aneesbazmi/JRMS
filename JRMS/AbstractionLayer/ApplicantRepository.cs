using EntityFramework;
using JRMS.DAL;

namespace JRMS.AbstractionLayer
{
    public class ApplicantRepository : GenericRepository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(JMSDbContext context) : base(context) { }
    }
}
