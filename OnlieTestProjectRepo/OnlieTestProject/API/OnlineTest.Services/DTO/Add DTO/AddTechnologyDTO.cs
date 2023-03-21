using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.Add_DTO
{
    public class AddTechnologyDTO
    {
        [Required]
        [StringLength(20)]
        public string TechName { get; set; }

        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }= DateTime.Now;

        //public int? ModifiedBy { get; set; }
        //[Column(TypeName = "datetime")]
        //public DateTime? ModifiedOn { get; set; }=DateTime.Now;
        public bool IsActive { get; set; } = true;
        
    }
}
