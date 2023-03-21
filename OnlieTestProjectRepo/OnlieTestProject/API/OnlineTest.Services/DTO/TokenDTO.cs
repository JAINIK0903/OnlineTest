using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Services.DTO
{
    public class TokenDTO
    {
        public TokenDTO()
        {
            Refresh_Token = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
        public string Grant_Type { get; set; }
        public string Refresh_Token { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        [MaxLength(64, ErrorMessage = "Email address can not be longer than 64 characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(256)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must be unique and contain unique character")]
        public string Password { get; set; }
    }
}
