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

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Name can not be longer than {1} characters")]
        public string TechName { get; set; }

        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }= DateTime.Now;
        public bool IsActive { get; set; } = true;
        
    }
}
