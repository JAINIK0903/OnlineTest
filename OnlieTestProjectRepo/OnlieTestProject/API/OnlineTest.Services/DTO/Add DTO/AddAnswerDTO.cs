using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Services.DTO.Add_DTO
{
    public class AddAnswerDTO
    {
        [Required(ErrorMessage ="Answer is Required")]
        public string AName { get; set; }
        public bool IsActive { get; set; }=true;
        [Required]
        public int CreatedBy { get; set; }
        [Column("datetime")]
        public DateTime CreatedTime { get; set; }=DateTime.Now;
    }
}
