using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JRMS.DTOs
{
    public class ApplicantDto
    {
        [Required]
        [StringLength(50)]
        public string name { get; set; }


        public int ApplicantId { get; set; }

        [Required]
        [StringLength(50)]
        public string address { get; set; }

        [Required]
        [StringLength(50)]
        public string Email_Address { get; set; }

        [Required]
        public int Marks_In_Matriculation { get; set; }

        [Required]
        public int Marks_In_Intermediate { get; set; }

        [Required]
        public int Marks_In_Batchelor { get; set; }

        [Required]
        [StringLength(1)]
        public string Applicant_Gender { get; set; }

        [Required]
        public DateTime date_of_birth { get; set; }
    }
}
