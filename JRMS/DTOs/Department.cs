using System.ComponentModel.DataAnnotations;

namespace JRMS.DTOs
{
    public class Department
    {
        public int Dept_id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Dept_Name { get; set; }
    }
}
