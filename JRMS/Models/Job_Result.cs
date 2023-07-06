namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Job_Result
    {
        [Key]
        public int Job_Result_Id { get; set; }

        [ForeignKey("Applicant")]
        public int Applicant_Id { get; set; }

        [ForeignKey("Job")]
        public int Job_Id { get; set; }

        public decimal Obtained_Marks_In_Test { get; set; }

        public decimal Obtained_Marks_In_Interview { get; set; }

        public int Total_Marks_Out_Of_200 { get; set; }

        public virtual Job Job { get; set; }
        public virtual Applicant applicant { get; set; }
    }
}
