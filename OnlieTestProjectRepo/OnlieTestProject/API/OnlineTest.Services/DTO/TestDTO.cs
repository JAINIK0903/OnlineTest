using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO
{
    public class TestDTO
    {
        [Key]
        public int Id { get; set; }
        public string TestName { get; set; }
        public string Description { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime ExpireOn { get; set; }

        public int TechnologyId { get; set; }
    }
}
