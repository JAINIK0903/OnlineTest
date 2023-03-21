using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Models
{
    public class RToken
    {
       [Key]
       public int Id { get; set; }
        [Column("Refresh_Token", TypeName = "varchar(150)")]
        public string RefreshToken { get; set; }
        [Column("Is_Stop")]
        public int IsStop { get; set; }
        [Column("Created_Date", TypeName ="datetime")]
        public DateTime CreatedOn { get; set; }
        [Column("User_Id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User UserNavigation { get; set; }
    }
}
