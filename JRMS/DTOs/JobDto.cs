using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JRMS.DTOs
{
    public class JobDto
    {
        public int Job_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Job_Title { get; set; }

        public DateTime Jobb_Adverstisement_Date { get; set; }

        public int Job_Dept_Id { get; set; }

        public DateTime Job_Last_Date_Apply { get; set; }

        [Required]
        public byte Total_Open_Merit_Seats { get; set; }

        [Required]
        public byte Job_Scale { get; set; }


        [Required]
        public byte Job_Total_Seats { get; set; }

        [Required]
        public byte Total_Women_Seats { get; set; }

        public DateTime? Job_Result_Declaration_Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Job_Posting_City_Name { get; set; }

        [Required]
        public byte Is_Contract_Based { get; set; }

    }
}