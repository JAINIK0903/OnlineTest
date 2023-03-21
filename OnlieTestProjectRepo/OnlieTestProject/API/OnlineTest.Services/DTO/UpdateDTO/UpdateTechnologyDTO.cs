using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Services.DTO.UpdateDTO
{
    public class UpdateTechnologyDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TechName { get; set; }

        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")] 
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
       
    }
}
