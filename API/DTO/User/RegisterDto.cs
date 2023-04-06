using System.ComponentModel.DataAnnotations;

namespace API.DTO.User
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}