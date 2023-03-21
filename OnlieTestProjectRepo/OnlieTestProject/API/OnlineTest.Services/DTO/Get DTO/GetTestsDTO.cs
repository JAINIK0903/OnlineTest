using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.Get_DTO
{
    public class GetTestsDTO
    {
        public int Id { get; set; }
        public string TestName {get; set;}
        public string Description { get; set;}
        public int CreatedBy { get; set;}
        //[Column(TypeName ="datetime")]
        public DateTime CreatedTime { get; set;}
        //[Column(TypeName = "datetime")] 
        public DateTime ExpireOn { get; set; } 
        public int TechnologyId { get; set;}
    }
}
