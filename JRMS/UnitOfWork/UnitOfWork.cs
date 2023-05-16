using JRMS.AbstractionLayer;
using JRMS.DAL;
using Microsoft.EntityFrameworkCore;

namespace JRMS.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JMSDbContext _context;
        public IDepartmentRepository DepartmentRepository { get;}

        public  IJobApplicationRepository JobApplicationRepository { get;}

        public IJobRepository JobRepository  { get; }

        public IApplicantRepository   applicantRepository { get; }


        public UnitOfWork(IDepartmentRepository departmentRepository,
                          IJobRepository jobRepository, IJobApplicationRepository jobApplicationRepository,
                          IApplicantRepository applicantRepository, JMSDbContext context)
        {
            this.DepartmentRepository = departmentRepository;
            this.JobRepository = jobRepository;
            this.JobApplicationRepository = jobApplicationRepository;
            this.applicantRepository = applicantRepository;




            this._context = context;
        }
        public void SaveChanges()
        {
             _context.SaveChanges();
        }
        public void Dispose() { 
            this._context.Dispose();
        }
    }
}
