namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Black_Listed_Candidates
    {
        
        public int Black_Listed_CandidatesId { get; set; }

        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }

        public virtual Applicant Applicant { get; set; }
    }
}