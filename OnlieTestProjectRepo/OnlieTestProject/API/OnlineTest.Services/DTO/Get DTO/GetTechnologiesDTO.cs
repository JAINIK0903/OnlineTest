using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.Get_DTO
{
    public class GetTechnologiesDTO
    {
        public int Id { get; set; }
        public string TechName { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")] 
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        
    }
}
