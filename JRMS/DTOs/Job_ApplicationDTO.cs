using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JRMS.DTOs
{
    public class Job_ApplicationDTO
    {
        public int Job_Id { get; set; }

        [Required]
        public int Application_Id { get; set; }

        [Required]
        public int Applicant_Id { get; set; }

        [Required]
        public DateTime Job_Application_Date { get; set; }

        [Required]
        [StringLength(20)]
        public string Payment_Method { get; set; }

        [Required]
        public int? Payment_Amount { get; set; }
    }

}
