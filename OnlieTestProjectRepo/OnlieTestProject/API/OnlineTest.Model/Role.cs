using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Models
{
    public class Role
    {
        [Required]
        
        public int Id { get; set; }
        [MaxLength(32)]
        public string RoleName { get; set; }
        
    }
}
