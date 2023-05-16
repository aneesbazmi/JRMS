namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Applicant
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

        public int? Marks_In_Matriculation { get; set; }

        public int? Marks_In_Intermediate { get; set; }

        public int? Marks_In_Batchelor { get; set; }

        [Required]
        [StringLength(1)]
        public string Applicant_Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_of_birth { get; set; }

        public virtual ICollection<Job_Application> Job_Application { get; set; }

        public virtual Black_Listed_Candidates Black_Listed_Candidate { get; set; }

    }
}
