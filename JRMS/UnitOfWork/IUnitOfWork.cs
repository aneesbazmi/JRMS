using JRMS.AbstractionLayer;

namespace JRMS.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository DepartmentRepository { get; }
        IJobRepository JobRepository { get; }

        IJobApplicationRepository JobApplicationRepository { get; }

        IApplicantRepository applicantRepository { get; }


        void SaveChanges();
    }
}
