using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Services.DTO.Add_DTO
{
    public class AddTestDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        public int TechnologyId { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")] 
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        [StringLength(200)]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string TestName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExpireOn { get; set; }= DateTime.Now;
        public bool isActive { get; set; }=true;
    }
}
