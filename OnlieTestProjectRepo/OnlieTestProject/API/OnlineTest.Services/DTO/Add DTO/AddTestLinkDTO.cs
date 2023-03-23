using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.Add_DTO
{
    public class AddTestLinkDTO
    {
        public int TestId { get; set; }
        public int UserId { get; set; }
        public Guid Token { get; set; }
        public int Attempts { get; set; }
        public DateTime ExpireOn { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
