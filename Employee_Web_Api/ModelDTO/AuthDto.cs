using System.ComponentModel.DataAnnotations;

namespace Employee_Web_Api.ModelDTO
{
    public class AuthDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
