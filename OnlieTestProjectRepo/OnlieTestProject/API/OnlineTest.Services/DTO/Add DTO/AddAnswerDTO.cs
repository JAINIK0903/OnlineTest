using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.Add_DTO
{
    public class AddAnswerDTO
    {
        [Required]
        [StringLength(50)]
        public string AName { get; set; }
        public bool IsActive { get; set; }=true;
        [Required]
        public int CreatedBy { get; set; }
        [Column("datetime")]
        public DateTime CreatedTime { get; set; }=DateTime.Now;
    }
}
