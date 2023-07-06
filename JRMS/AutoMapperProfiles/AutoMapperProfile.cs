using AutoMapper;
using JRMS.DTOs;
using EntityFramework;

namespace JRMS.AutoMapperConfigurations
{
    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile() {

            CreateMap<Department, DepartmentDTO > ();
            CreateMap<Applicant, ApplicantDto>();
            CreateMap<Job_Application, Job_ApplicationDTO>();
            CreateMap<Job, JobDto>();
       }
    }
}
