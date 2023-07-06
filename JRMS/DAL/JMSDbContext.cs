using EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace JRMS.DAL
{
    public class JMSDbContext  :DbContext
    {
        public JMSDbContext(DbContextOptions options) : base(options) {
            
        }

        public virtual DbSet<Applicant> applicants { get; set; }
        public virtual DbSet<Department> departments { get; set; }
        public virtual DbSet<Job> jobs { get; set; }
        public virtual DbSet<Job_Application> job_application { get; set; }
        public virtual DbSet<Job_Result> job_result { get; set; }
        public virtual DbSet<Black_Listed_Candidates> black_listed_candidates { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Black_Listed_Candidates>().HasNoKey();

        }*/
    }
    
}
