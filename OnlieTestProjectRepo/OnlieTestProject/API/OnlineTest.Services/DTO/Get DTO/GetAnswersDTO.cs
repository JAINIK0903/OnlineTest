using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.Get_DTO
{
    public class GetAnswersDTO
    {
        public int Id { get; set; }
        public string AName { get; set; }
        public bool IsActive { get; set; }=true; 
        public int CreatedBy { get; set; }
        [Column("datetime")]
        public DateTime CreatedTime { get; set; }
    }
}
