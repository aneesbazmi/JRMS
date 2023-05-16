namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Department
    {
       
        [Key]
        public int Dept_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Dept_Name { get; set; }

        public virtual ICollection<Job>? Jobs { get; set; }
    }
}
