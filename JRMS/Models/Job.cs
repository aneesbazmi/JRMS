namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("job")]
    public partial class Job
    {
        

        [Required]
        [StringLength(50)]
        public string Job_Title { get; set; }

        [Key]
        public int Job_Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Jobb_Adverstisement_Date { get; set; }

        [ForeignKey("Department")]
        public int Job_Dept_Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Job_Last_Date_Apply { get; set; }


        [Required]
        public byte Job_Scale { get; set; }


        [Required]
        public byte Job_Total_Seats { get; set; }

        [Required]
        public byte Total_Women_Seats { get; set; }

        [Required]
        public byte Total_Open_Merit_Seats { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Job_Result_Declaration_Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Job_Posting_City_Name { get; set; }

        [Required]
        public byte Is_Contract_Based { get; set; }

        [Required]
        public virtual Department Department { get; set; }

        [Required]
        public virtual ICollection<Job_Application> Job_Application { get; set; }

        [Required]
        public virtual ICollection<Job_Result> Job_Result { get; set; }
    }
}
