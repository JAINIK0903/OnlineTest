using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
       
        public string Password { get; set; }
       
        public string Email { get; set; }
       
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }=true;
        
    }
}
