namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Job_Application
    {
        public int Job_Id { get; set; }

        [Key]
        public int Application_Id { get; set; }

        [ForeignKey("Applicant")]
        public int Applicant_Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Job_Application_Date { get; set; }

        [Required]
        [StringLength(20)]
        public string Payment_Method { get; set; }

        public int? Payment_Amount { get; set; }

        public virtual Applicant Applicant { get; set; }

        public virtual Job Job { get; set; }
    }
}
