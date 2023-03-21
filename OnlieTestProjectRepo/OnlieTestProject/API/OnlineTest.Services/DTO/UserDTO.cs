using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO
{
    public class UserDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name can not be longer than 50 characters")]
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
    }
}
